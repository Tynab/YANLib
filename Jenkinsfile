pipeline {
    agent any

    environment {
        // Telegram configre
        // TOKEN = credentials('telegram_token')
        // CHAT_ID = credentials('telegram_chatid')

        // AWS credentials
        AWS_ACCESS_KEY_ID = credentials('aws_access')
        AWS_SECRET_ACCESS_KEY = credentials('aws_secret')
        AWS_DEFAULT_REGION = 'ap-southeast-1'
        AWS_PROFILE = 'Tynab'

        // Message
        GIT_MESSAGE = sh(returnStdout: true, script: "git log -n 1 --format=%s ${GIT_COMMIT}").trim()
        GIT_AUTHOR = sh(returnStdout: true, script: "git log -n 1 --format=%ae ${GIT_COMMIT}").trim()
        GIT_COMMIT_SHORT = sh(returnStdout: true, script: "git rev-parse --short ${GIT_COMMIT}").trim()
        GIT_INFO = "Branch: ${GIT_BRANCH}\nLast Message: ${GIT_MESSAGE}\nAuthor: ${GIT_AUTHOR}\nCommit: ${GIT_COMMIT_SHORT}"
        TEXT_BREAK = '----------------------------------------'
        TEXT_PRE = "${TEXT_BREAK}\n${GIT_INFO}"
        TEXT_TEST = "${JOB_NAME} is Running Tests"
        TEXT_BUILD = "${JOB_NAME} is Building"
        TEXT_PUSH = "${JOB_NAME} is Pushing"
        TEXT_CLEAN = "${JOB_NAME} is Cleaning"
        TEXT_RUN = "${JOB_NAME} is Running"

        // Parameters
        TEXT_SUCCESS_BUILD = "${JOB_NAME} is Success"
        TEXT_FAILURE_BUILD = "${JOB_NAME} is Failure"
        TEXT_TEST_RESULTS = "${JOB_NAME} Test Results"

        // Recipients
        RECIPIENTS = 'nguyendangtruongan10071993@gmail.com'
    }

    stages {
        stage('Run Unit Tests') {
            steps {
                // sh "curl --location --request POST 'https://api.telegram.org/bot${TOKEN}/sendMessage' --form text='${TEXT_TEST}' --form chat_id='${CHAT_ID}'"
                sh 'curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --channel 8.0'

                script {
                    try {
                        sh '''
                            export PATH="$PATH:$HOME/.dotnet"

                            dotnet workload install aspire
                            dotnet test test/YANLib.Domain.Tests/YANLib.Domain.Tests.csproj --logger "trx;LogFileName=domain-tests.trx" --results-directory ./TestResults
                            dotnet test test/YANLib.EntityFrameworkCore.Tests/YANLib.EntityFrameworkCore.Tests.csproj --logger "trx;LogFileName=ef-tests.trx" --results-directory ./TestResults
                            dotnet test test/YANLib.Tests/YANLib.Tests.csproj --filter "FullyQualifiedName~YANLib.Tests.Library.Snowflake" --logger "trx;LogFileName=snowflake-tests.trx" --results-directory ./TestResults
                        '''

                        sh '''
                            DOMAIN_TESTS=$(grep -o "passed=\"[0-9]*\"" ./TestResults/domain-tests.trx | grep -o "[0-9]*" || echo "0")
                            EF_TESTS=$(grep -o "passed=\"[0-9]*\"" ./TestResults/ef-tests.trx | grep -o "[0-9]*" || echo "0")
                            SNOWFLAKE_TESTS=$(grep -o "passed=\"[0-9]*\"" ./TestResults/snowflake-tests.trx | grep -o "[0-9]*" || echo "0")

                            TOTAL_TESTS=$((DOMAIN_TESTS + EF_TESTS + SNOWFLAKE_TESTS))

                            echo "Test Summary:" > test-summary.txt
                            echo "Domain Tests: $DOMAIN_TESTS" >> test-summary.txt
                            echo "EntityFrameworkCore Tests: $EF_TESTS" >> test-summary.txt
                            echo "Snowflake Tests: $SNOWFLAKE_TESTS" >> test-summary.txt
                            echo "Total Tests Run: $TOTAL_TESTS" >> test-summary.txt
                            echo "Note: Only running specific test categories to avoid stack overflow issues" >> test-summary.txt
                        '''

                        def testSummary = readFile('test-summary.txt').trim()

                        // sh "curl --location --request POST 'https://api.telegram.org/bot${TOKEN}/sendMessage' --form text='${TEXT_TEST_RESULTS}\n${testSummary}' --form chat_id='${CHAT_ID}'"
                        emailext(
                            subject: "${TEXT_TEST_RESULTS}",
                            body: """\
========================================
${GIT_INFO}

${testSummary}
========================================
""",
                            to: "${RECIPIENTS}"
                        )
                    } catch (Exception e) {
                        // sh "curl --location --request POST 'https://api.telegram.org/bot${TOKEN}/sendMessage' --form text='${TEXT_TEST_RESULTS}\nTests failed: ${e.getMessage()}' --form chat_id='${CHAT_ID}'"
                        emailext(
                            subject: "${TEXT_TEST_RESULTS} - Lỗi",
                            body: """\
========================================
${GIT_INFO}

Tests failed: ${e.getMessage()}
========================================
""",
                            to: "${RECIPIENTS}"
                        )

                        error "Unit tests failed: ${e.getMessage()}"
                    }
                }
            }
        }

        stage('Build') {
            steps {
                // sh "curl --location --request POST 'https://api.telegram.org/bot${TOKEN}/sendMessage' --form text='${TEXT_PRE}' --form chat_id='${CHAT_ID}'"
                // sh "curl --location --request POST 'https://api.telegram.org/bot${TOKEN}/sendMessage' --form text='${TEXT_BUILD}' --form chat_id='${CHAT_ID}'"
                emailext(
                    subject: "${TEXT_BUILD}",
                    body: """\
========================================
${GIT_INFO}

${TEXT_BUILD}
========================================
""",
                    to: "${RECIPIENTS}"
                )

                sh 'docker build -t yamiannephilim/yanlib:latest .'
            }
        }

        stage('Push') {
            steps {
                // sh "curl --location --request POST 'https://api.telegram.org/bot${TOKEN}/sendMessage' --form text='${TEXT_PUSH}' --form chat_id='${CHAT_ID}'"
                emailext(
                    subject: "${TEXT_PUSH}",
                    body: """\
========================================
${GIT_INFO}

${TEXT_PUSH}
========================================
""",
                    to: "${RECIPIENTS}"
                )

                withDockerRegistry(credentialsId: 'docker_hub', url: 'https://index.docker.io/v1/') {
                    sh 'docker push yamiannephilim/yanlib'
                }
            }
        }

        stage('Clean') {
            steps {
                // sh "curl --location --request POST 'https://api.telegram.org/bot${TOKEN}/sendMessage' --form text='${TEXT_CLEAN}' --form chat_id='${CHAT_ID}'"
                emailext(
                    subject: "${TEXT_CLEAN}",
                    body: """\
========================================
${GIT_INFO}

${TEXT_CLEAN}
========================================
""",
                    to: "${RECIPIENTS}"
                )

                script {
                    def containerId = sh(returnStdout: true, script: 'docker ps -aqf "name=yanlib"').trim()

                    if (containerId) {
                        sh "docker stop $containerId"
                        sh "docker rm $containerId"
                    }
                }
            }
        }

        stage('Run') {
            steps {
                // sh "curl --location --request POST 'https://api.telegram.org/bot${TOKEN}/sendMessage' --form text='${TEXT_RUN}' --form chat_id='${CHAT_ID}'"
                emailext(
                    subject: "${TEXT_RUN}",
                    body: """\
========================================
${GIT_INFO}

${TEXT_RUN}
========================================
""",
                    to: "${RECIPIENTS}"
                )

                sh 'docker container stop yanlib || echo "this container does not exist"'
                sh 'docker network create yan || echo "this network exist"'
                sh 'echo y | docker container prune'

                sh '''
                    docker run --name yanlib --network yan \
                    -e AWS_ACCESS_KEY_ID=${AWS_ACCESS_KEY_ID} \
                    -e AWS_SECRET_ACCESS_KEY=${AWS_SECRET_ACCESS_KEY} \
                    -e AWS_DEFAULT_REGION=${AWS_DEFAULT_REGION} \
                    -e AWS_PROFILE=${AWS_PROFILE} \
                    -d yamiannephilim/yanlib:latest
                '''
            }
        }
    }

    post {
        always {
            archiveArtifacts artifacts: 'TestResults/**/*', allowEmptyArchive: true
            junit testResults: 'TestResults/*.trx', allowEmptyResults: true
            cleanWs()
        }

        success {
            script {
                // sh "curl --location --request POST 'https://api.telegram.org/bot${TOKEN}/sendMessage' --form text='${TEXT_SUCCESS_BUILD}' --form chat_id='${CHAT_ID}'"
                emailext(
                subject: "${TEXT_SUCCESS_BUILD}",
                body: """\
========================================
${GIT_INFO}

Build SUCCESS!
========================================
""",
                to: "${RECIPIENTS}"
                )
            }
        }

        failure {
            script {
                // sh "curl --location --request POST 'https://api.telegram.org/bot${TOKEN}/sendMessage' --form text='${TEXT_FAILURE_BUILD}' --form chat_id='${CHAT_ID}'"
                emailext(
                subject: "${TEXT_FAILURE_BUILD}",
                body: """\
========================================
${GIT_INFO}

Build FAILED!
========================================
""",
                to: "${RECIPIENTS}"
                )
            }
        }
    }
}
