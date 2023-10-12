using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PAC.WebAPI.Filters
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public virtual void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!UserIsAuthorizedToCreateStudent(context))
            {
                context.Result = new UnauthorizedObjectResult("No puedo autorizarme");
            }
        }

        private bool UserIsAuthorizedToCreateStudent(AuthorizationFilterContext context)
        {

            if (context.HttpContext.Request.Headers.TryGetValue("Authorization", out var authorizationHeaderValue))
            {
                var token = authorizationHeaderValue.ToString();

                if (token == "mi_token_secreto")
                {
                    return true;
                }
            }
            return false;
        }
    }
}

