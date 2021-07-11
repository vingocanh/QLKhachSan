using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using QLPhongTro.Models;

namespace QLPhongTro.DAL
{
    class NhanVienDAL : DataSet<NhanVienModel>
    {
        public NhanVienModel Login(string taiKhoan, string matKhau)
        {
            List<NhanVienModel> result = ExecuteQuery("dbo.login_nv", (reader) => {
                return MapDataReader(reader);
            }, (parameters) => {
                parameters.AddWithValue("@tai_khoan", taiKhoan);
                parameters.AddWithValue("@mat_khau", matKhau);
            });
            if (result.Count > 0)
                return result.First();
            else return null;
        }

        public List<NhanVienModel> FindAllNhanVien()
        {
            return ExecuteQuery("dbo.get_all_nhanvien", (reader) => {
                return MapDataReader(reader);
            }, (parameters) => {

            });
        }


        private NhanVienModel MapDataReader(SqlDataReader reader)
        {
            NhanVienModel nv = new NhanVienModel();
            nv.Id = reader.GetInt32(0);
            nv.TaiKhoan = reader.GetString(1);
            nv.MatKhau = reader.GetString(2);
            nv.Ten = reader.GetString(3);
            return nv;
        }
    }
}