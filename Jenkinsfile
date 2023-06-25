pipeline {
    agent any
    
    stages {
        stage('Build') {
            steps {
                sh 'docker build -t yanlib:latest .'
            }
        }

        stage('Cleaning') {
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
                sh 'docker run --name yanlib --network yan -d yanlib:latest'
            }
        }
    }
}
