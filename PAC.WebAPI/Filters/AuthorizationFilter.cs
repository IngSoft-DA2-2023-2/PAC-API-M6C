using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PAC.WebAPI.Filters
{
    public class AuthenticationFilter : Attribute, IAuthorizationFilter
    {
        public virtual void OnAuthorization(AuthorizationFilterContext context)
        {
/*
            this._sessionService = context.HttpContext.RequestServices.GetService<ISessionService>();
            context.HttpContext.Request.Headers.TryGetValue("token", out var stringToken);
            try
            {
                token = Guid.Parse(stringToken);
                bool tokenIsValid = _sessionService.IsLoggedIn(token);
                if (!tokenIsValid)
                {
                    context.Result = new UnauthorizedResult();
                }

            }
            catch (Exception ex)
            {
                context.Result = new UnauthorizedResult();
            }*/
            var authorizationHeader = context.HttpContext.Request.Headers["filter"].ToString();
            if (authorizationHeader != "admin") {
                context.Result = new UnauthorizedResult();
            }
        }

    }
}

