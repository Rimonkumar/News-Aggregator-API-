using DAL.Interface;
using DAL.Model;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class SourceRepo : Repo, IRepo<Source, int, Source>
    {
        public Source Create(Source obj)
        {
            db.Sources.Add(obj);
            return db.SaveChanges() > 0 ? obj : null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Sources.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Source> Read()
        {
            return db.Sources.ToList();
        }

        public Source Read(int id)
        {
            return db.Sources.Find(id);
        }

        public Source Update(Source obj)
        {
            var ex = Read(obj.SourceId);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0 ? obj : null;
        }
    }
}
