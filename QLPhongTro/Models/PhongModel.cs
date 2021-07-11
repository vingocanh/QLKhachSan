using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using QLPhongTro.Models;

namespace QLPhongTro.Models
{
    public class PhongModel
    {
        [Display(Name = "ID Phòng")]
        [Required(ErrorMessage = "Bạn không được để trống")]
        public int Id { get; set; }
        [Display(Name = "Tên Phòng")]
        [Required(ErrorMessage = "Bạn không được để trống")]
        public String TenPhong { get; set; }
        [Display(Name = "Trạng Thái")]
        //[Required(ErrorMessage = "Bạn không được để trống")]
        public String TrangThai { get; set; }
        private LoaiPhongModel loaiPhong;

        public PhongModel()
        {
            loaiPhong = new LoaiPhongModel();
        }
        public LoaiPhongModel LoaiPhong
        {
            get
            {
                return loaiPhong;
            }

            set
            {
                loaiPhong = value;
            }
        }
    }
}