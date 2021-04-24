using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ADMLib.Student
{
    public class StudLoginLogic
    {


        public string login(StudLoginFields sf)
        {
            object obj;
            string x = null;
            const string strcon = "Server=localhost\\SQLEXPRESS;Database=onlineadmission;Trusted_Connection=True;";
            //String query = "select * from adm_tbl_stud_login where r_appid=@r_appid AND r_password=@r_password";
            SqlConnection con = new SqlConnection(strcon);
            SqlCommand cmd1 = new SqlCommand("StudLogin", con);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@r_password", CreateMD5(sf.Pass));
            cmd1.Parameters.AddWithValue("@r_appid", sf.AppID);
            
            try
            {
                cmd1.Connection = con;
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Add("@rv", SqlDbType.NVarChar, 250);
                cmd1.Parameters["@rv"].Direction = ParameterDirection.Output;
                cmd1.Connection = con;
                con.Open();
                cmd1.ExecuteNonQuery();
                con.Close();
                x = cmd1.Parameters["@rv"].Value.ToString();
                

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
                cmd1.Dispose();
                
            }
            return x;
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
