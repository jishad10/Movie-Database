using DAL.EF.TableModels;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class UserFavoriteRepo : Repo, IUserFavoriteRepo<bool>
    {
        public bool AddToFavorites(UserFavorite obj)
        {
            db.UserFavorites.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool RemoveFromFavorites(int userId, int movieId)
        {
            var favorite = db.UserFavorites.FirstOrDefault(uf => uf.UserId == userId && uf.MovieId == movieId);
            if (favorite != null)
            {
                db.UserFavorites.Remove(favorite);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public List<UserFavorite> GetUserFavorites(int userId)
        {
            return db.UserFavorites.Where(uf => uf.UserId == userId).ToList();
        }
    }
}
