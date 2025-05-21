pipeline {
    agent any

    environment {
        // Telegram configre
        TOKEN = credentials('telegram_token')
        CHAT_ID = credentials('telegram_chatid')

        // AWS credentials
        AWS_ACCESS_KEY_ID = credentials('aws_access')
        AWS_SECRET_ACCESS_KEY = credentials('aws_secret')
        AWS_DEFAULT_REGION = 'ap-southeast-1'

        // Telegram message
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
        TEXT_AWS_CONFIG = "${JOB_NAME} is Configuring AWS"

        // Telegram parameters
        TEXT_SUCCESS_BUILD = "${JOB_NAME} is Success"
        TEXT_FAILURE_BUILD = "${JOB_NAME} is Failure"
        TEXT_TEST_RESULTS = "${JOB_NAME} Test Results"
    }

    stages {
        stage('Run Unit Tests') {
            steps {
                sh "curl --location --request POST 'https://api.telegram.org/bot${TOKEN}/sendMessage' --form text='${TEXT_TEST}' --form chat_id='${CHAT_ID}'"
                sh 'curl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --channel 8.0'

                script {
                    try {
                        sh '''
                            export PATH="$PATH:$HOME/.dotnet"
                            dotnet workload install aspire
                            dotnet test --logger "trx;LogFileName=test-results.trx" --collect:"XPlat Code Coverage" --results-directory ./TestResults
                        '''

                        sh '''
                            TEST_SUMMARY=$(grep -A 5 "Total tests" ./TestResults/test-results.trx || echo "No test summary found")
                            echo "$TEST_SUMMARY" > test-summary.txt
                        '''

                        def testSummary = readFile('test-summary.txt').trim()

                        sh "curl --location --request POST 'https://api.telegram.org/bot${TOKEN}/sendMessage' --form text='${TEXT_TEST_RESULTS}\n${testSummary}' --form chat_id='${CHAT_ID}'"
                    } catch (Exception e) {
                        sh "curl --location --request POST 'https://api.telegram.org/bot${TOKEN}/sendMessage' --form text='${TEXT_TEST_RESULTS}\nTests failed: ${e.getMessage()}' --form chat_id='${CHAT_ID}'"
                        error "Unit tests failed: ${e.getMessage()}"
                    }
                }
            }
        }

        stage('Configure AWS') {
            steps {
                sh "curl --location --request POST 'https://api.telegram.org/bot${TOKEN}/sendMessage' --form text='${TEXT_AWS_CONFIG}' --form chat_id='${CHAT_ID}'"

                sh '''
                    aws configure set aws_access_key_id ${AWS_ACCESS_KEY_ID}
                    aws configure set aws_secret_access_key ${AWS_SECRET_ACCESS_KEY}
                    aws configure set default.region ${AWS_DEFAULT_REGION}
                '''

                sh 'aws sts get-caller-identity'
            }
        }

        stage('Build') {
            steps {
                sh "curl --location --request POST 'https://api.telegram.org/bot${TOKEN}/sendMessage' --form text='${TEXT_PRE}' --form chat_id='${CHAT_ID}'"
                sh "curl --location --request POST 'https://api.telegram.org/bot${TOKEN}/sendMessage' --form text='${TEXT_BUILD}' --form chat_id='${CHAT_ID}'"

                sh '''
                    docker build \
                    --build-arg AWS_ACCESS_KEY_ID=${AWS_ACCESS_KEY_ID} \
                    --build-arg AWS_SECRET_ACCESS_KEY=${AWS_SECRET_ACCESS_KEY} \
                    --build-arg AWS_DEFAULT_REGION=${AWS_DEFAULT_REGION} \
                    -t yamiannephilim/yanlib:latest .
                '''
            }
        }

        stage('Push') {
            steps {
                sh "curl --location --request POST 'https://api.telegram.org/bot${TOKEN}/sendMessage' --form text='${TEXT_PUSH}' --form chat_id='${CHAT_ID}'"

                withDockerRegistry(credentialsId: 'docker_hub', url: 'https://index.docker.io/v1/') {
                    sh 'docker push yamiannephilim/yanlib'
                }
            }
        }

        stage('Clean') {
            steps {
                sh "curl --location --request POST 'https://api.telegram.org/bot${TOKEN}/sendMessage' --form text='${TEXT_CLEAN}' --form chat_id='${CHAT_ID}'"

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
                sh "curl --location --request POST 'https://api.telegram.org/bot${TOKEN}/sendMessage' --form text='${TEXT_RUN}' --form chat_id='${CHAT_ID}'"
                sh 'docker container stop yanlib || echo "this container does not exist"'
                sh 'docker network create yan || echo "this network exist"'
                sh 'echo y | docker container prune'

                sh '''
                    docker run --name yanlib \
                    --network yan \
                    --restart=unless-stopped \
                    -e AWS_ACCESS_KEY_ID=${AWS_ACCESS_KEY_ID} \
                    -e AWS_SECRET_ACCESS_KEY=${AWS_SECRET_ACCESS_KEY} \
                    -e AWS_DEFAULT_REGION=${AWS_DEFAULT_REGION} \
                    -d yamiannephilim/yanlib:latest
                '''
            }
        }
    }

    post {
        always {
            archiveArtifacts artifacts: 'TestResults/**/*', allowEmptyArchive: true
            junit testResults: 'TestResults/test-results.trx', allowEmptyResults: true
            cleanWs()
        }

        success {
            script {
                sh "curl --location --request POST 'https://api.telegram.org/bot${TOKEN}/sendMessage' --form text='${TEXT_SUCCESS_BUILD}' --form chat_id='${CHAT_ID}'"
            }
        }

        failure {
            script {
                sh "curl --location --request POST 'https://api.telegram.org/bot${TOKEN}/sendMessage' --form text='${TEXT_FAILURE_BUILD}' --form chat_id='${CHAT_ID}'"
            }
        }
    }
}
