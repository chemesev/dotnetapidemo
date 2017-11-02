using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace apiserver.Models
{
   public class TodoTask 
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public string description  { get; set; } 
        public bool done  { get; set; }
    }
}