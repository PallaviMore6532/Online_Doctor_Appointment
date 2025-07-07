using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.CustFilters
{
    public class UserAuth:ActionFilterAttribute,IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.GetString("UserID") == null)
                context.Result = new RedirectToRouteResult(new { Controller = "ManageUsers",Action= "SignIn", area="" });
        }
    }
}
