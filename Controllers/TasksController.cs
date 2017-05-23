using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace apiserver.Controllers
{
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        // GET api/tasks
        [HttpGet]
        public IEnumerable<Task> Get()
        {
            var task1 = new Task 
            {
                id = 1,
                title = "Buy groceries",
                description = "Milk, Cheese, Pizza, Fruit, Tylenol",
                done = false
            };
            var task2 = new Task
            {
                id = 2,
                title = "Learn Python",
                description = "Need to find a good Python tutorial on the web",
                done = false
            };
            //var taskslist = new List<Task>{task1, task2};
            //JsonResult result = new JsonResult(taskslist);
            var result = new Task[]{task1, task2};
            return result;
        }

        // GET api/tasks/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "task description";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
