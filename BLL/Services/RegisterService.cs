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
    public class RegisterService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, RegisterDTO>();
                cfg.CreateMap<RegisterDTO, User>();
            });
            return new Mapper(config);
        }
        public static bool Create(RegisterDTO obj)
        {
            var data = GetMapper().Map<User>(obj);
            return DataAccess.RegisterData().Create(data);
        }
        public static List<RegisterDTO> Get()
        {
            var data = DataAccess.RegisterData().Get();
            return GetMapper().Map<List<RegisterDTO>>(data);
        }
        public static RegisterDTO Get(int id)
        {
            var data = DataAccess.RegisterData().Get(id);
            return GetMapper().Map<RegisterDTO>(data);
        }
        public static bool Update(RegisterDTO obj)
        {
            var data = GetMapper().Map<User>(obj);
            return DataAccess.RegisterData().Update(data);
        }
        public static bool Delete(int id)
        {
            return DataAccess.RegisterData().Delete(id);
        }
    }
}
