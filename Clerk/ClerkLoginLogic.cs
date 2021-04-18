using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ADMLib.Clerk
{
   public class ClerkLoginLogic
    {
        public int login(ClearkLoginFields sf)
        {
            object obj;
            const string strcon = "Server=localhost\\SQLEXPRESS;Database=onlineadmission;Trusted_Connection=True;";
            String query = "select * from adm_tbl_clerk_login where r_clerkid=@r_clerkid AND r_password=@r_password";
            SqlConnection con = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@r_password", CreateMD5(sf.Pass));
            cmd.Parameters.AddWithValue("@r_clerkid", sf.ClerkID);
            cmd.Connection = con;
            try
            {
                con.Open();
                obj = cmd.ExecuteScalar();
                if (Convert.ToInt32(obj) == 0)
                {

                    return 0;
                }
                else
                {
                    return 1;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
                cmd.Dispose();

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
