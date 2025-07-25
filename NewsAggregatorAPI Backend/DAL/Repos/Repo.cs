using DAL.Model;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class Repo
    {
        internal ArticlesContext db;
        public Repo()
        {
            db = new ArticlesContext();
        }
    }
}
