using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ADMLib.Student
{
    public class PastEduSaveLogic
    {
        public string Save_Past(PastEduFields pf)
        {
            String x = null;
            //String query1 = "inset into adm_tbl_past_edu_details (_appid,_hssctotobt,_hssctot,_hsscphymar,_hsscchemmar,_hsscmatmar,_hsscpcmtot,_cetscore,_ssctotobt,_dtotobt,_jeescore,_doverallper,_sscoverallper,_hsscpcmper,_hsscoverallper,_hsscgrade,_cetroll,_sscboard,_jeeroll,_dboard,_hsscboard) values (_appid,_hssctotobt,_hssctot,_hsscphymar,_hsscchemmar,_hsscmatmar,_hsscpcmtot,_cetscore,_ssctotobt,_dtotobt,_jeescore,_doverallper,_sscoverallper,_hsscpcmper,_hsscoverallper,_hsscgrade,_cetroll,_sscboard,_jeeroll,_dboard,_hsscboard) ";
            const string strcon = "Server=localhost\\SQLEXPRESS;Database=onlineadmission;Trusted_Connection=True;";
            SqlConnection con = new SqlConnection(strcon);
            string myMsg = "";
            try
            {

                SqlCommand cmd1 = new SqlCommand("SavePastEduDetails", con);
                cmd1.Parameters.AddWithValue("@r_appid", pf.AppID);
                cmd1.Parameters.AddWithValue("@r_hsscboard", pf.HsscBoard);
                cmd1.Parameters.AddWithValue("@r_hsscgrade", pf.HsscGrade);
                cmd1.Parameters.AddWithValue("@r_hsscchemmar", pf.HsscChem);
                cmd1.Parameters.AddWithValue("@r_hsscmatmar", pf.HsscMaths);
                cmd1.Parameters.AddWithValue("@r_hsscphymar", pf.HsscPhy);
                cmd1.Parameters.AddWithValue("@r_hsscoverallper", pf.HsscOverallPer);
                cmd1.Parameters.AddWithValue("@r_hsscpcmper", pf.HsscPcmPer);
                cmd1.Parameters.AddWithValue("@r_hsscpcmtot", pf.HsscPcmTot);
                cmd1.Parameters.AddWithValue("@r_hssctot", pf.HsscTotMarks);
                cmd1.Parameters.AddWithValue("@r_hssctotobt", pf.HsscTotMarksObt);
                cmd1.Parameters.AddWithValue("@r_sscboard", pf.SscBoard);
                cmd1.Parameters.AddWithValue("@r_sscoverallper", pf.SscOverallPer);
                cmd1.Parameters.AddWithValue("@r_ssctotobt", pf.SscTotObt);
                cmd1.Parameters.AddWithValue("@r_dboard", pf.DipBoard);
                cmd1.Parameters.AddWithValue("@r_doverallper", pf.DipOverallPer);
                cmd1.Parameters.AddWithValue("@r_dtotobt", pf.DipTotObt);
                cmd1.Parameters.AddWithValue("@r_jeeroll", pf.JeeRoll);
                cmd1.Parameters.AddWithValue("@r_jeescore", pf.JeeScore);
                cmd1.Parameters.AddWithValue("@r_cetroll", pf.CetRoll);
                cmd1.Parameters.AddWithValue("@r_cetscore", pf.CetScore);
                cmd1.Connection = con;
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Add("@rv", SqlDbType.NVarChar, 250);
                cmd1.Parameters["@rv"].Direction = ParameterDirection.Output;
                cmd1.Connection = con;
                con.Open();
                cmd1.ExecuteNonQuery();
                con.Close();
                x = cmd1.Parameters["@rv"].Value.ToString();

               
            }catch(Exception ex)
            {
                throw ex;
            }
            return x;
        }

    }
}
