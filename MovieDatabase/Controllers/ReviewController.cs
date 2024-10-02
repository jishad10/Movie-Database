using BLL.DTOs;
using BLL.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieDatabase.Controllers
{
    [RoutePrefix("api/review")]
    public class ReviewController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = UserReviewService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Reviews retrieved successfully.", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = $"Failed to retrieve reviews: {ex.Message}" });
            }
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = UserReviewService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Review retrieved successfully.", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = $"Failed to retrieve review: {ex.Message}" });
            }
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(UserReviewDTO obj)
        {
            try
            {
                var data = UserReviewService.Create(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Review created successfully.", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = $"Failed to create review: {ex.Message}" });
            }
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(UserReviewDTO obj)
        {
            try
            {
                var data = UserReviewService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Review updated successfully.", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = $"Failed to update review: {ex.Message}" });
            }
        }

        [HttpGet]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = UserReviewService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Review deleted successfully.", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = $"Failed to delete review: {ex.Message}" });
            }
        }
    }
}
