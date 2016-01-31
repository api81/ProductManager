using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Drawing;
using System.Linq;
using System.Web;

namespace ProductManager.Models
{
    public class Product
    {
        public Product()
        {

        }
        [Key]
        public int ProductId { get; set; }

        [DisplayName("Nazwa produktu")]
        public string ProductName { get; set; }
        [DisplayName("Opis")]
        public string ProductsDescryption { get; set; }

        [DisplayName("Wysokość")]
        public decimal ProductHeight { get; set; }
        [DisplayName("Szerokość")]
        public decimal ProductWidth { get; set; }
        [DisplayName("Cena")]
        [DataType(DataType.Currency)]
        // [RegularExpression(@"^\d+.\d{0,2}$", ErrorMessage = "Price must can't have more than 2decimal places")]
        public decimal ProductPrice { get; set; }




        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
        public virtual ICollection<FilePath> FilePaths { get; set; }

    }

}