using DAL.Interface;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class CategoryRepo : Repo, IRepo<Category, int, Category>
    {
        public Category Create(Category obj)
        {
            db.Categories.Add(obj);
            return db.SaveChanges() > 0 ? obj : null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Categories.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Category> Read()
        {
            return db.Categories.ToList();
        }

        public Category Read(int id)
        {
            return db.Categories.Find(id);
        }

        public Category Update(Category obj)
        {
            var ex = Read(obj.CategoryId);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0 ? obj : null;
        }
    }
}
