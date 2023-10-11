using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;

namespace PAC.WebAPI.Filters
{
    public class AuthenticationFilter : Attribute, IAuthorizationFilter
    {
        private readonly string _roleRequired;

        public AuthenticationFilter(string roleRequired)
        {
            _roleRequired = roleRequired;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var authorizationHeader = context.HttpContext.Request.Headers["Authorization"].ToString();

            var userRole = GetRoleFromToken(authorizationHeader);

            if (string.IsNullOrEmpty(userRole))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (userRole != _roleRequired)
            {
                context.Result = new ForbidResult();
            }
        }
        private string GetRoleFromToken(string token)
        {
            return token;
        }
    }
}


