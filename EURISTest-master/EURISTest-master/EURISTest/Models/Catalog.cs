using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EURISTest.Models
{
    [Table("Catalogs")]
    public class Catalog
    {

        [Key]
        public int CatalogID { get; set; }
        [Required(ErrorMessage = "Catalog code required!")]
        [StringLength(50, ErrorMessage = "Maximum length is 50 char")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Catalog description required!")]
        [StringLength(50, ErrorMessage = "Maximum length is 50 char")]
        public string Description { get; set; }
        //public List<Product> productList;

        public virtual ICollection<ProductCatalog> Catalogs { get; set; }

    }
}