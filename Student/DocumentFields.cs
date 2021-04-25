using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADMLib.Student
{
    public class DocumentFields
    {
        private string _docname;
        private int _docid;
        private int _appid;
        private string _docpath;



        public string DocName
        {
            get { return _docname; }
            set { _docname = value; }
        }
        public int AppID
        {
            get { return _appid; }
            set { _appid = value; }
        }
        public int DocID
        {
            get { return _docid; }
            set { _docid = value; }
        }
        public string DocPath
        {
            get { return _docpath; }
            set { _docpath = value; }
        }
    }
}
