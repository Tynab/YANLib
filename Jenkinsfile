pipeline {
    agent any
    
    stages {
        stage('Build') {
            steps {
                sh 'docker build -t yamiannephilim/yanlib:latest .'
            }
        }

        // stage('Push') {
        //     steps {
        //         withDockerRegistry(credentialsId: 'docker_hub', url: 'https://index.docker.io/v1/') {
        //             sh 'docker push yamiannephilim/yanlib'
        //         }
        //     }
        // }
        stage('Push') {
            steps {
                withDockerRegistry([credentialsId: 'docker_hub', url: 'https://index.docker.io/v1/']) {
                    script {
                        def registry = 'https://index.docker.io/v1/'
                        def image = 'yamiannephilim/yanlib'
                        def dockerCreds = docker.getRegistryCredentials('docker_hub')

                        docker.withRegistry(registry, dockerCreds) {
                            sh "echo ${dockerCreds.PASSWORD} | docker login --username ${dockerCreds.US‌ERNAME} --password-stdin"
                            sh "docker push ${image}"
                        }
                    }
                }
            }
        }

        stage('Clean') {
            steps {
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
                sh 'docker container stop yanlib || echo "this container does not exist"'
                sh 'docker network create yan || echo "this network exist"'
                sh 'echo y | docker container prune'
                sh 'docker run --name yanlib --network yan --restart=unless-stopped -d yamiannephilim/yanlib:latest'
            }
        }
    }

    post {
        always {
            cleanWs()
        }
    }
}
