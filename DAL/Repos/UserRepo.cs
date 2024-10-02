using DAL.EF.TableModels;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repo,IAuth
    {
        public bool Authenticate(int uid, string pass)
        {
            var user = db.Users.SingleOrDefault(
                    u => u.Id.Equals(uid) &&
                    u.Password.Equals(pass)
                );
            return user != null;
        }
    }
}
