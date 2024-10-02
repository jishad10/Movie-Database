using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }
        public virtual ICollection<UserReview> UserReviews { get; set; }
        public virtual ICollection<UserFavorite> UserFavorites { get; set; }
        public virtual ICollection<UserWatchlist> UserWatchlist { get; set; }
        public virtual ICollection<Token> Tokens { get; set; }

        public User()
        {
            UserReviews = new List<UserReview>();
            UserFavorites = new List<UserFavorite>();
            UserWatchlist = new List<UserWatchlist>();
            Tokens = new List<Token>();
        }
    }
}
