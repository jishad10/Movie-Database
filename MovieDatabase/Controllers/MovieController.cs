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
    [RoutePrefix("api/movie")]
    public class MovieController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = MovieService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Movies retrieved successfully.", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = $"Failed to retrieve movies: {ex.Message}" });
            }
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = MovieService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Movie retrieved successfully.", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = $"Failed to retrieve movie: {ex.Message}" });
            }
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(MovieDTO obj)
        {
            try
            {
                var data = MovieService.Create(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Movie created successfully.", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = $"Failed to create movie: {ex.Message}" });
            }
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(MovieDTO obj)
        {
            try
            {
                var data = MovieService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Movie updated successfully.", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = $"Failed to update movie: {ex.Message}" });
            }
        }

        [HttpGet]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = MovieService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Movie deleted successfully.", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = $"Failed to delete movie: {ex.Message}" });
            }
        }

        [HttpGet]
        [Route("search/{title}")]
        public HttpResponseMessage Search(string title)
        {
            try
            {
                var data = MovieService.SearchByTitle(title);
                if (data == null || !data.Any()) 
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { message = "No movies found with the given title." });
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Movies found successfully.", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = $"Failed to search movies: {ex.Message}" });
            }
        }
    }
}
