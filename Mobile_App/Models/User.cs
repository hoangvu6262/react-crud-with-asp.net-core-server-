using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mobile_App.Models
{
    public class User
    {
        [Key]
        public int Usersid { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        public string taiKhoan { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string hoTen { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string email { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string soDt { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string matKhau { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string maLoaiNguoiDung { get; set; }
    }
}
