using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_App.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductModelID { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        public string ModelName { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        public string Demensions { get; set; }

        public int Ram { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        public string Display { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        public string Camera { get; set; }

        public int Battery { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        public string Chip { get; set; }


        [Column(TypeName = "text")]
        public string Describe { get; set; }

        [Column(TypeName = "text")]
        public string Image { get; set; }

    }
}
