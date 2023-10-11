using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PAC.WebAPI.Filters
{
    public class AuthenticationFilter : Attribute, IAuthorizationFilter
    {
        private readonly string role;

        public AuthenticationFilter(string role)
        {
            this.role = role;
        }
        public virtual void OnAuthorization(AuthorizationFilterContext context)
        {
            var authorizationHeader = context.HttpContext.Request.Headers[""].ToString();
            if (authorizationHeader == null)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Credenciales invalidas.",
                };
                return;
            }
            if (!authorizationHeader.Equals("Admin")) 
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "No posee privilegios necesarios para esta accion.",
                };
                return;
            }
        }

    }
}

