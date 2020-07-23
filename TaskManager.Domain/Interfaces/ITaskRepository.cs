using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Models;

namespace TaskManager.Repositories
{
    public interface ITaskRepository
    {
        TaskModel GetById(int taskId);
        IQueryable<TaskModel> GetAllActive();
        Task Add(TaskModel taskModel);
        Task Update(int taskId, TaskModel taskModel);
        Task Delete(int taskId);
    }
}
