using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class MovieRepo : Repo, IMRepo<Movie, int, bool>
    {
        public bool Create(Movie obj)
        {
            db.Movies.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Movies.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<Movie> Get()
        {
            return db.Movies.ToList();
        }

        public Movie Get(int id)
        {
            return db.Movies.Find(id);
        }

        public bool Update(Movie obj)
        {
            var exobj = Get(obj.Id);
            db.Entry(exobj).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

        public List<Movie> SearchByTitle(string title)
        {
            return db.Movies.Where(m => m.Title.Contains(title)).ToList();
        }
    }
}
