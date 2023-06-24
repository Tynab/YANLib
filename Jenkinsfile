pipeline {
    agent any
    
    stages {
        stage('Build') {
            steps {
                script {
                    docker.withTool('docker') {
                        def imageName = 'yanlib'
                        def imageTag = 'latest'
                        
                        sh "docker build -t ${imageName}:${imageTag} ."
                    }
                }
            }
        }
    }
}
