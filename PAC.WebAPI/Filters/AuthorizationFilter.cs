using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PAC.WebAPI.Filters
{
    public class AuthenticationFilter : Attribute, IAuthorizationFilter
    {

        private long[] _allowedRoles;

        public virtual void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!IsAdminUser(context.HttpContext.User))
            {
                context.Result = new ForbidResult(); // Return a 403 Forbidden result for non-admin users
            }
        }

        private bool IsAdminUser(ClaimsPrincipal user)
        {
            return user.HasClaim(c => c.Type == "role" && c.Value == "admin");
        }

        public void AuthenticationRequired(params long[] values)
        {
            _allowedRoles = values;
        }
    }
}

