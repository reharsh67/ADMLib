using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MyTestLib
{
    public class PastEduSaveLogic
    {
        public int Save_Past(PastEduFields pf)
        {
            String query1 = "inset into adm_tbl_past_edu_details (_appid,_hssctotobt,_hssctot,_hsscphymar,_hsscchemmar,_hsscmatmar,_hsscpcmtot,_cetscore,_ssctotobt,_dtotobt,_jeescore,_doverallper,_sscoverallper,_hsscpcmper,_hsscoverallper,_hsscgrade,_cetroll,_sscboard,_jeeroll,_dboard,_hsscboard) values (_appid,_hssctotobt,_hssctot,_hsscphymar,_hsscchemmar,_hsscmatmar,_hsscpcmtot,_cetscore,_ssctotobt,_dtotobt,_jeescore,_doverallper,_sscoverallper,_hsscpcmper,_hsscoverallper,_hsscgrade,_cetroll,_sscboard,_jeeroll,_dboard,_hsscboard) ";
            const string strcon = "Server=localhost\\SQLEXPRESS;Database=onlineadmission;Trusted_Connection=True;";
            SqlConnection con = new SqlConnection(strcon);
            string myMsg = "";
            try
            {

                SqlCommand cmd1 = new SqlCommand(query1, con);
                cmd1.Parameters.AddWithValue("@_appid", pf.AppID);
                cmd1.Parameters.AddWithValue("@_hsscboard", pf.HsscBoard);
                cmd1.Parameters.AddWithValue("@_hsscgrade", pf.HsscGrade);
                cmd1.Parameters.AddWithValue("@_hsscchemmar", pf.HsscChem);
                cmd1.Parameters.AddWithValue("@_hsscmatmar", pf.HsscMaths);
                cmd1.Parameters.AddWithValue("@_hsscphymar", pf.HsscPhy);
                cmd1.Parameters.AddWithValue("@_hsscoverallper", pf.HsscOverallPer);
                cmd1.Parameters.AddWithValue("@_hsscpcmper", pf.HsscPcmPer);
                cmd1.Parameters.AddWithValue("@_hsscpcmtot", pf.HsscPcmTot);
                cmd1.Parameters.AddWithValue("@_hssctot", pf.HsscTotMarks);
                cmd1.Parameters.AddWithValue("@_hssctotobt", pf.HsscTotMarksObt);
                cmd1.Parameters.AddWithValue("@_sscboard", pf.SscBoard);
                cmd1.Parameters.AddWithValue("@_sscoverallper", pf.SscOverallPer);
                cmd1.Parameters.AddWithValue("@_ssctotobt", pf.SscTotObt);
                cmd1.Parameters.AddWithValue("@_dboard", pf.DipBoard);
                cmd1.Parameters.AddWithValue("@_doverallper", pf.DipOverallPer);
                cmd1.Parameters.AddWithValue("@_dtotobt", pf.DipTotObt);
                cmd1.Parameters.AddWithValue("@_jeeroll", pf.JeeRoll);
                cmd1.Parameters.AddWithValue("@_jeescore", pf.JeeScore);
                cmd1.Parameters.AddWithValue("@_cetroll", pf.CetRoll);
                cmd1.Parameters.AddWithValue("@_cetscore", pf.CetScore);
                cmd1.Connection = con;
                con.Open();
                cmd1.ExecuteNonQuery();
                con.Close();

                return 0;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
