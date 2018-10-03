using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SupportDashboard.BusinessLogic.Models;
using SupportDashboard.BusinessLogic.Service;

namespace SupportDashboard.API.Controllers
{
    [RoutePrefix("api/tasks")]
    public class TasksController : ApiController
    {
        private AppService<Task> _supportTask = new SupportTaskService();

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var tasks = _supportTask.GetAll();

            return Ok(tasks);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var task = _supportTask.Get(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _supportTask.Delete(id);

            return Ok();
        }

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Add([FromBody]Task task)
        {
            _supportTask.Add(task);

            return Ok();
        }

        [HttpPost]
        [Route("Update")]
        public IHttpActionResult Update([FromBody] Task task)
        {
            _supportTask.Update(task);

            return Ok();
        }
    }
}
