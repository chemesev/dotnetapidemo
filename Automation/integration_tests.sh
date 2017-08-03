#!/bin/bash
set -e
# define some colors to use for output
RED='\033[0;31m'
GREEN='\033[0;32m'
NC='\033[0m'
# kill and remove any running containers
cleanup () {
  docker ps -a -q |xargs docker rm -f
}
integration_test (){
  # curl	-H	'Content-Type:	application/json'	-X	PUT	-d	\
	#					"{\"_id\":	1,
	#					\"title\":	\"My	First	Book\",
	#					\"author\":	\"John	Doe\",
	#					\"description\":	\"Not	a	very	good	book\"}"	\
	#					http://localhost:5000/api/v1/books	\
	#					|	jq	'.'
	#	
	#curl	http://localhost:5000/api/v1/books	\
	#			|	jq	'.'
	#
	#curl	http://localhost:5000/api/v1/books/_id/1	\
	#				|	jq	'.'

  RESPONSE=$(curl -L --write-out "%{http_code}\n" --silent --output /dev/null "${DOCKER_MACHINE_NAME}:5000/api/tasks")
if [ $RESPONSE -eq 200 ]; then
  echo success
else
  echo "failed ($RESPONSE)"
  exit 1
fi
}
# catch unexpected failures, do cleanup and output an error message
trap 'cleanup ; printf "${RED}Tests Failed For Unexpected Reasons${NC}\n"'\
  HUP INT QUIT PIPE TERM
# build and run the composed services
echo "Running Docker container..."
docker run -d -p 5000:5000 --name $CIRCLE_PROJECT_REPONAME $CIRCLE_PROJECT_REPONAME 
integration_test
if [ $? -ne 0 ] ; then
  printf "${RED}Docker Compose Failed${NC}\n"
  exit -1
fi
# wait for the test service to complete and grab the exit code
TEST_EXIT_CODE=`docker wait ci_integration-tester_1`
# output the logs for the test (for clarity)
docker logs ci_integration-tester_1
# inspect the output of the test and display respective message
if [ -z ${TEST_EXIT_CODE+x} ] || [ "$TEST_EXIT_CODE" -ne 0 ] ; then
  printf "${RED}Tests Failed${NC} - Exit Code: $TEST_EXIT_CODE\n"
else
  printf "${GREEN}Tests Passed${NC}\n"
fi
# call the cleanup fuction
cleanup
# exit the script with the same code as the test service code
exit $TEST_EXIT_CODE