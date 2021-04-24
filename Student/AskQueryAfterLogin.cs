using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ADMLib.Student
{
    public class AskQueryAfterLogin
    {

        public string Ask_Que_Again(EnqueryFields ef)
        {

            const string strcon = "Server=localhost\\SQLEXPRESS;Database=onlineadmission;Trusted_Connection=True;";
            //String query2 = "insert into adm_tbl_student_queries (r_appid,r_query,r_time_posted) values (@r_uid,@r_query,@r_time_posted)";
            string x = null;
            DateTimeOffset now = (DateTimeOffset)DateTime.UtcNow;
           SqlConnection con = new SqlConnection(strcon);
          
            try
            {
                
                SqlCommand cmd2 = new SqlCommand("SaveQuery", con);
            
                cmd2.Parameters.AddWithValue("@r_appid", ef.AppID);
                cmd2.Parameters.AddWithValue("@r_query", ef.Query);
                cmd2.Parameters.AddWithValue("@r_time_posted", now.ToString());
                cmd2.Connection = con;
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.Add("@rv", SqlDbType.NVarChar, 250);
                cmd2.Parameters["@rv"].Direction = ParameterDirection.Output;
                cmd2.Connection = con;
                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();
                x = cmd2.Parameters["@rv"].Value.ToString();

                


            }
            catch (Exception ex)
            {
                
                throw;
            }
            finally
            {
              
                

            }
            return x;
        }
    }
}
