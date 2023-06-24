pipeline {
    agent any
    
    stages {
        stage('Build') {
            steps {
                sh 'apt update' // Run apt update
                sh 'apt upgrade -y' // Run apt upgrade with the -y flag to automatically answer yes to prompts
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
