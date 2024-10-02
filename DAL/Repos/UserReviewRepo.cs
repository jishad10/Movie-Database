using DAL.EF.TableModels;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class UserReviewRepo : Repo, IRepo<UserReview, int, bool>
    {
        public bool Create(UserReview obj)
        {
            db.UserReviews.Add(obj);
            return db.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.UserReviews.Remove(exobj);
            return db.SaveChanges() > 0;
        }
        public List<UserReview> Get()
        {
            return db.UserReviews.ToList();
        }
        public UserReview Get(int id)
        {
            return db.UserReviews.Find(id);
        }
        public bool Update(UserReview obj)
        {
            var exobj = Get(obj.Id);
            db.Entry(exobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
