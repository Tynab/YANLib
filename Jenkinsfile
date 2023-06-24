pipeline {
    agent any
    
    stages {
        stage('Build') {
            steps {
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
