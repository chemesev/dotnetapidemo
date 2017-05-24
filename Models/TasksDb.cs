using System;
using Microsoft.EntityFrameworkCore;

namespace apiserver
{
    public class TasksDb : DbContext
    {
        // Reference our tomato table using this
        public DbSet<Task> TasksTable { get; set; }  
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./Tasks.db");
            
        }
    }
}