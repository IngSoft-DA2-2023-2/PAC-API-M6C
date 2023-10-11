using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PAC.WebAPI.Filters
{
    public class AuthenticationFilter : Attribute, IAuthorizationFilter
    {
        public virtual void OnAuthorization(AuthorizationFilterContext context)
        {
            var authorizationHeader = context.HttpContext.Request.Headers[""].ToString();
            
            if (string.IsNullOrEmpty(authorizationHeader))
            {
                context.Result = new ObjectResult(new { Message = "Authorization header is missing" })
                {
                    StatusCode = 401
                };
                
            } else if (!authorizationHeader.Equals("Admin"))
            {
                context.Result = new ObjectResult(new { Message = "Can't perform action" })
                {
                    StatusCode = 403
                };
            }
        }

    }
}

