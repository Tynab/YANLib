pipeline {
    agent any
    
    stages {
        stage('Build') {
            steps {
                script {
                    def imageName = 'yanlib'
                    def imageTag = 'latest'
                    sh "docker build -t ${imageName}:${imageTag} ."
                }
            }
        }
    }
}
