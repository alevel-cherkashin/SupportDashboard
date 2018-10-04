﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SupportDashboard.BusinessLogic.Service;
using SupportDashboard.BusinessLogic.Models;

namespace SupportDashboard.API.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoriesController : ApiController
    {

        private AppService<Category> _supportCategory = new SupportCategoryService();

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var categories = _supportCategory.GetAll();

            return Ok(categories);
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
        [Route("create")]
        public IHttpActionResult Add([FromBody] Category category)
        {
            _supportCategory.Add(category);

            return Ok();
        }

        [HttpPut]
        [Route("update")]
        public IHttpActionResult Update([FromBody] Category category)
        {
            _supportCategory.Update(category);

            return Ok();
        }

    }
}
