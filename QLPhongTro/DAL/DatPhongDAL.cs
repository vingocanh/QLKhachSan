using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using QLPhongTro.Models;

namespace QLPhongTro.DAL
{
    class DatPhongDAL : DataSet<DatPhongModel>
    {

        public List<DatPhongModel> FindAllHoaDonDatPhong()
        {
            return ExecuteQuery("dbo.get_hoa_don_dat_phong", (reader) => {
                return MapDataReader(reader);
            }, (parameters) => {

            });
        }

        public DatPhongModel FindHoaDonDatPhongById(int id)
        {
            List<DatPhongModel> result = ExecuteQuery("dbo.get_hoa_don_dat_phong_by_id", (reader) => {
                return MapDataReader(reader);
            }, (parameters) => {
                parameters.AddWithValue("@id", id);
            });
            if (result.Count > 0)
                return result.First();
            else return null;
        }
        public DatPhongModel FindDatPhongById(int id)
        {
            List<DatPhongModel> result = ExecuteQuery("dbo.get_hddp_by_id", (reader) => {
                return MapDataReader(reader);
            }, (parameters) => {
                parameters.AddWithValue("@id", id);
            });
            if (result.Count > 0)
                return result.First();
            else return null;
        }

        public bool DatPhong(DatPhongModel hoaDonDatPhong)
        {
            return Execute("dbo.dat_phong_ks", (parameters) => {
                parameters.AddWithValue("@khach_hang_id", hoaDonDatPhong.KhachHang.Id);
                parameters.AddWithValue("@phong_id", hoaDonDatPhong.Phong.Id);
                parameters.AddWithValue("@nhan_vien_id", hoaDonDatPhong.NhanVien.Id);
            });
        }

        private DatPhongModel MapDataReader(SqlDataReader reader)
        {
            DatPhongModel hd = new DatPhongModel();
            hd.Id = reader.GetInt32(0);
            hd.KhachHang.Id = reader.GetInt32(1);
            hd.KhachHang.Ten = reader.GetString(2);
            hd.KhachHang.ngaySinh = reader.GetDateTime(3);
            hd.KhachHang.SoCMT = reader.GetString(4);
            hd.KhachHang.SoDT = reader.GetString(5);
            hd.Phong.Id = reader.GetInt32(6);
            hd.Phong.TenPhong = reader.GetString(7);
            hd.Phong.TrangThai = reader.GetString(8);
            hd.Phong.LoaiPhong.Id = reader.GetInt32(9);
            hd.Phong.LoaiPhong.TenLoai = reader.GetString(10);
            hd.Phong.LoaiPhong.GiaTien = reader.GetInt32(11);
            hd.NhanVien.Id = reader.GetInt32(12);
            hd.NhanVien.TaiKhoan = reader.GetString(13);
            hd.NhanVien.MatKhau = reader.GetString(14);
            hd.NhanVien.Ten = reader.GetString(15);
            hd.NgayDat = reader.GetDateTime(16);
            return hd;
        }

    }
}