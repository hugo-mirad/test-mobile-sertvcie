using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarsInfo
{
     public class UserLoginInfo
    {
        private string _AASuccess;

        public string AASuccess
        {
            get { return _AASuccess; }
            set { _AASuccess = value; }
        }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _UserID;

        public string UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        private string _PhoneNumber;

        public string PhoneNumber
        {
            get { return _PhoneNumber; }
            set { _PhoneNumber = value; }
        }
        private string _PackageID;

        public string PackageID
        {
            get { return _PackageID; }
            set { _PackageID = value; }
        }

        private string _UID;

        public string UID
        {
            get { return _UID; }
            set { _UID = value; }
        }

        private string _IsActive;

        public string IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }


    }
}
