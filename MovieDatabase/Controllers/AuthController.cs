using BLL.DTOs;
using BLL.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieDatabase.Controllers
{
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Login(LoginDTO login)
        {
            try
            {
                var token = AuthService.Authenticate(login.UserId, login.Password);
                if (token != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = "Login successful.", token });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, new { message = "Invalid credentials. Unauthorized access." });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = $"Login failed: {ex.Message}" });
            }
        }

        [HttpGet]
        [Route("api/logout")]
        public HttpResponseMessage Logout()
        {
            var key = Request.Headers.Authorization;
            if (key == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { message = "No token provided for logout." });

            try
            {
                var token = AuthService.LogoutToken(key.ToString());
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Logout successful.", token });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = $"Logout failed: {ex.Message}" });
            }
        }
    }
}
