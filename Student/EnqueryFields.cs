using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTestLib
{
    public class EnqueryFields
    {
        private string _uid;
        private int _appid;
        private string _phno;
        private string _fname;
        private string _mname;
        private string _lname;
        private string _email;
        private string _state;
        private string _city;
        private string _query;

        public int AppID
        {
            get { return _appid; }
            set { _appid = value; }
        }
        public string Uid
        {
            get { return _uid; }
            set { _uid = value; }
        }
        public string Phno
        {
            get { return _phno; }
            set { _phno = value; }
        }
        public string FName
        {
            get { return _fname; }
            set { _fname = value; }
        }
        public string MName
        {
            get { return _mname; }
            set { _mname = value; }
        }
        public string LName
        {
            get { return _lname; }
            set { _lname = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        public string Query
        {
            get { return _query; }
            set { _query = value; }
        }

    }
}
