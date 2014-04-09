using System;
using System.Collections.Generic;
using System.Text;

namespace CarsInfo
{[Serializable]
    public class User_log_Info
    {
        private Int64  _LogID;

        public Int64 LogID
        {
            get { return _LogID; }
            set { _LogID = value; }
        }
        private string _IPAddress;

        public string IPAddress
        {
            get { return _IPAddress; }
            set { _IPAddress = value; }
        }
        private string _Login_Date;

        public string  Login_Date
        {
            get { return _Login_Date; }
            set { _Login_Date = value; }
        }
        private int _User_ID;

        public int User_ID
        {
            get { return _User_ID; }
            set { _User_ID = value; }
        }
        private string _SessionID;

        public string SessionID
        {
            get { return _SessionID; }
            set { _SessionID = value; }
        }
        private string _CookieID;

        public string CookieID
        {
            get { return _CookieID; }
            set { _CookieID = value; }
        }
        private string _Logout_Date;

        public string Logout_Date
        {
            get { return _Logout_Date; }
            set { _Logout_Date = value; }
        }
        private int _Logout_Type_ID;

        public int Logout_Type_ID
        {
            get { return _Logout_Type_ID; }
            set { _Logout_Type_ID = value; }
        }	
	
    }
}
