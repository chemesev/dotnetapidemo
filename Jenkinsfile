pipeline {
  agent {
    docker {
      image 'microsoft/dotnet'
      args '1.1.2-sdk-jessie'
    }
    
  }
  stages {
    stage('prep') {
      steps {
        echo 'Prep Step'
      }
    }
  }
}