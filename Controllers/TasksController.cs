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
                var newitem = db.TasksTable.Find(id); 
                if (newitem == null)
                {
                    return NotFound();
                }  
                newitem.title = item.title;
                newitem.description =item.description;
                newitem.done = item.done;
                db.TasksTable.Update(newitem);
                db.SaveChanges();
                //return CreatedAtRoute("GetById", new { id = item.id }, item);
                return new NoContentResult();
            }


        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (TasksDb db = new TasksDb())
            {                 
                if (db.TasksTable.Where(t => t.id == id).Count() > 0) // Check if element exists
                    db.TasksTable.Remove(db.TasksTable.First(t => t.id == id));
                else
                {
                    return NotFound();
                }
                db.SaveChanges();
                return new NoContentResult();
            }
        }
    }
}
