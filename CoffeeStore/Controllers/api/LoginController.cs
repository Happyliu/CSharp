using CoffeeStore.Login;
using CoffeeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CoffeeStore.Controllers.api
{

    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {

        [HttpPost]
        public string PostLogin(LoginDTO loginDTO)
        {
            return TokenManager.GenerateToken(loginDTO.Username, loginDTO.Password, "2323", "chrome", DateTime.UtcNow.Ticks);
        }

        [HttpGet]
        public bool GetLogin([FromUri]string token)
        {
            return TokenManager.IsTokenValid(token);
        }

        [HttpGet]
        public bool GetLogin()
        {
            var headers = Request.Headers;
            string token;
            if (headers.Contains("token"))
            {
                token = headers.GetValues("token").First();
            }
            else
            {
                token = null;
            }
            return TokenManager.IsTokenValid(token);
        }

    }
}
