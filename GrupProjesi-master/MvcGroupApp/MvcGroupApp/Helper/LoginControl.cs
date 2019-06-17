using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcGroupApp.Helper
{
    /// <summary>
    /// Kullanıcının doğrulanıp doğrulanmaması durumuna göre kullanıcı login sayfasına yönlendiriliyor.
    /// </summary>
    public class LoginControl : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (!HttpContext.Current.Response.IsRequestBeingRedirected)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "action", "Login" }, { "controller", "Account" } });
                }
            }
        }
    }
}