using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_App.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        public int UserID { get; set; }
        public User Users { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }

        public decimal PTotal { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string status { get; set; }

        public List<OrderDetail> OderDetails { get; set; }
    }
}
