using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class SourceDTO
    {
        public int SourceId { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        public string URL { get; set; }
    }
}
