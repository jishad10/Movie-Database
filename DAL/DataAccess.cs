using DAL.EF.TableModels;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccess
    {
        public static IMRepo<Movie, int, bool> MovieData()
        {
            return new MovieRepo();
        }

        public static IRepo<Genre, int, bool> GenreData()
        {
            return new GenreRepo();
        }

        public static IRepo<UserReview, int, bool> UserReviewData()
        {
            return new UserReviewRepo();
        }

        public static IUserFavoriteRepo<bool> UserFavoriteData()
        {
            return new UserFavoriteRepo();
        }

        public static IUserWatchlistRepo<bool> UserWatchlistData()
        {
            return new UserWatchlistRepo();
        }

        public static IAuth AuthData()
        {
            return new UserRepo();
        }

        public static IRepo<Token, string, Token> TokenData()
        {
            return new TokenRepo();
        }

        public static IRepo<User, int, bool> RegisterData()
        {
            return new RegisterRepo();
        }
    }
}
