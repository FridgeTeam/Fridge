using Fridge.Data;
using Fridge.Data.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Fridge.Api.UserSessionManager
{
    public class SessionAuthorizeAttribute : AuthorizeAttribute
    {
        protected IFridgeData Data { get; private set; }

        public SessionAuthorizeAttribute(IFridgeData data)
        {
            this.Data = data;
        }

        public SessionAuthorizeAttribute() : this(new FridgeData(new FridgeDbContext()))
        {
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (SkipAuthorization(actionContext))
            {
                return;
            }

            var userSessionManager = new UserSessionManager(new FridgeData(new FridgeDbContext()));
            if (userSessionManager.ValidateUserSession())
            {
                base.OnAuthorization(actionContext);
            }
            else
            {
                actionContext.Response = actionContext.ControllerContext.Request.CreateErrorResponse(
                    HttpStatusCode.Unauthorized, "Access token expried or not valid.");
            }
        }

        private static bool SkipAuthorization(HttpActionContext actionContext)
        {
            return actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any()
                   || actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
        }
    }
}