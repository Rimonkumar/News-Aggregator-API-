using DAL.Interface;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;

namespace DAL.Repos
{
    public class ArticleRepo : Repo, IRepo<Article, int, Article>
    {
        public Article Create(Article obj)
        {
            db.Articles.Add(obj);
            return db.SaveChanges() > 0 ? obj : null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Articles.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Article> Read()
        {
            return db.Articles.ToList();
        }

        public Article Read(int id)
        {
            return db.Articles.Find(id);
        }

        public Article Update(Article obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0 ? obj : null;
        }

        // 🔍 Custom Method for Searching by Title (with eager loading)
        public List<Article> SearchByTitle(string title)
        {
            return db.Articles
                     .Include("User")
                     .Include("Category")
                     .Include("Source")
                     .Where(a => a.Title.Contains(title))
                     .ToList();
        }

        public Article GetWithAllRelations(int id)
        {
            return db.Articles
                     .Include("User")
                     .Include("Category")
                     .Include("Source")
                     .FirstOrDefault(a => a.Id == id);
        }

    }
}
