using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.CustFilters
{
    public class AdminAuth:ActionFilterAttribute,IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.GetString("AdminID") == null)
                context.Result = new RedirectToRouteResult(new { Controller = "ManageAdmin",Action= "SignIn", area="" });
        }
    }
}
