using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QLPhongTro.Models
{
    public class DatPhongModel
    {

        public int Id { get; set; }
        public KhachHangModel KhachHang { get; set; }
        public PhongModel Phong { get; set; }
        public NhanVienModel NhanVien { get; set; }
        //public int KhachHang { get; set; }
        //public int Phong { get; set; }
        //public int NhanVien { get; set; }
        [Column(TypeName = "date")]
        [Display(Name = "Ngày Đặt Phòng")]
        [Required(ErrorMessage = "Bạn không được để trống")]
        public DateTime ? NgayDat { get; set; }

        public DatPhongModel()
        {
            KhachHang = new KhachHangModel();
            Phong = new PhongModel();
            NhanVien = new NhanVienModel();
            NgayDat = DateTime.Now;
        }
        //public DatPhongModel()
        //{
        //    NgayDat = DateTime.Now;
        //}
    }
}