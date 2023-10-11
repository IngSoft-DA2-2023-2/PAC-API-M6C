using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PAC.WebAPI.Filters
{
    public class AuthenticationFilter : Attribute, IAuthorizationFilter
    {
        public virtual void OnAuthorization(AuthorizationFilterContext context)
        {
            const string TOKEN_HEADER = "Authorization";
            const string EXPECTED_TOKEN_VALUE = "is admin";

            if (!context.HttpContext.Request.Headers.ContainsKey(TOKEN_HEADER))
            {
                context.Result = new UnauthorizedObjectResult("Authorization header is missing.");
                return;
            }

            var tokenValue = context.HttpContext.Request.Headers[TOKEN_HEADER].ToString();
            if (tokenValue != EXPECTED_TOKEN_VALUE)
            {
                context.Result = new ForbidResult("Invalid token value.");
            }
        }

    }
}

