using CoffeeStore.Domain.Abstract;
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
        private ILoginRepository repository;

        public LoginController(ILoginRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public HttpResponseMessage PostLogin(LoginDTO loginDTO)
        {
            if (repository.IsValidUserName(loginDTO.Username))
            {
                if (repository.IsValidForLogin(loginDTO.Username, loginDTO.Password))
                {
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(TokenManager.GenerateToken(loginDTO.Username, loginDTO.Password, "2323", "chrome", DateTime.UtcNow.Ticks));
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/plain");
                    return response;
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Forbidden, new HttpError("Password is wrong!"));
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, new HttpError("Username is not exist in the system"));
            }
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
