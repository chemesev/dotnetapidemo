#!/bin/bash
set -euxo pipefail
integration_test (){
	RESPONSE=$(curl -vL --write-out "%{http_code}\n" --silent --output /dev/null "http://dotnetapidemo:5000/api/tasks")
if [ $RESPONSE -eq 200 ]; then
  echo success
else
  echo "failed ($RESPONSE)"
  exit 1
fi

RESPONSE=$(curl -vL \
			      -H	'Content-Type:	application/json'	-X	POST	-d	\
						"{\"title\":	\"My	First	Task\",
						\"description\":	\"Do Something\",
						\"done\":	\"false\"}"	\
						--write-out "%{http_code}\n" --silent --output /dev/null "http://dotnetapidemo:5000/api/tasks")
if [ $RESPONSE -eq 201 ]; then
  echo success
else
  echo "failed ($RESPONSE)"
  exit 1
fi
}
sleep 60
integration_test