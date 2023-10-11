/*using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ej_filters.auth;

namespace filtro
{
    public class ExampleAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        private Auth auth;
        private readonly string msg;
        public ExampleAuthorizationFilter(string message)
        {
            msg = message;
            auth = new Auth();
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string token = context.HttpContext.Request.Headers["auth"];
            if (token == null)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = msg + "no esta logueado."
                };
                return;
            }
            
        }
    }
}*/
//No pude instalar el NuGet entonces el filtro no funca pero seria esta basicamente