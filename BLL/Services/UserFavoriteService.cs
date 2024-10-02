using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.TableModels;
using System.Collections.Generic;

namespace BLL.Services
{
    public class UserFavoriteService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Movie, MovieDTO>();
                cfg.CreateMap<MovieDTO, Movie>();
                cfg.CreateMap<UserFavorite, UserFavoriteDTO>();
                cfg.CreateMap<UserFavoriteDTO, UserFavorite>();
            });
            return new Mapper(config);
        }
        public static bool AddToFavorites(UserFavoriteDTO favoriteDTO)
        {
            var favorite = GetMapper().Map<UserFavorite>(favoriteDTO);
            return DataAccess.UserFavoriteData().AddToFavorites(favorite);
        }
        public static bool RemoveFromFavorites(int userId, int movieId)
        {
            return DataAccess.UserFavoriteData().RemoveFromFavorites(userId, movieId);
        }
        public static List<UserFavoriteDTO> GetUserFavorites(int userId)
        {
            var favorites = DataAccess.UserFavoriteData().GetUserFavorites(userId);
            return GetMapper().Map<List<UserFavoriteDTO>>(favorites);
        }
    }
}
