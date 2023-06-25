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
                sh 'docker stop yanlib'
                sh 'docker rm yanlib'
            }
        }

        stage('Run') {
            steps {
                sh 'docker run --name yanlib --network yan -d yanlib:latest'
            }
        }
    }
}
