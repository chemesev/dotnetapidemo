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
    stage('Container'){
      steps {
        docker.withRegistry("${registry_url}", "${docker_creds_id}") {
          
          // Set up the container to build
          maintainer_name = "jayjohnson"
          container_name = "django-nginx"
      

          echo "Building nginx with docker.build(${maintainer_name}/${container_name}:${build_tag})"
          container = docker.build("${maintainer_name}/${container_name}:${build_tag}", 'nginx')
        
          // add more tests
          
          stage "Pushing"
          container.push()
          
          //currentBuild.result = 'SUCCESS'
        }
      }
    }
  }
}