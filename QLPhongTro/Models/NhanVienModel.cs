using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLPhongTro.Models
{
    public class NhanVienModel
    {
        [Display(Name = "ID Nhân viên")]
        [Required(ErrorMessage = "Bạn không được để trống")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Bạn không được để trống tên tài khoản")]
        public string TaiKhoan { get; set; }
        [Required(ErrorMessage = "Bạn không được để pass")]
        public string MatKhau { get; set; }
        [Display(Name = "Tên Nhân Viên")]
        public string Ten { get; set; }
        private bool remember;


        public bool Remember
        {
            get
            {
                return remember;
            }

            set
            {
                remember = value;
            }
        }
    }
}