using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    [Table("Tasks")]
    public class TaskModel
    {
        [Key]
        public int TaskId { get; set; }
        [DisplayName("Task Name:")]
        [Required(ErrorMessage = "Task Name field is required.")]
        public string Name { get; set; }
        [DisplayName("Task Description:")]
        public string Description { get; set; }
        public bool IsDone { get; set; }

    }
}
