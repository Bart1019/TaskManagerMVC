using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;

namespace TaskManager.Models
{
    public class TaskManagerContext : DbContext
    {
        public TaskManagerContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TaskModel> Tasks { get; set; }
    }
}
