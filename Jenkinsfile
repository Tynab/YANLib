def gv

pipeline {
    agent any
    stages {
        stage('init') {
            steps {
                script {
                    echo "Initializing Groovy Script..."
                    gv = load "script.groovy"
                }
            }
        }
        stage('build') {
            steps {
                script {
                    echo "Build Docker Image with Dockerfile..."
                    gv.buildImage()
                }
            }
        }
        stage('push') {
            steps {
                script {
                    echo "Pushing Docker Image to Docker Hub Repo..."
                    gv.pushImage()
                }
            }
        }
        stage('deploy') {
            steps {
                script {
                    echo "Deploying the application to EC2..."
                    gv.deployImage()
                }
            }
        }
    }   
}
