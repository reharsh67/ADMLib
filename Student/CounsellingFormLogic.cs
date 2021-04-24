using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ADMLib.Student
{
    public class CounsellingFormLogic
    {
        public string Fill_Counselling_Form(CounsellingFields ef)
        {
            object obj;string x=null;
           // String query1 = "select COUNT(*) from adm_tbl_personal_details where  r_appid=@r_appid";
            //String query3 = "insert into adm_tbl_student_counselling (r_appid,r_year,r_date,r_slot,r_mode) values (@r_appid,@r_year,@r_date,@r_slot,@r_mode) ";
            const string strcon = "Server=localhost\\SQLEXPRESS;Database=onlineadmission;Trusted_Connection=True;";
            SqlConnection con = new SqlConnection(strcon);
            string myMsg = "";
            try {
                
                    SqlCommand cmd3 = new SqlCommand("BookCounselling", con);
                    cmd3.Connection = con;
                    con.Open();
                    cmd3.Parameters.AddWithValue("@r_year", ef.Year.Trim());
                    cmd3.Parameters.AddWithValue("@r_appid", ef.AppId);
                    cmd3.Parameters.AddWithValue("@r_slot", ef.Slot);
                    cmd3.Parameters.AddWithValue("@r_mode", ef.Mode);
                    cmd3.Parameters.AddWithValue("@r_date", ef.Date);
                    cmd3.Connection = con;
                    cmd3.CommandType = CommandType.StoredProcedure;
                    cmd3.Parameters.Add("@rv", SqlDbType.NVarChar, 250);
                    cmd3.Parameters["@rv"].Direction = ParameterDirection.Output;
                    cmd3.Connection = con;
                    con.Open();
                    cmd3.ExecuteNonQuery();
                    con.Close();
                    x = cmd3.Parameters["@rv"].Value.ToString();
              
            }
            catch (Exception ex)
            {
                myMsg = ex.ToString();
                throw;
            }
            finally
            {
                con.Close();
            }
            return x;
        }
    }
}
