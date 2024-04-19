using System;
using System.Web;
using System.Web.Mvc;

public class CacheAuthorizationAttribute : FilterAttribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationContext filterContext)
    {
        if (!IsUserAuthorized(filterContext.HttpContext))
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }

    private bool IsUserAuthorized(HttpContextBase context)
    {
        return context.Cache["IsUserAuthorized"] 
            != null && (bool)context.Cache["IsUserAuthorized"];
    }
}
