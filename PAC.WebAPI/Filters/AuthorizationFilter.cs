﻿using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;

namespace PAC.WebAPI.Filters
{
    public class AuthenticationFilter : Attribute, IAuthorizationFilter
    {
        public virtual void OnAuthorization(AuthorizationFilterContext context)
        {
            var authorizationHeader = context.HttpContext.Request.Headers["filter"].ToString();
            if (authorizationHeader != "admin") {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}

