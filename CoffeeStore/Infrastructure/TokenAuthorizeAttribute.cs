using CoffeeStore.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Net.Http;


namespace CoffeeStore.Infrastructure
{
    public class TokenAuthorizeAttribute : AuthorizeAttribute
    {

        private const string _securityToken = "token";

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            try
            {
                //Get Token from query string
                //var queryString = actionContext.Request.GetQueryNameValuePairs().ToDictionary(x => x.Key, x => x.Value);
                //string token = queryString[_securityToken];

                //Get token from header
                string token;
                var headers = actionContext.Request.Headers;
                if (headers.Contains("token"))
                {
                    token = headers.GetValues("token").First();
                }
                else {
                    token = null;
                }

                return TokenManager.IsTokenValid(token);
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}