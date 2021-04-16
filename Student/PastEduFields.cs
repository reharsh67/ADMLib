using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADMLib.Student
{
    public class PastEduFields
    {
        private int _appid;
        private int _hssctotobt;
        private int _hssctot;
        private int _hsscphymar;
        private int _hsscchemmar;
        private int _hsscmatmar;
        private int _hsscpcmtot;
        private int _cetscore;
        private int _ssctotobt;
        private int _dtotobt;
        private int _jeescore;
        private float _doverallper;
        private float _sscoverallper;
        private float _hsscpcmper;
        private float _hsscoverallper;
        private string _hsscgrade;
        private string _cetroll;
        private string _sscboard;
        private string _jeeroll;
        private string _dboard;
        private string _hsscboard;



        public int AppID
        {
            get { return _appid; }
            set { _appid = value; }
        }
        public string HsscBoard
        {
            get { return _hsscboard; }
            set { _hsscboard = value; }
        }
        public string HsscGrade
        {
            get { return _hsscgrade; }
            set { _hsscgrade = value; }
        }
        public int HsscPhy
        {
            get { return _hsscphymar; }
            set { _hsscphymar = value; }
        }
        public int HsscChem
        {
            get { return _hsscchemmar; }
            set { _hsscchemmar = value; }
        }
        public int HsscMaths
        {
            get { return _hsscmatmar; }
            set { _hsscmatmar = value; }
        }
        public int HsscPcmTot
        {
            get { return _hsscpcmtot; }
            set { _hsscpcmtot = value; }
        }
        public int HsscTotMarksObt
        {
            get { return _hssctotobt; }
            set { _hssctotobt = value; }
        }
        public int HsscTotMarks
        {
            get { return _hssctot; }
            set { _hssctot = value; }
        }
        public float HsscPcmPer
        {
            get { return _hsscpcmper; }
            set { _hsscpcmper = value; }
        }
        public float  HsscOverallPer
        {
            get { return _hsscoverallper; }
            set { _hsscoverallper = value; }
        }



        public int SscTotObt
        {
            get { return _ssctotobt; }
            set { _ssctotobt = value; }
        }
        public string SscBoard
        {
            get { return _sscboard; }
            set { _sscboard = value; }
        }
        public float SscOverallPer
        {
            get { return _sscoverallper; }
            set { _sscoverallper = value; }
        }

        public int DipTotObt
        {
            get { return _dtotobt; }
            set { _dtotobt = value; }
        }
        public string DipBoard
        {
            get { return _dboard; }
            set { _dboard = value; }
        }
        public float DipOverallPer
        {
            get { return _doverallper; }
            set { _doverallper = value; }
        }

        public int JeeScore
        {
            get { return _jeescore; }
            set { _jeescore = value; }
        }
        public string JeeRoll
        {
            get { return _jeeroll; }
            set { _jeeroll = value; }
        }
        
        public int CetScore
        {
            get { return _cetscore; }
            set { _cetscore = value; }
        }
        public string CetRoll
        {
            get { return _cetroll; }
            set { _cetroll = value; }
        }
 }
}
