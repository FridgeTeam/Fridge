using Fridge.Data;
using Fridge.Data.Data;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System.Net.Http;
using System.Web.Http;

namespace Fridge.Api.Controllers
{
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
    }
}