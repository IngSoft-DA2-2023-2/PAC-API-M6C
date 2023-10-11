using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PAC.WebAPI.Filters
{
    public class AuthenticationFilter : Attribute, IAuthorizationFilter
    {
        private string[] _allowedRoles;

        public AuthenticationFilter(params string[] values)
        {
            _allowedRoles = values;
        }
        public virtual void OnAuthorization(AuthorizationFilterContext context)
        {
            var authorizationHeader = context.HttpContext.Request.Headers[""].ToString();
            if (_allowedRoles is not null && _allowedRoles.Count() > 0)
            {
                if (!_allowedRoles.Contains(authorizationHeader))
                {
                    context.Result = new ContentResult()
                    {
                        StatusCode = 401,
                        Content = "Unauthorized",
                    };
                }
            }
        }

    }
}

