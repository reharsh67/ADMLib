using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ADMLib.Student
{
    public class UploadDocumentLogic
    {

        public string upload(DocumentFields ef)
        {
            string x = null;

            const string strcon = "Server=localhost\\SQLEXPRESS;Database=onlineadmission;Trusted_Connection=True;";
            SqlConnection con = new SqlConnection(strcon);
            SqlCommand cmd1 = new SqlCommand("UploadDocuments", con);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@r_appid", ef.AppID);
            cmd1.Parameters.AddWithValue("@r_docid", ef.DocID);
            cmd1.Parameters.AddWithValue("@r_docurl", ef.DocPath);
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
                throw ex;
            }
            finally
            {
                con.Close();
                

            }
           



            return x;

        }
        public DataSet Pre_Fill()
        {
            //ARFFormFields emf = new ARFFormFields();
            object obj;
            //  String query1 = "select * from adm_tbl_personal_details where r_appid=@r_appid";

            const string strcon = "Server=localhost\\SQLEXPRESS;Database=onlineadmission;Trusted_Connection=True;";
            SqlConnection con = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand("ListDocuments", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //DataTable dt = new DataTable { TableName = "MyTable" };
            
            cmd.Connection = con;
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                cmd.Dispose();

            }
            return ds;
        }


    }
}
