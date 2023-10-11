using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PAC.WebAPI.Filters
{
    public class AuthenticationFilter : Attribute, IAuthorizationFilter
    {
        public virtual void OnAuthorization(AuthorizationFilterContext context)
        {
            // Se asume que en el header encontramos el rol del usuario que realizo request
            string header = context.HttpContext.Request.Headers["role"].ToString();
            bool isAdmin = header.Equals("admin");
            if (!isAdmin)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 403,
                    Content = "This action is exclusive to administrators"
                };
                return;
            }
        }

    }
}

