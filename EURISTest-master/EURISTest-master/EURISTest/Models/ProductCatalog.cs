using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EURISTest.Models
{
    public class ProductCatalog
    {
        [Key, Column(Order = 1)]
        public int ProductId { get; set; }
        [Key, Column(Order = 2)]
        public int CatalogId { get; set; }
        public Product Product { get; set; }
        public Catalog Catalog { get; set; }
    }
}