using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ADMLib.Student
{
    public class ViewQueryRespLogic
    {
        public DataTable View_Response(EnqueryFields ef)
        {


            const string strcon = "Server=localhost\\SQLEXPRESS;Database=onlineadmission;Trusted_Connection=True;";
            String query = "select * from adm_tbl_student_queries where r_appid=@r_appid ";
            SqlConnection con = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable { TableName = "MyTable" };
            cmd.Parameters.AddWithValue("@r_appid", ef.AppID);
            cmd.Connection = con;
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dt.Load(dr);
                

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                cmd.Dispose();

            }
            return dt;
        }
    }
}
