pipeline {
    agent any

    stages {
        stage('Build') {
            steps {
                script {
                    def img = 'httpd:2.4-alpine'
                    docker.image(img).run('-d -p 80:80')
                }
            }
        }
    }
}
