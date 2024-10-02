using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserFavoriteRepo<RET>
    {
        RET AddToFavorites(UserFavorite obj);
        RET RemoveFromFavorites(int userId, int movieId);
        List<UserFavorite> GetUserFavorites(int userId);
    }
}
