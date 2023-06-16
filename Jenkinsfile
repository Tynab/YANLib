pipeline {
    agent {
        docker {
            image 'jenkins/jenkins:dind'
            args '--privileged --user root --group-add docker'
        }
    }
    stages {
        stage('Build stage') {
            steps {
                withDockerRegistry(credentialsId: 'yanlib', url: 'https://index.docker.io/v1/') {
                    sh 'docker build -t yamiannephilim/yanlib:v230611 .'
                    sh 'docker push yamiannephilim/yanlib:v230611'
                }
            }
        }
    }
}