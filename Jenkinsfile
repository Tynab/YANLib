pipeline {
    agent any
    
    stages {
        stage('Build') {
            steps {
                sh 'apt update'
                sh 'apt upgrade -y'
                sh 'apt-get install --assume-yes docker.io'
                sh 'apt update'
                sh 'apt upgrade -y'
                sh 'docker build -t yanlib:latest .'
            }
        }
        
        stage('Run') {
            steps {
                sh 'docker run --name yanlib -d yanlib:latest'
            }
        }
    }
}
