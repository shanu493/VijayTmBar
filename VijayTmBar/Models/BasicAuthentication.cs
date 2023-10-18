using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace VijayTmBar.Models
{
    public class BasicAuthentication: AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                // string decode = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));

                // UesrSecurity us = new UesrSecurity(decode);
                UesrSecurity us = new UesrSecurity(authenticationToken);

                if (us.IsTokenValid())
                {
                    //Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(decode), null);
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(authenticationToken), null);

                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }




        }

    }
}