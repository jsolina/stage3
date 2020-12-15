using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class TaskList
    {
        [Key]
        [Column("idTask")]
        public int idTask { get; set; }
        public string taskName { get; set; }
        public string taskDetails { get; set; }
    }
}
