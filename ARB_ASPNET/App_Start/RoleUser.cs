using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Data;
using Data.Entity;

namespace ARB_ASPNET.App_Start
{
    public class RoleUser: AuthorizeAttribute
    {
        public string MaChucNang { get; set; }
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
            if(string.IsNullOrEmpty(MaChucNang) == false)
            {
                if(user.Username == "Admin")
                {
                    return;
                }
                var check = new mapPhanQuyen().KiemTra(user.Id, MaChucNang);
                if(check == false)
                {
                    filterContext.Result = new RedirectToRouteResult(

                    new RouteValueDictionary(new
                    {
                        controller = "Dashboard",
                        action = "LoiPhanQuyen",
                        area = "Admin"
                    }));
                    return;
                }
            }

            return;
        }
    }
}