namespace Fridge.Api.Controllers
{
    using BindingModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using AutoMapper.QueryableExtensions;
    using ViewModels;

    [RoutePrefix("api/Comments")]
    public class CommentsController : BaseApiController
    {
        [HttpGet]
        public IHttpActionResult GetRecipeComments([FromUri] CommentsBindingModel pagingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            string recipeName = pagingModel.RecipeName.Replace("-", " ");

            IQueryable<CommentViewModel> result = this.Data.Comments.All()
                .Where(x => x.Recipe.Name == recipeName)
                .OrderByDescending(x => x.Id)
                .ProjectTo<CommentViewModel>();

            return this.OKWithPagingAndSorting(pagingModel, result);
        }
    }
}
