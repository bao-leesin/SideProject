pipeline {
    agent any
    
    environment {
        IMAGE_NAME = 'sideproject'
        CONTAINER_NAME = 'sideproject-app'
        HOST_PORT = '5000'
        CONTAINER_PORT = '80'
    }
    
    stages {
        stage('Checkout') {
            steps {
                echo 'Checking out code from GitHub...'
                checkout scm
            }
        }
        
        stage('Build Docker Image') {
            steps {
                echo 'Building Docker image...'
                sh "docker build -t ${IMAGE_NAME}:latest ."
            }
        }
        
        stage('Stop Old Container') {
            steps {
                echo 'Stopping old container if exists...'
                sh "docker stop ${CONTAINER_NAME} || true"
                sh "docker rm ${CONTAINER_NAME} || true"
            }
        }
        
        stage('Deploy') {
            steps {
                echo 'Starting new container...'
                sh "docker run -d --name ${CONTAINER_NAME} -p ${HOST_PORT}:${CONTAINER_PORT} ${IMAGE_NAME}:latest"
                echo "Application deployed at http://localhost:${HOST_PORT}"
            }
        }
        
        stage('Verify Deployment') {
            steps {
                echo 'Verifying container is running...'
                sh "docker ps | grep ${CONTAINER_NAME}"
            }
        }
    }
    
    post {
        success {
            echo '✅ Pipeline succeeded! Application is running.'
            echo "Access your app at: http://localhost:${HOST_PORT}"
        }
        failure {
            echo '❌ Pipeline failed! Check the logs above.'
        }
    }
}
