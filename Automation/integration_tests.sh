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

RESPONSE=$(curl -L --write-out "%{http_code}\n" --silent --output /dev/null "dotnetapidemo:5000/api/tasks")
if [ $RESPONSE -eq 200 ]; then
  echo success
else
  echo "failed ($RESPONSE)"
  exit 1
fi
}
integration_test