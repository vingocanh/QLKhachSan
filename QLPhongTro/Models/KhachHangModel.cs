using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLPhongTro.Models
{
    public class KhachHangModel
    {

        [Display(Name = "ID Khách Hàng")]
        [Required(ErrorMessage = "Bạn không được để trống")]
        public int Id { get; set; }
        [Display(Name = "Tên Khách Hàng")]
        [Required(ErrorMessage = "Bạn không được để trống")]
        public String Ten { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày Sinh")]
        [Required(ErrorMessage = "Bạn không được để trống")]
        public DateTime ? ngaySinh { get; set; }

        [Display(Name = "Số CMT")]
        [Required(ErrorMessage = "Bạn không được để trống")]
        public String SoCMT { get; set; }

        [Display(Name = "Số ĐT")]
        [Required(ErrorMessage = "Bạn không được để trống")]
        public String SoDT { get; set; }

      
        private class ColumnAttribute : Attribute
        {
            public string TypeName { get; set; }
        }
    }
}