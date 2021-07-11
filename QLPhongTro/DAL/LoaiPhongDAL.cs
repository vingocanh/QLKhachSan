using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using QLPhongTro.Models;

namespace QLPhongTro.DAL
{
    class LoaiPhongDAL : DataSet<LoaiPhongModel>
    {

        public List<LoaiPhongModel> FindAllLoaiPhong()
        {
            return ExecuteQuery("dbo.get_all_loai_phong", (reader) => {
                return MapDataReaderLoaiP(reader);
            }, (parameters) => {
            });
        }

        private LoaiPhongModel MapDataReaderLoaiP(SqlDataReader reader)
        {
            LoaiPhongModel lP = new LoaiPhongModel();
            lP.Id = reader.GetInt32(0);
            lP.TenLoai = reader.GetString(1);
            lP.GiaTien = reader.GetInt32(2);


            return lP;
        }
    }
}