using System;
using Microsoft.EntityFrameworkCore;

namespace apiserver.Models
{
    public class TasksDbContext : DbContext
    {
        // Reference our tomato table using this
        public DbSet<TodoTask> TasksTable { get; set; }  
        public TasksDbContext(DbContextOptions<TasksDbContext> options)
            : base(options)
        {
        }
    }
}