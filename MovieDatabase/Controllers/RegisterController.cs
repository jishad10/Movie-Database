using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieDatabase.Controllers
{
    [RoutePrefix("api/register")]
    public class RegisterController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = RegisterService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Users retrieved successfully.", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = $"Failed to retrieve users: {ex.Message}" });
            }
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = RegisterService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "User retrieved successfully.", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = $"Failed to retrieve user: {ex.Message}" });
            }
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(RegisterDTO obj)
        {
            try
            {
                var data = RegisterService.Create(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "User created successfully.", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = $"Registration failed: {ex.Message}" });
            }
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(RegisterDTO obj)
        {
            try
            {
                var data = RegisterService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "User updated successfully.", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = $"Failed to update user: {ex.Message}" });
            }
        }

        [HttpGet]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = RegisterService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "User deleted successfully.", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = $"Failed to delete user: {ex.Message}" });
            }
        }
    }
}
