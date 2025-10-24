pipeline {
    agent any
    
    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }
        
        stage('Build') {
            steps {
                sh 'dotnet restore'
                sh 'dotnet build --configuration Release'
            }
        }
        
        stage('Test') {
            steps {
                sh 'dotnet test'
            }
        }
        
        stage('Publish') {
            steps {
                sh 'dotnet publish -c Release -o ./publish'
            }
        }
    }
    
    post {
        success {
            echo 'Pipeline succeeded!'
        }
        failure {
            echo 'Pipeline failed!'
        }
    }
}
