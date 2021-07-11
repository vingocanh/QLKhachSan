using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using QLPhongTro.Models;

namespace QLPhongTro.Models
{
    public class TraPhongModel
    {
        
        public int Id { get; set; }
        public DatPhongModel DatPhong { get; set; }
        public NhanVienModel NhanVien { get; set; }
        public DateTime NgayTra { get; set; }
        public long SoTien { get; set; }

        public TraPhongModel()
        {
            DatPhong = new DatPhongModel();
            NhanVien = new NhanVienModel();
        }
    }
}