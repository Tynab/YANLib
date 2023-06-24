pipeline {
    agent any
    stages {
        stage('Build stage') {
            steps {
                script {
                    withDockerRegistry(credentialsId: 'yanlib', url: 'https://index.docker.io/v1/') {
                        docker.image('docker:latest').inside('-v /var/run/docker.sock:/var/run/docker.sock') {
                            sh 'docker build -t yamiannephilim/yanlib:v230611 .'
                            sh 'docker push yamiannephilim/yanlib:v230611'
                        }
                    }
                }
            }
        }
    }
}
