using BLL.DTOs;
using BLL.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieDatabase.Controllers
{
    [RoutePrefix("api/favorite")]
    public class UserFavoriteController : ApiController
    {
        [HttpGet]
        [Route("{userId}")]
        public HttpResponseMessage GetUserFavorites(int userId)
        {
            try
            {
                var favorites = UserFavoriteService.GetUserFavorites(userId);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "User favorites retrieved successfully.", favorites });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = $"Failed to retrieve user favorites: {ex.Message}" });
            }
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage AddToFavorites(UserFavoriteDTO favoriteDto)
        {
            try
            {
                var success = UserFavoriteService.AddToFavorites(favoriteDto);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Movie added to favorites successfully.", success });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = $"Failed to add movie to favorites: {ex.Message}" });
            }
        }

        [HttpPost]
        [Route("remove/{userId}/{movieId}")]
        public HttpResponseMessage RemoveFromUserFavorites(int userId, int movieId)
        {
            try
            {
                var success = UserFavoriteService.RemoveFromFavorites(userId, movieId);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Movie removed from favorites successfully.", success });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = $"Failed to remove movie from favorites: {ex.Message}" });
            }
        }
    }
}
