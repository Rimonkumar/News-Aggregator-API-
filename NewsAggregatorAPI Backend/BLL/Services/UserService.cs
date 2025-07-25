using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using DAL;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class UserService
    {
        public static UserDTO Create(UserDTO userDto)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<UserDTO, User>();
                c.CreateMap<User, UserDTO>();
            });

            var mapper = new Mapper(cfg);
            var user = mapper.Map<User>(userDto);

            var createdUser = DataAccessFactory.UserData().Create(user);

            if (createdUser != null)
            {
                return mapper.Map<UserDTO>(createdUser);
            }
            return null;
        }

        public static List<UserDTO> Get()
        {
            var data = DataAccessFactory.UserData().Read();

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>();
            });

            var mapper = new Mapper(cfg);
            return mapper.Map<List<UserDTO>>(data);
        }

        public static UserDTO Update(UserDTO userDto)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<UserDTO, User>();
                c.CreateMap<User, UserDTO>();
            });

            var mapper = new Mapper(cfg);
            var user = mapper.Map<User>(userDto);

            var updatedUser = DataAccessFactory.UserData().Update(user);

            if (updatedUser != null)
            {
                return mapper.Map<UserDTO>(updatedUser);
            }
            return null;
        }

        public static bool Delete(string uname)
        {
            try
            {
                var user = DataAccessFactory.UserData().Read(uname);
                if (user == null) return false;

                
                var allArticles = DataAccessFactory.ArticleData().Read();
                var userArticles = allArticles.Where(a => a.UserId == user.Id).ToList();

              
                foreach (var article in userArticles)
                {
                    DataAccessFactory.ArticleData().Delete(article.Id);
                }

                
                return DataAccessFactory.UserData().Delete(uname);
            }
            catch
            {
                return false; 
            }
        }
    }
}