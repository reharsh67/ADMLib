using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADMLib.Student
{
    public class StudLoginFields
    {

        private int _appid;
        private string _pass;
        private string _email;
        private string _confirmPass;
        private string _oldpass;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Pass
        {
            get { return _pass; }
            set { _pass = value; }
        }
        public string OldPass
        {
            get { return _oldpass; }
            set { _oldpass = value; }
        }
        public string ConfirmPass
        {
            get { return _confirmPass; }
            set { _confirmPass = value; }
        }
        public int AppID
        {
            get { return _appid; }
            set { _appid = value; }
        }
    }
}
