using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
