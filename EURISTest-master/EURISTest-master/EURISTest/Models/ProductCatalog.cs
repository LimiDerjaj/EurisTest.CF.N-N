using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EURISTest.Models
{
    [Table("ProductCatalogs")]
    public class ProductCatalog
    {
        [Key]
        public int ProductCatalogID { get; set; }
        public int FKCatalogID { get; set; }
        [ForeignKey("FKCatalogID")]
        public Catalog Catalog { get; set; }
        public int FKProductID { get; set; }
        [ForeignKey("FKProductID")]
        public Product Product { get; set; }
    }
}