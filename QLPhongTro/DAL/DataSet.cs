using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QLPhongTro.DAL
{
    abstract class DataSet<T>
    {

        public static SqlConnection GetConnect()
        {
            return new SqlConnection(@"Data Source=DESKTOP-ANUAD36\SQLEXPRESS;Initial Catalog=QLPhongTro;Integrated Security=True");
        }

        public List<T> ExecuteQuery(String proc, Func<SqlDataReader, T> MapData, Action<SqlParameterCollection> MapParams)
        {
            List<T> result = new List<T>();
            SqlConnection conn = GetConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = proc;
            cmd.Connection = conn;
            MapParams(cmd.Parameters);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(MapData(reader));
                }
            }
            catch (Exception e)
            {
                throw e;
                //Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE=""JavaScript"">alert("Bạn không được để trống")</SCRIPT>");

            }
            finally
            {
                conn.Close();
            }
            return result;
        }


        public bool Execute(String proc, Action<SqlParameterCollection> MapParams)
        {
            SqlConnection conn = GetConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = proc;
            cmd.Connection = conn;
            MapParams(cmd.Parameters);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}