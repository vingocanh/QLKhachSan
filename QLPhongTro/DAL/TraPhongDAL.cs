using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using QLPhongTro.Models;

namespace QLPhongTro.DAL
{
    class TraPhongDAL : DataSet<TraPhongModel>
    {
        public List<TraPhongModel> FindAllHoaDonTraPhongg()
        {
            return ExecuteQuery("dbo.get_all_hoa_don_tra_phong", (reader) => {
                return MapDataReader(reader);
            }, (parameters) => {

            });
        }



        public TraPhongModel FindHoaHoaDonTraPhongById(int id)
        {
            List<TraPhongModel> result = ExecuteQuery("dbo.get_hoa_don_tra_phong_by_id", (reader) => {
                return MapDataReader(reader);
            }, (parameters) => {
                parameters.AddWithValue("@id", id);
            });
            if (result.Count > 0)
                return result.First();
            else return null;
        }
        public bool TraPhong(TraPhongModel hoaDonTraPhong)
        {
            return Execute("dbo._tra_phong_", (parameters) => {
                parameters.AddWithValue("@phong_id", hoaDonTraPhong.DatPhong.Phong.Id);
                parameters.AddWithValue("@hoa_don_dat_phong_id", hoaDonTraPhong.DatPhong.Id);
                parameters.AddWithValue("@nhan_vien_id ", hoaDonTraPhong.NhanVien.Id);
                parameters.AddWithValue("@tien", hoaDonTraPhong.DatPhong.Phong.LoaiPhong.GiaTien);
            });
        }

        private TraPhongModel MapDataReader(SqlDataReader reader)
        {
            TraPhongModel hdt = new TraPhongModel();
            DatPhongModel hdd = new DatPhongModel();
            hdd.Id = reader.GetInt32(1);
            hdd.KhachHang.Id = reader.GetInt32(2);
            hdd.KhachHang.Ten = reader.GetString(3);
            hdd.KhachHang.ngaySinh = reader.GetDateTime(4);
            hdd.KhachHang.SoCMT = reader.GetString(5);
            hdd.KhachHang.SoDT = reader.GetString(6);
            hdd.Phong.Id = reader.GetInt32(7);
            hdd.Phong.TenPhong = reader.GetString(8);
            hdd.Phong.TrangThai = reader.GetString(9);
            hdd.Phong.LoaiPhong.Id = reader.GetInt32(10);
            hdd.Phong.LoaiPhong.TenLoai = reader.GetString(11);
            hdd.Phong.LoaiPhong.GiaTien = reader.GetInt32(12);
            hdd.NhanVien.Id = reader.GetInt32(13);
            hdd.NhanVien.TaiKhoan = reader.GetString(14);
            hdd.NhanVien.MatKhau = reader.GetString(15);
            hdd.NhanVien.Ten = reader.GetString(16);
            hdd.NgayDat = reader.GetDateTime(17);

            
            hdt.DatPhong = hdd;
            hdt.NhanVien.Id = reader.GetInt32(18);
            hdt.NhanVien.TaiKhoan = reader.GetString(19);
            hdt.NhanVien.MatKhau = reader.GetString(20);
            hdt.NhanVien.Ten = reader.GetString(21);
            hdt.NgayTra = reader.GetDateTime(22);
            hdt.SoTien = reader.GetInt32(23);
            return hdt;
        }
    }
}