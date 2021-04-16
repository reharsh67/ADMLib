using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADMLib.Student
{
    public class CounsellingFields
    {
        private int _appid;
        private string _year;
        private string _date;
        private string _mode;
        private string _slot;
        private string _email;

        public int AppId
        {
            get { return _appid; }
            set { _appid = value; }
        }
        public string Year
        {
            get { return _year; }
            set { _year = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public string Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }
        public string Slot
        {
            get { return _slot; }
            set { _slot = value; }
        }
        
    }
}
