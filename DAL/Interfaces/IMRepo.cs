using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IMRepo<CLASS, ID, RET>
    {
        RET Create(CLASS obj);
        List<CLASS> Get();
        CLASS Get(ID id);
        RET Update(CLASS obj);
        bool Delete(ID id);
        List<CLASS> SearchByTitle(string title);
    }
}
