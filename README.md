# Demo API server in .net Core with JS frontend
| API           | Description | Request body | Response body |
| ------------- |:-------------:| -----:|------:|
| GET /api/tasks	       | Get all to-do items	    | None	        | Array of to-do items |
| GET /api/tasks/{id}	   | Get an item by ID	    | None	        | To-do item |
| POST /api/tasks	       | Add a new item	        | To-do item	    | To-do item |
| PUT /api/tasks/{id}	   | Update an existing item | To-do item	    | None |
| DELETE /api/tasks/{id} | Delete an item    	    | None	        | None |


#### Install dotnet
#### Prepare DB
`dotnet ef database update`
#### install dependencies
`dotnet restore`
#### run server on 5000 port
`dotnet run`
#### Just open http://localhost:5000
**API Endpoint described in _self.tasksURI_ variable**
