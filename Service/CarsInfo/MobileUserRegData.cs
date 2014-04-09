using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarsInfo
{
    public class MobileUserRegData
    {
        private int _UId;

        public int UId
        {
            get { return _UId; }
            set { _UId = value; }
        }

        private string _Name;


        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _UserName;


        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
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

        private string _City;

        public string City
        {
            get { return _City; }
            set { _City = value; }
        }
        private int _StateID;


        public int StateID
        {
            get { return _StateID; }
            set { _StateID = value; }
        }
        private string _Address;


        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }private string _Zip;

        public string Zip
        {
            get { return _Zip; }
            set { _Zip = value; }
        }private string _BusinessName;

        public string BusinessName
        {
            get { return _BusinessName; }
            set { _BusinessName = value; }
        }
        private string _AltEmail;

        public string AltEmail
        {
            get { return _AltEmail; }
            set { _AltEmail = value; }
        }
        private string _AltPhone;


        public string AltPhone
        {
            get { return _AltPhone; }
            set { _AltPhone = value; }
        }
        private string _StateCode;


        public string StateCode
        {
            get { return _StateCode; }
            set { _StateCode = value; }
        }
        private string _CarIDs;


        public string CarIDs
        {
            get { return _CarIDs; }
            set { _CarIDs = value; }
        }
    }
}
