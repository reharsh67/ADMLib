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
        public string Fill_Enquery_form(EnqueryFields ef)
        {
            
            
                const string strcon = "Server=localhost\\SQLEXPRESS;Database=onlineadmission;Trusted_Connection=True;";
                string myMsg = ""; object obj;
                SqlConnection con = new SqlConnection(strcon);
            //String query = "insert into adm_tbl_personal_details (r_firstname,r_middlename,r_lastname,r_mobileno,r_email,r_state,r_city)  values (@r_firstname,@r_middlename,@r_lastname,@r_phno,@r_email,@r_state,@r_city ) ";
            // String query1 = "select COUNT(*) from adm_tbl_personal_details where r_email=@r_email or r_mobileno=@r_phno";
            // string query2 = "insert into adm_tbl_student_queries (r_appid,r_query,r_time_posted) values (@r_appid,@r_query,@r_time_posted)";
            string x = null,xx;
                DateTimeOffset now = (DateTimeOffset)DateTime.UtcNow;
                try
                {
                int count=0;
                 
                        
                        SqlCommand cmd1 = new SqlCommand("SaveEnqueryDetails", con);
                        cmd1.Connection = con;
                        cmd1.Parameters.AddWithValue("@r_phno", Convert.ToInt64(ef.Phno));
                        cmd1.Parameters.AddWithValue("@r_firstname", ef.FName);
                        cmd1.Parameters.AddWithValue("@r_middlename", ef.MName);
                        cmd1.Parameters.AddWithValue("@r_lastname", ef.LName);
                        cmd1.Parameters.AddWithValue("@r_email", ef.Email);
                        cmd1.Parameters.AddWithValue("@r_state", ef.State);
                        cmd1.Parameters.AddWithValue("@r_city", ef.City);
                cmd1.Connection = con;
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Add("@rv", SqlDbType.NVarChar, 250);
                cmd1.Parameters["@rv"].Direction = ParameterDirection.Output;
                cmd1.Connection = con;
                con.Open();
                cmd1.ExecuteNonQuery();
                con.Close();
                x = cmd1.Parameters["@rv"].Value.ToString();
               

                    if (ef.Query != null)
                    {
                        SqlCommand cmd2 = new SqlCommand("SaveQuery", con);
                        cmd2.Connection = con;
                       
                        cmd2.Parameters.AddWithValue("@r_query", ef.Query);
                        cmd2.Parameters.AddWithValue("@r_time_posted", now.ToString());
                        cmd2.Parameters.AddWithValue("@r_appid", Gen_AppID()-1);
                    cmd2.Connection = con;
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Add("@rv", SqlDbType.NVarChar, 250);
                    cmd2.Parameters["@rv"].Direction = ParameterDirection.Output;
                    cmd2.Connection = con;
                    con.Open();
                    cmd2.ExecuteNonQuery();
                    con.Close();
                    xx = cmd2.Parameters["@rv"].Value.ToString();
                    x = x + " " + xx;
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
return x;
            }
        public int Gen_AppID()
        {
            int x = 0;
            try {
                
                const string strcon = "Server=localhost\\SQLEXPRESS;Database=onlineadmission;Trusted_Connection=True;";
                SqlConnection con = new SqlConnection(strcon);
                //String query = "select COUNT(*) from adm_tbl_personal_details ";
                SqlCommand cmd1 = new SqlCommand("GenApplicationId", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Add("@rv", SqlDbType.Int);
                cmd1.Parameters["@rv"].Direction = ParameterDirection.Output;
                cmd1.Connection = con;
                con.Open();
                cmd1.ExecuteNonQuery();
                con.Close();
              x = (int)cmd1.Parameters["@rv"].Value;
            }
            catch(Exception Ex)
            {
                throw Ex;
            }
            return x+1;
        }
            
        }
       
    }

