using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using apiserver.Models;


namespace apiserver.Controllers
{
    [Route("api/[controller]")]
    public class TasksController : Controller
    {    
        private readonly TasksDbContext _context;

        public TasksController(TasksDbContext context)
        {
            _context = context;
        }        
        // GET api/tasks
        [HttpGet]
        public IEnumerable<TodoTask> Get ()
        {
                return _context.TasksTable.ToList();
        }
        // GET api/tasks/5
        [HttpGet("{id}", Name = "GetById")]
        public IActionResult Get(int id)
        {
            var item = _context.TasksTable.FirstOrDefault(x => x.id == id);
                if (item == null)
                {
                    return NotFound();
                }
                return new ObjectResult(item);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]TodoTask item)
        {
            
            if (item == null)
                {
                    return BadRequest();
                }

                _context.TasksTable.Add(item);
                _context.SaveChanges();
                return CreatedAtRoute("GetById", new { id = item.id }, item);
        }
        

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]TodoTask item)
        {
            if (item == null | id == 0)
            //item.id != id
            {
                return BadRequest();
            }

            var newitem = _context.TasksTable.Find(id);
            if (newitem == null)
            {
                return NotFound();
            }

            newitem.title = item.title;
            newitem.description = item.description;
            newitem.done = item.done;
            _context.TasksTable.Update(newitem);
            _context.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
                if (_context.TasksTable.Where(t => t.id == id).Count() > 0) // Check if element exists
                    _context.TasksTable.Remove(_context.TasksTable.First(t => t.id == id));
                else
                {
                    return NotFound();
                }
                _context.SaveChanges();
                return new NoContentResult();
        }
    }
}
