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

    public class RecipesController : BaseApiController
    {
        // GET: api/Recipes
        [HttpGet]
        [ResponseType(typeof(RecepieViewModel))]
        public IHttpActionResult GetRecipes([FromUri]PageableBindingModel pagingModel)
        {
            IQueryable<RecepieViewModel> model = this.Data.Recipes.All().ProjectTo<RecepieViewModel>();
            return this.OKWithPagingAndSorting(pagingModel, model);
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