pipeline {
    agent {
        docker {
            image 'jenkins/inbound-agent:4.10-1-alpine'
        }
    }
    
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
