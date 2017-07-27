pipeline {
  agent {
    docker.withDockerServer([uri: 'unix:///var/run/docker.sock']) {
      image 'microsoft/dotnet:1.1.2-sdk-jessie'
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




