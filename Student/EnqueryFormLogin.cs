using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ADMLib.Student
{
    public class EnqueryFormLogin
    {
        public int Fill_Enquery_form(EnqueryFields ef)
        {
            
            
                const string strcon = "Server=localhost\\SQLEXPRESS;Database=onlineadmission;Trusted_Connection=True;";
                string myMsg = ""; object obj;
                SqlConnection con = new SqlConnection(strcon);
                String query = "insert into adm_tbl_personal_details (r_firstname,r_middlename,r_lastname,r_mobileno,r_email,r_state,r_city)  values (@r_firstname,@r_middlename,@r_lastname,@r_phno,@r_email,@r_state,@r_city ) ";
                String query1 = "select COUNT(*) from adm_tbl_personal_details where r_email=@r_email or r_mobileno=@r_phno";
                string query2 = "insert into adm_tbl_student_queries (r_appid,r_query,r_time_posted) values (@r_appid,@r_query,@r_time_posted)";
            int x = 0;
                DateTimeOffset now = (DateTimeOffset)DateTime.UtcNow;
                try
                {
                int count=0;
                    SqlCommand cmd = new SqlCommand(query1, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@r_phno", Convert.ToInt64(ef.Phno));
                    cmd.Parameters.AddWithValue("@r_email", ef.Email);
                    cmd.Connection = con;
                    con.Open();
                    obj = cmd.ExecuteScalar();
                    con.Close();
                    if (Convert.ToInt32(obj) != 0)
                    {

                    return x;
                        

                    }
                    else
                    {
                        con.Open();
                        SqlCommand cmd1 = new SqlCommand(query, con);
                        cmd1.Connection = con;
                        cmd1.Parameters.AddWithValue("@r_phno", Convert.ToInt64(ef.Phno));
                        cmd1.Parameters.AddWithValue("@r_firstname", ef.FName);
                        cmd1.Parameters.AddWithValue("@r_middlename", ef.MName);
                        cmd1.Parameters.AddWithValue("@r_lastname", ef.LName);
                        cmd1.Parameters.AddWithValue("@r_email", ef.Email);
                        cmd1.Parameters.AddWithValue("@r_state", ef.State);
                        cmd1.Parameters.AddWithValue("@r_city", ef.City);
                        cmd1.ExecuteNonQuery();
                        con.Close();
                    x++;

                    if (ef.Query != null)
                    {
                        SqlCommand cmd2 = new SqlCommand(query2, con);
                        cmd2.Connection = con;
                        con.Open();
                        cmd2.Parameters.AddWithValue("@r_query", ef.Query);
                        cmd2.Parameters.AddWithValue("@r_time_posted", now.ToString());
                        cmd2.Parameters.AddWithValue("@r_appid", count);
                        cmd2.ExecuteNonQuery();
                        con.Close();
                        x++;

                    }



                }

                return x;

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
        public int Gen_AppID()
        {
            try {
                int x = 0;
                const string strcon = "Server=localhost\\SQLEXPRESS;Database=onlineadmission;Trusted_Connection=True;";
                SqlConnection con = new SqlConnection(strcon);
                String query = "select COUNT(*) from adm_tbl_personal_details ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Connection = con;
                con.Open();
                x = Convert.ToInt16(cmd.ExecuteScalar());
                return x;
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
        }
            
        }
       
    }

