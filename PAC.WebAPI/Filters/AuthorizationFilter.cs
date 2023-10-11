using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PAC.WebAPI.Filters
{
    public class AuthenticationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            
            var userRole = context.HttpContext.Request.Headers["UserRole"].ToString();

            if (string.IsNullOrEmpty(userRole) || userRole != "admin")
            {
                context.Result = new ForbidResult();
            }
        }

    }
}

