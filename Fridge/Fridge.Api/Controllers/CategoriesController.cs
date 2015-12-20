namespace Fridge.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Fridge.Data;
    using Fridge.Models;

    public class CategoriesController : BaseApiController
    {
        private const string ModelName = "job title";

        // GET: api/Categories
        [HttpGet]
        public IQueryable<Category> GetCategories()
        {
            return this.Data.Categories.All();
        }

        // GET: api/Categories/5
        [HttpGet]
        [ResponseType(typeof(Category))]
        public IHttpActionResult GetCategory(int id)
        {
            Category category = this.Data.Categories.GetById(id);
            if (category == null)
            {
                return NotFound();
            }

            return this.Ok(category);
        }

        // PUT: api/Categories/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategory(int id, Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.Id)
            {
                return BadRequest();
            }

            this.Data.Categories.Update(category);

            try
            {
                this.Data.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Categories
        [HttpPost]
        [ResponseType(typeof(Category))]
        public IHttpActionResult PostCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this.Data.Categories.Add(category);
            this.Data.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = category.Id }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete]
        [ResponseType(typeof(Category))]
        public IHttpActionResult DeleteCategory(int id)
        {
            Category category = this.Data.Categories.GetById(id);
            if (category == null)
            {
                return NotFound();
            }

            this.Data.Categories.Delete(category);
            this.Data.SaveChanges();

            return Ok(category);
        }       

        private bool CategoryExists(int id)
        {
            return this.Data.Categories.All().Count(e => e.Id == id) > 0;
        }
    }
}