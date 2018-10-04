using SupportDashboard.BusinessLogic.Models;
using SupportDashboard.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SupportTask = SupportDashboard.BusinessLogic.Models.Task;

namespace SupportDashboard.Controllers.Tasks
{
    public class TasksController : Controller
    {
        private ISupportDashboard<SupportTask> _taskService = new TaskService();
        private ISupportDashboard<Category> _categoryService = new CategoryService();

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            ViewBag.Category = await _categoryService.GetAll();
            var tasks = await _taskService.GetAll();
            return View(tasks);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(SupportTask task)
        {
            await _taskService.Add(task);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            var task = await _taskService.Get(id);
            return View(task);
        }

        [HttpPost]
        public async Task<ActionResult> Update(SupportTask task)
        {
            await _taskService.Update(task);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            await _taskService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}