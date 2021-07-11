using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLPhongTro.Models
{
    public class LoaiPhongModel
    {
        [Display(Name = "ID Loại Phòng")]
        [Required(ErrorMessage = "Bạn không được để trống")]
        public int Id { get; set; }
        [Display(Name = "Tên Loại Phòng")]
        [Required(ErrorMessage = "Bạn không được để trống")]
        public String TenLoai { get; set; }
        [Display(Name = "Giá Tiền")]
        [Required(ErrorMessage = "Bạn không được để trống")]
        public long GiaTien { get; set; }
    }
}