using System;
using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PAC.WebAPI.Filters
{
    public class AuthenticationFilter : Attribute, IAuthorizationFilter
    {
        public virtual void OnAuthorization(AuthorizationFilterContext context)
        {
            var authorizationHeader = context.HttpContext.Request.Headers["rol"].ToString();
            if (authorizationHeader is null)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Not authorized"
                };
                return;
            }
            bool isAdmin = authorizationHeader.Equals("admin");
            if (!isAdmin)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 403,
                    Content = "Not authorized, invalid rol"
                };
                return;
            }
        }

    }
}

