using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace apiserver
{
   public class Task 
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public string description  { get; set; } 
        public bool done  { get; set; }
    }
}