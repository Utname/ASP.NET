using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ARB_ASPNET.App_Start
{
    public class RoleUser: AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var user = SessionConfig.GetUser();
            if(user == null)
            {
                filterContext.Result = new RedirectToRouteResult(

                    new RouteValueDictionary(new
                    {
                        controller = "User",
                        action = "Login",
                        area = "Admin"
                    }));
                return;
            }
            return;
        }
    }
}