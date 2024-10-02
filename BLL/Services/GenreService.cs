using AutoMapper;
using BLL.DTOs;
using DAL.EF.TableModels;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class GenreService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Genre, GenreDTO>();
                cfg.CreateMap<GenreDTO, Genre>();
            });
            return new Mapper(config);
        }
        public static bool Create(GenreDTO obj)
        {
            var data = GetMapper().Map<Genre>(obj);
            return DataAccess.GenreData().Create(data);
        }
        public static List<GenreDTO> Get()
        {
            var data = DataAccess.GenreData().Get();
            return GetMapper().Map<List<GenreDTO>>(data);
        }
        public static GenreDTO Get(int id)
        {
            var data = DataAccess.GenreData().Get(id);
            return GetMapper().Map<GenreDTO>(data);
        }
        public static bool Update(GenreDTO obj)
        {
            var data = GetMapper().Map<Genre>(obj);
            return DataAccess.GenreData().Update(data);
        }
        public static bool Delete(int id)
        {
            return DataAccess.GenreData().Delete(id);
        }
    }
}
