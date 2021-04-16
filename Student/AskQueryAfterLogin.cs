using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MyTestLib
{
    public class AskQueryAfterLogin
    {

        public int Ask_Que_Again(EnqueryFields ef)
        {

            const string strcon = "Server=localhost\\SQLEXPRESS;Database=onlineadmission;Trusted_Connection=True;";
            String query2 = "insert into adm_tbl_student_queries (r_appid,r_query,r_time_posted) values (@r_uid,@r_query,@r_time_posted)";

            DateTimeOffset now = (DateTimeOffset)DateTime.UtcNow;
           SqlConnection con = new SqlConnection(strcon);
           SqlCommand cmd = new SqlCommand(query2, con);
            cmd.CommandType = CommandType.Text;
            try
            {
                
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd2.Connection = con;
                con.Open();
                cmd2.Parameters.AddWithValue("@r_query", ef.Query);
                cmd2.Parameters.AddWithValue("@r_time_posted", now.ToString());
                cmd2.Parameters.AddWithValue("@r_uid", ef.AppID);
                cmd2.ExecuteNonQuery();
                
                con.Close();
                
                return 0;


            }
            catch (Exception ex)
            {
                return 1;
                throw;
            }
            finally
            {
                con.Close();
                

            }
        }
    }
}
