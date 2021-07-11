using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using QLPhongTro.Models;

namespace QLPhongTro.DAL
{
    class KhachHangDAL : DataSet<KhachHangModel>
    {
        public List<KhachHangModel> FindAllKhachHang()
        {
            return ExecuteQuery("dbo.get_all_khach_hang", (reader) => {
                return MapDataReader(reader);
            }, (parameters) => {

            });
        }


        public KhachHangModel FindKhachHangById(int id)
        {
            List<KhachHangModel> result = ExecuteQuery("dbo.get_khach_hang_by_id", (reader) => {
                return MapDataReader(reader);
            }, (parameters) => {
                parameters.AddWithValue("@id", id);
            });
            if (result.Count > 0)
                return result.First();
            else return null;
        }

        public bool CreateKhachHang(KhachHangModel khachHang)
        {
            return Execute("dbo.insert_into_khach_hang", (parameters) => {
                parameters.AddWithValue("@ten", khachHang.Ten);
                parameters.AddWithValue("@ngay_sinh", khachHang.ngaySinh);
                parameters.AddWithValue("@so_cmt", khachHang.SoCMT);
                parameters.AddWithValue("@so_dien_thoai", khachHang.SoDT);
            });
        }

        public bool UpdateKhachHang(KhachHangModel khachHang, int id)
        {
            return Execute("dbo.update_khach_hang", (parameters) => {
                parameters.AddWithValue("@ten", khachHang.Ten);
                parameters.AddWithValue("@ngay_sinh", khachHang.ngaySinh);
                parameters.AddWithValue("@so_cmt", khachHang.SoCMT);
                parameters.AddWithValue("@so_dien_thoai", khachHang.SoDT);
                parameters.AddWithValue("@id", id);
            });
        }

        public bool DeleteKhachHang(int id)
        {
            return Execute("dbo.delete_khach_hang", (parameters) => {
                parameters.AddWithValue("@id", id);
            });
        }
        private KhachHangModel MapDataReader(SqlDataReader reader)
        {
            KhachHangModel kh = new KhachHangModel();
            kh.Id = reader.GetInt32(0);
            kh.Ten = reader.GetString(1);
            kh.ngaySinh = reader.GetDateTime(2);
            kh.SoCMT = reader.GetString(3);
            kh.SoDT = reader.GetString(4);
            return kh;
        }
    }
}