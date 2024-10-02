using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.TableModels;
using System.Collections.Generic;

namespace BLL.Services
{
    public class UserReviewService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserReview, UserReviewDTO>();
                cfg.CreateMap<UserReviewDTO, UserReview>();
            });
            return new Mapper(config);
        }
        public static bool Create(UserReviewDTO obj)
        {
            var data = GetMapper().Map<UserReview>(obj);
            return DataAccess.UserReviewData().Create(data);
        }
        public static List<UserReviewDTO> Get()
        {
            var data = DataAccess.UserReviewData().Get();
            return GetMapper().Map<List<UserReviewDTO>>(data);
        }
        public static UserReviewDTO Get(int id)
        {
            var data = DataAccess.UserReviewData().Get(id);
            return GetMapper().Map<UserReviewDTO>(data);
        }
        public static bool Update(UserReviewDTO obj)
        {
            var data = GetMapper().Map<UserReview>(obj);
            return DataAccess.UserReviewData().Update(data);
        }
        public static bool Delete(int id)
        {
            return DataAccess.UserReviewData().Delete(id);
        }
    }
}
