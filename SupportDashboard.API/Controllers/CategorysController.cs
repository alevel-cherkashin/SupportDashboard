using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SupportDashboard.BusinessLogic.Service;
using SupportDashboard.BusinessLogic.Models;


namespace SupportDashboard.API.Controllers
{
    [RoutePrefix("api/categores")]
    public class CategorysController : ApiController
    {

        private AppService<Category> _supportCategory = new SupportCategoryService();

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var categorys = _supportCategory.GetAll();

            return Ok(categorys);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var category = _supportCategory.Get(id);

            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _supportCategory.Delete(id);

            return Ok();
        }

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Add([FromBody] Category category)
        {
            _supportCategory.Add(category);

            return Ok();
        }

        [HttpPost]
        [Route("Update")]
        public IHttpActionResult Update([FromBody] Category category)
        {
            _supportCategory.Update(category);

            return Ok();
        }

    }
}
