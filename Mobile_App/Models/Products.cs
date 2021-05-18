using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_App.Models
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }

        public int ProductModelID { get; set; }
        public ProductModel ProductModel { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        public string ModelName { get; set; }

        public int Rom { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Color { get; set; }

        public decimal Price { get; set; }

        [Column(TypeName = "text")]
        public string Status { get; set; }

        public int Quantily { get; set; }

        [Column(TypeName = "text")]
        public string Image { get; set; }

    }
}
