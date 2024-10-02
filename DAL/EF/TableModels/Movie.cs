using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Director { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [StringLength(1000)]
        public string TrailerLink { get; set; }

        [StringLength(1000)]
        public string ReviewLink { get; set; }
        public virtual Genre Genre { get; set; }

        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        public virtual ICollection<UserReview> UserReviews { get; set; }
        public virtual ICollection<UserFavorite> UserFavorites { get; set; }
        public virtual ICollection<UserWatchlist> UserWatchlist { get; set; }
        public Movie()
        {
            UserReviews = new List<UserReview>();
            UserFavorites = new List<UserFavorite>();
            UserWatchlist = new List<UserWatchlist>();
        }
    }
}
