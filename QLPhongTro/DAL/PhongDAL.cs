using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using QLPhongTro.Models;

namespace QLPhongTro.DAL
{
    class PhongDAL : DataSet<PhongModel>
    {
        public List<PhongModel> FindAllPhong()
        {
            return ExecuteQuery("dbo.get_all_phong", (reader) => {
                return MapDataReader(reader);
            }, (parameters) => {
            });
        }


        public List<PhongModel> FindAllPhongStatus()
        {
            return ExecuteQuery("dbo.get_phong_status", (reader) => {
                return MapDataReader(reader);
            }, (parameters) => {
            });
        }



        public PhongModel FindPhongById(int id)
        {
            List<PhongModel> result = ExecuteQuery("dbo.get_phong_by_id", (reader) =>
            {
                return MapDataReader(reader);
            }, (parameters) =>
            {
                parameters.AddWithValue("@id", id);
            });
            if (result.Count > 0)
                return result.First();
            else return null;
        }

        public bool CreatePhong(PhongModel phong)
        {
            return Execute("dbo.insert_into_phong", (parameters) => {
                parameters.AddWithValue("@ten_phong", phong.TenPhong);
                parameters.AddWithValue("@loai_phong_id", phong.LoaiPhong.Id);
                parameters.AddWithValue("@status", phong.TrangThai);
            });
        }

        public bool UpdatePhong(PhongModel phong, int id)
        {
            return Execute("dbo.update_phong", (parameters) => {
                parameters.AddWithValue("@ten_phong", phong.TenPhong);
                parameters.AddWithValue("@loai_phong_id", phong.LoaiPhong.Id);
                parameters.AddWithValue("@status", phong.TrangThai);
                parameters.AddWithValue("@id", id);
            });
        }

        public bool DeletePhong(int id)
        {
            return Execute("dbo.delete_phong", (parameters) => {
                parameters.AddWithValue("@id", id);
            });
        }
        
        private PhongModel MapDataReader(SqlDataReader reader)
        {
            PhongModel p = new PhongModel();
            p.Id = reader.GetInt32(0);
            p.TenPhong = reader.GetString(1);
            p.TrangThai = reader.GetString(2);
            p.LoaiPhong.Id = reader.GetInt32(3);
            p.LoaiPhong.TenLoai = reader.GetString(4);
            p.LoaiPhong.GiaTien = reader.GetInt32(5);
           
            return p;
        }

      
    }
}