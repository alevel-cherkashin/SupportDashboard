using SupportDashboard.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SupportDashboard.BusinessLogic.Models;


namespace SupportDashboard.Controllers.Categories
{
    public class CategoriesController : Controller
    {
        private ISupportDashboard<Category> _categoryService = new CategoryService();

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var categories = await _categoryService.GetAll();
            return View(categories);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(Category task)
        {
            await _categoryService.Add(task);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Update(int id)
        {
            var task = await _categoryService.Get(id);
            return View(task);
        }

        [HttpPost]
        public async Task<ActionResult> Update(Category task)
        {
            await _categoryService.Update(task);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            await _categoryService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}