using DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [ForeignKey("User")]
        public string PostedBy { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [ForeignKey("Source")]
        public int SourceId { get; set; }

        public DateTime Date { get; set; }

        public virtual User User { get; set; }
        public virtual Category Category { get; set; }
        public virtual Source Source { get; set; }
        public object UserId { get; set; }
    }
}
