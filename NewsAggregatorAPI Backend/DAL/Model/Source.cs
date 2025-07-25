using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Source
    {
        
        [Key]
        public int SourceId { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        public string URL { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

        public Source()
        {
            Articles = new List<Article>();
        }
    }
}

