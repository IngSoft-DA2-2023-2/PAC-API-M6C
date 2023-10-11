using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PAC.WebAPI.Filters
{
    public class AuthenticationFilter : Attribute, IAuthorizationFilter
    {
        public virtual void OnAuthorization(AuthorizationFilterContext context)
        {
            var authorizationHeader = context.HttpContext.Request.Headers["auth"].ToString();
            if (authorizationHeader == null)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Auth token is null"
                };
                return;
            }
        }

    }
}

