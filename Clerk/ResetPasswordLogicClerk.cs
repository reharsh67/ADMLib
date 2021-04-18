using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ADMLib.Clerk
{
    public class ResetPasswordLogicClerk
    {

        public int PassReset(ClearkLoginFields sf)
        {

            object obj;
            const string strcon = "Server=localhost\\SQLEXPRESS;Database=onlineadmission;Trusted_Connection=True;";
            SqlConnection con = new SqlConnection(strcon);
            String query = "select * from adm_tbl_clerk_login where  r_appid=@r_clerkid";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@r_clerkid", sf.ClerkID);
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
                    String query1 = "update  adm_tbl_clerk_login set r_password=@r_password where r_clerkid=@r_clerkid";
                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    cmd1.CommandType = CommandType.Text;
                    cmd1.Parameters.AddWithValue("@r_password", CreateMD5(sf.Pass));
                    cmd1.Parameters.AddWithValue("@r_clerkid", sf.ClerkID);
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
