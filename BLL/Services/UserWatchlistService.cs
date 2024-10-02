using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.TableModels;
using System.Collections.Generic;

namespace BLL.Services
{
    public class UserWatchlistService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Movie, MovieDTO>();
                cfg.CreateMap<MovieDTO, Movie>();
                cfg.CreateMap<UserWatchlist, UserWatchlistDTO>();
                cfg.CreateMap<UserWatchlistDTO, UserWatchlist>();
            });
            return new Mapper(config);
        }
        public static bool AddToWatchlist(UserWatchlistDTO watchlistDTO)
        {
            var watchlist = GetMapper().Map<UserWatchlist>(watchlistDTO);
            return DataAccess.UserWatchlistData().Create(watchlist);
        }
        public static bool RemoveFromWatchlist(int userId, int movieId)
        {
            return DataAccess.UserWatchlistData().RemoveFromWatchlist(userId, movieId);
        }
        public static List<UserWatchlistDTO> GetWatchlistByUser(int userId)
        {
            var data = DataAccess.UserWatchlistData().GetByUserId(userId);
            return GetMapper().Map<List<UserWatchlistDTO>>(data);
        }
    }
}
