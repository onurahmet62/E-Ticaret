using MvcGroupApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcGroupApp.Helper
{
    public class AuthorizeUserControl : ActionFilterAttribute
    {
        //private byte[] RoleID;
        //public AuthorizeUserControl(byte[] roleID)
        //{
        //    this.RoleID = roleID;
        //}

        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    //Eğer giriş sağlanmışsa
        //    if (HttpContext.Current.User.Identity.IsAuthenticated)
        //    {   //Kullanıcının RoleId bilgisi db'den çekilir
        //        if (!RoleID.Contains((byte)AccountControl.GetRoleID()))
        //        {
        //            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "action", "UnAuthorize" }, { "controller", "Error" } });
        //        }
        //    }
        //}
    }
}