using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserWatchlistRepo<RET>
    {
        RET Create(UserWatchlist obj);
        RET RemoveFromWatchlist(int userId, int movieId);
        List<UserWatchlist> GetByUserId(int userId);
    }
}
