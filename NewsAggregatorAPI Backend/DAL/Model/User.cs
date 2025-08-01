﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User
    {
        [Key]
        public string Uname { get; set; }

        [Required, StringLength(20)]
        public string Password { get; set; }

        [Required, StringLength(20)]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
        public object Id { get; set; }

        public User()
        {
            Articles = new List<Article>();
        }
    }
}
