using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ArticleDTO
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public string PostedBy { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int SourceId { get; set; }

        public UserDTO User { get; set; }
        public CategoryDTO Category { get; set; }
        public SourceDTO Source { get; set; }
    }

    

}
