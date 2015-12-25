namespace Fridge.Api.Controllers
{
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Fridge.Models;
    using BindingModels;
    using ViewModels.Home;
    using AutoMapper.QueryableExtensions;
    using System.Collections.Generic;
    using System;
    using ViewModels.Recipe;
    [RoutePrefix("api/Recipes")]
    public class RecipesController : BaseApiController
    {
        private const string ModelName = "recipe";

        // GET: api/Recipes
        [HttpGet]
        [ResponseType(typeof(RecepiesViewModel))]
        public IHttpActionResult GetRecipes([FromUri]PageableBindingModel pagingModel)
        {
            IQueryable<RecepiesViewModel> model = this.Data.Recipes.All().ProjectTo<RecepiesViewModel>();
            return this.OKWithPagingAndSorting(pagingModel, model);
        }

        // GET: api/Recipes
        [HttpGet]
        [ResponseType(typeof(RecepiesViewModel))]
        [Route("Random")]
        public IHttpActionResult RandomRecipes(int count)
        {
            int from = this.Data.Recipes.All().Min(x => x.Id);
            int to = this.Data.Recipes.All().Max(x => x.Id) + 1;
            int countAll = this.Data.Recipes.All().Count();
            IQueryable<RecepiesViewModel> model = null;

            if (countAll <= count)
            {
                model = this.Data.Recipes.All().ProjectTo<RecepiesViewModel>();
                return this.Ok(model);
            }

            HashSet<int> ids = new HashSet<int>();
            Random rand = new Random();

            for (int i = 0; i < count; i++)
            {
                int randNum = rand.Next(from, to);
                bool isExist = this.Data.Recipes.All().Where(x => x.Id == randNum).Any();
                if (isExist && !ids.Contains(randNum))
                {
                    ids.Add(randNum);
                }
                else
                {
                    i--;
                }
            }

            model = this.Data.Recipes.All().Where(x => ids.Contains(x.Id)).ProjectTo<RecepiesViewModel>();
            return this.Ok(model);
        }

        // GET: api/Recipes/name
        [HttpGet]
        [ResponseType(typeof(RecipeViewModel))]
        public IHttpActionResult GetRecipesByName(string recipeName)
        {
            string name = recipeName.Replace("-", " ");
            RecipeViewModel model = this.Data.Recipes.All()
                .Where(x => x.Name == name)
                .ProjectTo<RecipeViewModel>()
                .FirstOrDefault();

            this.CheckModelForNull(model, ModelName);

            return this.Ok(model);
        }

        // GET: api/Recipes/5
        [ResponseType(typeof(Recipe))]
        public IHttpActionResult GetRecipe(int id)
        {
            Recipe recipe = this.Data.Recipes.GetById(id);
            if (recipe == null)
            {
                return this.NotFound();
            }

            return this.Ok(recipe);
        }

        // PUT: api/Recipes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRecipe(int id, Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recipe.Id)
            {
                return this.BadRequest();
            }

            this.Data.Recipes.Update(recipe);

            try
            {
                this.Data.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return this.StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Recipes
        [ResponseType(typeof(Recipe))]
        public IHttpActionResult PostRecipe(Recipe recipe)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            this.Data.Recipes.Add(recipe);
            this.Data.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = recipe.Id }, recipe);
        }

        // DELETE: api/Recipes/5
        [ResponseType(typeof(Recipe))]
        public IHttpActionResult DeleteRecipe(int id)
        {
            Recipe recipe = this.Data.Recipes.GetById(id);
            if (recipe == null)
            {
                return this.NotFound();
            }

            this.Data.Recipes.Delete(recipe);
            this.Data.SaveChanges();

            return this.Ok(recipe);
        }


        private bool RecipeExists(int id)
        {
            return this.Data.Recipes.All().Count(e => e.Id == id) > 0;
        }
    }
}