namespace Fridge.Api.Controllers
{
    using Fridge.Api.BindingModels;
    using ViewModels;
    using Fridge.Common;
    using Fridge.Data;
    using Fridge.Data.Data;
    using Microsoft.AspNet.Identity;
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Collections.Generic;

    public class BaseApiController : ApiController
    {
        public BaseApiController(IFridgeData data)
        {
            this.Data = data;
        }

        public BaseApiController()
        {
            this.Data = new FridgeData(new FridgeDbContext());
        }

        protected IFridgeData Data { get; private set; }

        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return this.InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        this.ModelState.AddModelError(string.Empty, error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return this.BadRequest();
                }

                return this.BadRequest(this.ModelState);
            }

            return null;
        }

        /// <summary>
        /// Checks object for null reference
        /// </summary>
        /// <param name="obj">Object to check</param>
        /// <param name="objName">Name of the object, goes in exception message</param>
        /// <param name="objId">Id of the object, goes in exception message</param>
        /// <exception cref="HttpResponseException">Thrown when obj is null</exception>
        protected void CheckObjectForNull(object obj, string objName, object objId = null)
        {
            if (obj == null)
            {
                string errorMessage = string.Empty;

                if (objId != null)
                {
                    errorMessage = string.Format("There is no {0} with id {1}", objName, objId);
                }
                else
                {
                    errorMessage = string.Format("There is no such {0}", objName);
                }

                var jsonObj = JsonConvert.SerializeObject(new { Message = errorMessage });

                throw new HttpResponseException(new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Content = new StringContent(jsonObj)
                });
            }
        }

        /// <summary>
        /// Check input model for null
        /// <exception cref="HttpResponseException">Returns BadRequest 400</exception>
        /// </summary>
        protected void CheckModelForNull(object model, string modelName)
        {
            if (model == null)
            {
                string errorMessage = string.Format("Invalid model, the {0} is null.", modelName);

                var jsonObj = JsonConvert.SerializeObject(new { Message = errorMessage });

                throw new HttpResponseException(new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Content = new StringContent(jsonObj)
                });
            }
        }

        protected IHttpActionResult OKWithPagingAndSorting<T>(IPageableBindingModel model, IQueryable<T> sourceObject)
        {
            try
            {
                if (model.OrderBy == null)
                {
                    try
                    {
                        sourceObject = sourceObject.OrderByDescending("Id");
                    }
                    catch (Exception)
                    {
                        try
                        {
                            sourceObject = sourceObject.OrderByDescending("PhoneId");
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                }
                else
                {
                    string[] orderParameter = model.OrderBy.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);

                    if (string.Equals(orderParameter[1], "asc", StringComparison.CurrentCultureIgnoreCase))
                    {
                        sourceObject = sourceObject.OrderBy(orderParameter[0]);
                    }
                    else if (string.Equals(orderParameter[1], "desc", StringComparison.CurrentCultureIgnoreCase))
                    {
                        sourceObject = sourceObject.OrderByDescending(orderParameter[0]);
                    }
                    else
                    {
                        return this.Content(HttpStatusCode.BadRequest, new { Message = "Bad order." });
                    }
                }
            }
            catch (Exception)
            {

                return this.Content(HttpStatusCode.BadRequest, new { Message = "Invalid sorting." });
            }

            // Apply paging: find the requested page (by given start page and page size)
            int pageSize = 20;
            if (model.PageSize.HasValue)
            {
                pageSize = model.PageSize.Value;
            }
            var numItems = sourceObject.Count();
            var numPages = (numItems + pageSize - 1) / pageSize;
            if (model.StartPage.HasValue)
            {
                sourceObject = sourceObject.Skip(pageSize * (model.StartPage.Value - 1));
            }

            var objToReturn = sourceObject.Take(pageSize).ToList();

            PageableViewModel<List<T>> obj = new PageableViewModel<List<T>>()
            {
                NumItems = numItems,
                NumPages = numPages,
                Result = objToReturn
            };

            return this.Ok(obj);
        }

        public IHttpActionResult BadMessageRequest(string message)
        {
            return this.Content(HttpStatusCode.BadRequest, new { Message = message });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Data.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}