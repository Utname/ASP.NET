using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Entity;

namespace ARB_ASPNET.App_Start
{
    public static class SessionConfig
    {
        public static void SetUser(Account user)
        {
            //lưu vào session
            HttpContext.Current.Session["user"] = user;
        }

        public static Account GetUser()
        {
            return (Account)HttpContext.Current.Session["user"];
        }
    }
}