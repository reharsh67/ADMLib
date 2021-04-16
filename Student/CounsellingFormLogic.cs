using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ADMLib.Student
{
    public class CounsellingFormLogic
    {
        public int Fill_Counselling_Form(CounsellingFields ef)
        {
            object obj;
            String query1 = "select COUNT(*) from adm_tbl_personal_details where  r_appid=@r_appid";
            String query3 = "insert into adm_tbl_student_counselling (r_appid,r_year,r_date,r_slot,r_mode) values (@r_appid,@r_year,@r_date,@r_slot,@r_mode) ";
            const string strcon = "Server=localhost\\SQLEXPRESS;Database=onlineadmission;Trusted_Connection=True;";
            SqlConnection con = new SqlConnection(strcon);
            string myMsg = "";
            try {
                SqlCommand cmd1 = new SqlCommand(query1, con);
                cmd1.Parameters.AddWithValue("@r_appid", ef.AppId);
                cmd1.Connection = con;
                con.Open();
                obj = cmd1.ExecuteScalar();
                con.Close();
                if (Convert.ToInt32(obj) != 0)
                {
                    SqlCommand cmd3 = new SqlCommand(query3, con);
                    cmd3.Connection = con;
                    con.Open();
                    cmd3.Parameters.AddWithValue("@r_year", ef.Year.Trim());
                    cmd3.Parameters.AddWithValue("@r_appid", ef.AppId);
                    cmd3.Parameters.AddWithValue("@r_slot", ef.Slot);
                    cmd3.Parameters.AddWithValue("@r_mode", ef.Mode);
                    cmd3.Parameters.AddWithValue("@r_date", ef.Date);
                    cmd3.ExecuteNonQuery();
                    con.Close();
                    cmd3.Dispose();
                    return 0;
                }
                else
                {
                    return 1;
                }
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
        }
    }
}
