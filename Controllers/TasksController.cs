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
         
            using (TasksDb db = new TasksDb())
            {
                return db.TasksTable.ToList();
            }
        }
        // GET api/tasks/5
        [HttpGet("{id}", Name = "GetById")]
        public IActionResult Get(int id)
        {
           using (TasksDb db = new TasksDb())
            {
                var item = db.TasksTable.FirstOrDefault(x => x.id == id);
                if (item == null)
                {
                    return NotFound();
                }
                return new ObjectResult(item);
            }
            
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Task item)
        {
         
            
            if (item == null)
                {
                    return BadRequest();
                }
            using (TasksDb db = new TasksDb())
            {
                db.TasksTable.Add(item);
                db.SaveChanges();
                return CreatedAtRoute("GetById", new { id = item.id }, item);
            }
        }
        

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Task item)
        {
                if (item == null || item.id != id )
                {
                    return BadRequest();
                }
            using (TasksDb db = new TasksDb())
            {
                var row = db.TasksTable.FirstOrDefault(x => x.id == id);
                if (row == null)
                {
                    return NotFound();
                }  
                var result = db.TasksTable.Find(id); 
                result.title = item.title;
                result.description =item.description;
                result.done = item.done;
                db.TasksTable.Update(result);
                db.SaveChanges();
                //return CreatedAtRoute("GetById", new { id = item.id }, item);
                return new NoContentResult();
            }


        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
