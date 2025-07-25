using DAL.Interface;
using DAL.Interfaces;
using DAL.Model;
using DAL.Models;
using DAL.Repos;

namespace DAL
{
    public class DataAccessFactory
    {
        
        public static IRepo<Article, int, Article> ArticleData()
        {
            return new ArticleRepo();
        }

        
        public static IRepo<Category, int, Category> CategoryData()
        {
            return new CategoryRepo();
        }

        
        public static IRepo<Source, int, Source> SourceData()
        {
            return new SourceRepo();
        }

        
        public static IRepo<User, string, User> UserData()
        {
            return new UserRepo();
        }

        
        public static IAuth<bool> AuthData()
        {
            return new UserRepo();
        }

        public static IRepo<Token, string, Token> TokenData()
        {
            return new TokenRepo();
        }

    }
}
