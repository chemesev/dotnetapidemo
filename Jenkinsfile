pipeline {
  agent {
    docker {
      image 'microsoft/dotnet:1.1.2-sdk-jessie'
    }
    
  }
  stages {
    stage('prep') {
      steps {
        echo 'Prep Step'
      }
    }
    stage('Build') {
      steps {
        sh '''dotnet --version
dotnet restore
dotnet build
dotnet publish'''
      }
    }
  }
}