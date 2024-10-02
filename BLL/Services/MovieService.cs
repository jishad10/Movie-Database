using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class MovieService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Movie, MovieDTO>();
                cfg.CreateMap<MovieDTO, Movie>();
            });
            return new Mapper(config);
        }
        public static bool Create(MovieDTO obj)
        {
            var data = GetMapper().Map<Movie>(obj);
            return DataAccess.MovieData().Create(data);
        }
        public static List<MovieDTO> Get()
        {
            var data = DataAccess.MovieData().Get();
            return GetMapper().Map<List<MovieDTO>>(data);
        }
        public static MovieDTO Get(int id)
        {
            var data = DataAccess.MovieData().Get(id);
            return GetMapper().Map<MovieDTO>(data);
        }
        public static bool Update(MovieDTO obj)
        {
            var data = GetMapper().Map<Movie>(obj);
            return DataAccess.MovieData().Update(data);
        }
        public static bool Delete(int id)
        {
            return DataAccess.MovieData().Delete(id);
        }
        public static List<MovieDTO> SearchByTitle(string title)
        {
            var data = DataAccess.MovieData().SearchByTitle(title);
            return GetMapper().Map<List<MovieDTO>>(data);
        }
    }
}
