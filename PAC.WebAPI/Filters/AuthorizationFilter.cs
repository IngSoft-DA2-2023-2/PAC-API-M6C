using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PAC.WebAPI.Filters
{
    public class AuthenticationFilter : Attribute, IAuthorizationFilter
    {
        public virtual async void OnAuthorization(AuthorizationFilterContext context)
        {
            var authorizationHeader = context.HttpContext.Request.Headers["admin"].ToString();
            if (authorizationHeader == null)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "No authorized"
                };
                return;
            }

            context.Result = new ContentResult()
            {
                StatusCode = 200,
                Content = "Auth"
            };
            return;
        }

    }
}

