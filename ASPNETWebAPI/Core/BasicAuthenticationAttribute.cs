using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using ASPNETWebAPI.Services;
using System.Threading;
using System.Security.Principal;

namespace ASPNETWebAPI.Core
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string authenToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodeAuthenToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenToken));
                string[] splitAuthToken = decodeAuthenToken.Split(':');
                string username = splitAuthToken[0];
                string password = splitAuthToken[1];

                if (EmployeeSecurity.Login(username, password))
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                else
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }
    }
}