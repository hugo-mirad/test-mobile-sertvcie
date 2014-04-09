
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarsInfo
{
    public class NewCarsInfo
    {
        private int _NewCarRequestID;


        public int NewCarRequestID
        {
            get { return _NewCarRequestID; }
            set { _NewCarRequestID = value; }
        }
        private string _NewCarRequestName;


        public string NewCarRequestName
        {
            get { return _NewCarRequestName; }
            set { _NewCarRequestName = value; }
        }
        private string _NewCarReqPhoneNumber;


        public string NewCarReqPhoneNumber
        {
            get { return _NewCarReqPhoneNumber; }
            set { _NewCarReqPhoneNumber = value; }
        }
        private string _NewCarReqEmail;


        public string NewCarReqEmail
        {
            get { return _NewCarReqEmail; }
            set { _NewCarReqEmail = value; }
        }
    }
}
