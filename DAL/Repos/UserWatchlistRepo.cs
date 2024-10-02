using DAL.EF.TableModels;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class UserWatchlistRepo : Repo, IUserWatchlistRepo<bool>
    {
        public bool Create(UserWatchlist obj)
        {
            db.UserWatchlists.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool RemoveFromWatchlist(int userId, int movieId)
        {
            var watchlist = db.UserWatchlists.FirstOrDefault(wl => wl.UserId == userId && wl.MovieId == movieId);
            if (watchlist != null)
            {
                db.UserWatchlists.Remove(watchlist);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public List<UserWatchlist> GetByUserId(int userId)
        {
            return db.UserWatchlists.Where(wl => wl.UserId == userId).ToList();
        }
    }
}
