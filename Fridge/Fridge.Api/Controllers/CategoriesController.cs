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
    using Common;
    using ViewModels;
    using AutoMapper.QueryableExtensions;

    [Authorize(Roles = GlobalConstants.AdminRole)]
    public class CategoriesController : BaseApiController
    {
        private const string ModelName = "job title";

        // GET: api/Categories
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(CategoriesViewModel))]
        public IQueryable<CategoriesViewModel> GetCategories()
        {
            return this.Data.Categories.All().ProjectTo<CategoriesViewModel>();
        }

        // GET: api/Categories/5
        [AllowAnonymous]
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
        public IHttpActionResult Edit(int id, Category category)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != category.Id)
            {
                return this.BadRequest();
            }

            this.Data.Categories.Update(category);

            try
            {
                this.Data.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.CategoryExists(id))
                {
                    return this.NotFound();
                }
                else
                {
                    throw;
                }
            }

            return this.StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Categories
        [HttpPost]
        [ResponseType(typeof(Category))]
        public IHttpActionResult PostCategory(Category category)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.Data.Categories.Add(category);
            this.Data.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = category.Id }, category);
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

            return this.Ok(category);
        }

        private bool CategoryExists(int id)
        {
            return this.Data.Categories.All().Count(e => e.Id == id) > 0;
        }
    }
}