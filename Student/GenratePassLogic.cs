using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MyTestLib
{
    public class GenratePassLogic
    {
        public int Gen_Pass(StudLoginFields sf)
        {

            object obj;
             const string strcon = "Server=localhost\\SQLEXPRESS;Database=onlineadmission;Trusted_Connection=True;";
             SqlConnection con = new SqlConnection(strcon);
            String query = "select * from adm_tbl_personal_details where r_email=@r_email AND r_appid=@r_appid";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@r_email", sf.Email);
            cmd.Parameters.AddWithValue("@r_appid", sf.AppID);
            cmd.Connection = con;
            try
            {
                con.Open();
                obj = cmd.ExecuteScalar();
                if (Convert.ToInt32(obj) == 0)
                {
                    con.Close();
                    return 0;
                }
                else
                {
                    con.Close();
                    con.Open();
                    String query1 = "insert into  adm_tbl_stud_login  (r_appid,r_password) values (@r_appid,@r_password) ";
                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    cmd1.CommandType = CommandType.Text;
                    cmd1.Parameters.AddWithValue("@r_password", CreateMD5(sf.Pass));
                    cmd1.Parameters.AddWithValue("@r_appid", sf.AppID);
                    cmd1.Connection = con;
                    cmd1.ExecuteNonQuery();
                    con.Close();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            
        }
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
