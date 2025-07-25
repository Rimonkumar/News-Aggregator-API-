using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Model;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ArticleService
    {
        public static List<ArticleDTO> Get()
        {
            var data = DataAccessFactory.ArticleData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Article, ArticleDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<ArticleDTO>>(data);
        }

        //public static ArticleDTO Get(int id)
        //{
        //    var data = DataAccessFactory.ArticleData().Read(id);
        //    var cfg = new MapperConfiguration(c =>
        //    {
        //        c.CreateMap<Article, ArticleDTO>();
        //    });
        //    var mapper = new Mapper(cfg);
        //    return mapper.Map<ArticleDTO>(data);
        //}

        public static ArticleDTO Get(int id)
        {
            var data = (DataAccessFactory.ArticleData() as ArticleRepo).GetWithAllRelations(id);

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<User, UserDTO>();
                c.CreateMap<Category, CategoryDTO>();
                c.CreateMap<Source, SourceDTO>();

                c.CreateMap<Article, ArticleDTO>()
                    .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                    .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                    .ForMember(dest => dest.Source, opt => opt.MapFrom(src => src.Source));
            });

            var mapper = new Mapper(cfg);
            return mapper.Map<ArticleDTO>(data);
        }


        public static bool Delete(int id)
        {
            return DataAccessFactory.ArticleData().Delete(id);
        }

        public static ArticleDTO Create(ArticleDTO articleDto)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ArticleDTO, Article>();
                c.CreateMap<Article, ArticleDTO>();
            });
            var mapper = new Mapper(cfg);

            var article = mapper.Map<Article>(articleDto);

            var createdArticle = DataAccessFactory.ArticleData().Create(article);

            if (createdArticle != null)
            {
                return mapper.Map<ArticleDTO>(createdArticle);
            }
            return null;
        }


        public static List<ArticleDTO> SearchByTitle(string title)
        {
            var repo = DataAccessFactory.ArticleData() as ArticleRepo;
            var data = repo.SearchByTitle(title);

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Article, ArticleDTO>();
                c.CreateMap<User, UserDTO>();
                c.CreateMap<Category, CategoryDTO>();
                c.CreateMap<Source, SourceDTO>();
            });

            var mapper = new Mapper(cfg);
            return mapper.Map<List<ArticleDTO>>(data);
        }




    }
}