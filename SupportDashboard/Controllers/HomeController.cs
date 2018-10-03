using SupportDashboard.Services;
using System.Collections.Generic;
using System.Web.Mvc;
using SupportTask = SupportDashboard.BusinessLogic.Models.Task;

namespace SupportDashboard.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TaskService taskService = new TaskService();
            var tasks = taskService.GetAll();
            return View(tasks);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}