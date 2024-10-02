using BLL.DTOs;
using BLL.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieDatabase.Controllers
{
    [RoutePrefix("api/genre")]
    public class GenreController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = GenreService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Genres retrieved successfully.", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = $"Failed to retrieve genres: {ex.Message}" });
            }
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = GenreService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Genre retrieved successfully.", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = $"Failed to retrieve genre: {ex.Message}" });
            }
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(GenreDTO obj)
        {
            try
            {
                var data = GenreService.Create(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Genre created successfully.", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = $"Failed to create genre: {ex.Message}" });
            }
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(GenreDTO obj)
        {
            try
            {
                var data = GenreService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Genre updated successfully.", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = $"Failed to update genre: {ex.Message}" });
            }
        }

        [HttpGet]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = GenreService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Genre deleted successfully.", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = $"Failed to delete genre: {ex.Message}" });
            }
        }
    }
}
