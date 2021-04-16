using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MyTestLib
{
    public class ARFFillingLogic
    {
        public DataTable Pre_Fill(ARFFormFields ef)
        {
            ARFFormFields emf = new ARFFormFields();
            object obj;
            String query1 = "select * from adm_tbl_personal_details where r_appid=@r_appid";
            DataTable dt = new DataTable { TableName = "MyTable" };
            const string strcon = "Server=localhost\\SQLEXPRESS;Database=onlineadmission;Trusted_Connection=True;";
            SqlConnection con = new SqlConnection(strcon);
            try
            {
                SqlCommand cmd1 = new SqlCommand(query1, con);
                cmd1.Parameters.AddWithValue("@r_appid", ef.AppID);
                cmd1.Connection = con;
                con.Open();
                SqlDataReader dr = cmd1.ExecuteReader(CommandBehavior.CloseConnection);
                dt.Load(dr);
                con.Close();
            }
            catch(Exception ex)
            {

            }
            return dt;
        }
        public int ARF_Fill_Logic(ARFFormFields ef)
        {
            ARFFormFields emf = new ARFFormFields();
            object obj;
            String query1 = "update  adm_tbl_personal_details set r_dob=@r_dob,r_gender=@r_gender,r_study_year=@r_study_year,r_admission_type=@r_admission_type,r_academic_yr=@r_academic_yr,r_fathername=@r_fathername,r_fathermobile=@r_fathermobile,r_fatheroccupation=@r_fatheroccupation,r_motherfname=@r_mothername,r_mothermobile=@r_mothermobile,r_motheroccupation=@r_motheroccupation,r_income=@r_income,r_cast=@r_cast,r_relegion=@r_religion,r_address_line_1=@r_address_line_1,r_address_line_2=@r_address_line_2,r_address_line_3=@r_address_line_3 where r_appid=@r_appid";
            const string strcon = "Server=localhost\\SQLEXPRESS;Database=onlineadmission;Trusted_Connection=True;";
            SqlConnection con = new SqlConnection(strcon);
            try
            {
                SqlCommand cmd1 = new SqlCommand(query1, con);
                cmd1.Parameters.AddWithValue("@r_appid", ef.AppID);
                cmd1.Parameters.AddWithValue("@r_dob", ef.DOB);
                cmd1.Parameters.AddWithValue("@r_gender", ef.Gender);
                cmd1.Parameters.AddWithValue("@r_study_year", ef.AdmissionIn);
                cmd1.Parameters.AddWithValue("@r_admission_type", ef.AdmissionType);
                cmd1.Parameters.AddWithValue("@r_academic_yr", ef.AcademicYear);
                cmd1.Parameters.AddWithValue("@r_fathername", ef.FaName);
                cmd1.Parameters.AddWithValue("@r_fathermobile", ef.FaPhno);
                cmd1.Parameters.AddWithValue("@r_fatheroccupation", ef.FaWork);
                cmd1.Parameters.AddWithValue("@r_mothername", ef.MoName);
                cmd1.Parameters.AddWithValue("@r_mothermobile", ef.MoPhno);
                cmd1.Parameters.AddWithValue("@r_motheroccupation", ef.MoWork);
                cmd1.Parameters.AddWithValue("@r_income", ef.Income);
                cmd1.Parameters.AddWithValue("@r_cast", ef.Cast);
                cmd1.Parameters.AddWithValue("@r_religion", ef.Religion);
                cmd1.Parameters.AddWithValue("@r_address_line_1", ef.AddLine1);
                cmd1.Parameters.AddWithValue("@r_address_line_2", ef.AddLine2);
                cmd1.Parameters.AddWithValue("@r_address_line_3", ef.AddLine3);
                cmd1.Connection = con;
                con.Open();
                cmd1.ExecuteNonQuery();
                con.Close();
                
            }
            catch(Exception ex)
            {
                throw ex;
            }


                return 0;
        }

    }
}
