pipeline {
    agent {
        docker {
            image 'alpine:latest'
            args '-v /var/run/docker.sock:/var/run/docker.sock'
        }
    }

    stages {
        stage('Build') {
            steps {
                sh 'apk add --no-cache docker'
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
