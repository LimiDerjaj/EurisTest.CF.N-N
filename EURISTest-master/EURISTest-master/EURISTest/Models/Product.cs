﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EURISTest.Models
{
    [Table("Products")]
    public class Product
    {

        [Key]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Product code required!")]
        [StringLength(50, ErrorMessage = "Maximum length is 50 char")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Product description required!")]
        [StringLength(50, ErrorMessage = "Maximum length is 50 char")]
        public string Description { get; set; }

        public virtual ICollection<Catalog> Catalogs { get; set; }

        public Product()
        {
            Catalogs = new HashSet<Catalog>();
        }
    }
}