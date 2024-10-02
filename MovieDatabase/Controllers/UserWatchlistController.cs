using BLL.DTOs;
using BLL.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieDatabase.Controllers
{
    [RoutePrefix("api/watchlist")]
    public class UserWatchlistController : ApiController
    {
        [HttpGet]
        [Route("{userId}")]
        public HttpResponseMessage GetWatchlistByUser(int userId)
        {
            try
            {
                var data = UserWatchlistService.GetWatchlistByUser(userId);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Watchlist retrieved successfully.", data });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = $"Failed to retrieve watchlist: {ex.Message}" });
            }
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage AddToWatchlist(UserWatchlistDTO watchlistDTO)
        {
            try
            {
                var success = UserWatchlistService.AddToWatchlist(watchlistDTO);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Movie added to watchlist successfully.", success });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = $"Failed to add movie to watchlist: {ex.Message}" });
            }
        }

        [HttpPost]
        [Route("remove/{userId}/{movieId}")]
        public HttpResponseMessage RemoveFromWatchlist(int userId, int movieId)
        {
            try
            {
                var success = UserWatchlistService.RemoveFromWatchlist(userId, movieId);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Movie removed from watchlist successfully.", success });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = $"Failed to remove movie from watchlist: {ex.Message}" });
            }
        }
    }
}
