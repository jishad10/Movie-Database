using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class UserWatchlist
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual Movie Movie { get; set; }
        [ForeignKey("Movie")]
        public int MovieId { get; set; }
    }
}
