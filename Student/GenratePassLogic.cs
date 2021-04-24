using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ADMLib.Student
{
    public class GenratePassLogic
    {
        public string Gen_Pass(StudLoginFields sf)
        {
            object m;
            String f=""; int x=99;
             const string strcon = "Server=localhost\\SQLEXPRESS;Database=onlineadmission;Trusted_Connection=True;";
             SqlConnection con = new SqlConnection(strcon);
            //String query = "select * from adm_tbl_personal_details where r_email=@r_email AND r_appid=@r_appid";
            try
            {

                con.Close();

                // String query1 = "insert into  adm_tbl_stud_login  (r_appid,r_password) values (@r_appid,@r_password) ";
                SqlCommand cmd1 = new SqlCommand("GenratePassword", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@r_password", CreateMD5(sf.Pass));
                cmd1.Parameters.AddWithValue("@r_appid", sf.AppID);
                cmd1.Parameters.AddWithValue("@r_email", sf.Email);
                cmd1.Parameters.Add("@rv", SqlDbType.NVarChar, 250);
                cmd1.Parameters["@rv"].Direction = ParameterDirection.Output;
                cmd1.Connection = con;
                con.Open();
                cmd1.ExecuteNonQuery();
                con.Close();
                f = cmd1.Parameters["@rv"].Value.ToString();

               // f = "10";


            }
            catch (Exception ex)
            {
                f =f+"  "+ ex.Message.ToString();
            }
            finally
            {
                con.Close();
            }
            return f;
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
