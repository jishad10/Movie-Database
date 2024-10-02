using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class GenreRepo : Repo, IRepo<Genre, int, bool>
    {
        public bool Create(Genre obj)
        {
            db.Genres.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Genres.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<Genre> Get()
        {
            return db.Genres.ToList();
        }

        public Genre Get(int id)
        {
            return db.Genres.Find(id);
        }

        public bool Update(Genre obj)
        {
            var exobj = Get(obj.Id);
            db.Entry(exobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
