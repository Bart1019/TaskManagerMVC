using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.Repositories;

namespace TaskManager.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository _repository;
        public TaskController(ITaskRepository repository)
        {
            _repository = repository;
        }
        // GET: Task
        public ActionResult Index()
        {
            return View(_repository.GetAllActive());
        }

        // GET: Task/Details/5
        public ActionResult Details(int id)
        {
            return View(_repository.GetById(id));
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            return View(new TaskModel());
        }

        // POST: Task/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TaskModel taskModel)
        {
            await _repository.Add(taskModel);

            return RedirectToAction(nameof(Index));
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_repository.GetById(id));
        }

        // POST: Task/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult>Edit(int id, TaskModel taskModel)
        {
            await _repository.Update(id, taskModel);
            
            return RedirectToAction(nameof(Index));
        }

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_repository.GetById(id));
        }

        // POST: Task/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, TaskModel taskModel)
        {
            await _repository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        // GET: Task/Done/5
        public async Task<ActionResult> Done(int id)
        {
            TaskModel task = _repository.GetById(id);
            task.IsDone = true;
            await _repository.Update(id, task);
            await _repository.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}