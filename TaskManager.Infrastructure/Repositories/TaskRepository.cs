using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskManagerContext _context;
        public TaskRepository(TaskManagerContext context)
        {
            _context = context;
        }
        public TaskModel GetById(int taskId)
        {
            return _context.Tasks.SingleOrDefault(x => x.TaskId == taskId);
        }

        public IQueryable<TaskModel> GetAllActive()
        {
            return _context.Tasks.Where(x=>!x.IsDone);
        }

        public async Task Add(TaskModel taskModel)
        {
            await _context.AddAsync(taskModel);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int taskId, TaskModel taskModel)
        {
            var updatedTask = await _context.Tasks.SingleOrDefaultAsync(x => x.TaskId == taskId);
            if (updatedTask != null)
            {
                updatedTask.Name = taskModel.Name;
                updatedTask.Description = taskModel.Description;
                updatedTask.IsDone = taskModel.IsDone;
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int taskId)
        {
            var deletedTask = await _context.Tasks.SingleOrDefaultAsync(x => x.TaskId == taskId);
            if (deletedTask == null) return;
            _context.Remove(deletedTask);
            await _context.SaveChangesAsync();
        }
    }
}
