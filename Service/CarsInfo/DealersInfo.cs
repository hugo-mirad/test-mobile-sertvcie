using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarsInfo
{
    public class DealersInfo
    {
        private int _DealerRequestID;


        public int DealerRequestID
        {
            get { return _DealerRequestID; }
            set { _DealerRequestID = value; }
        }
        private string _DealerName;


        public string DealerName
        {
            get { return _DealerName; }
            set { _DealerName = value; }
        }
        private string _DealerPhone;


        public string DealerPhone
        {
            get { return _DealerPhone; }
            set { _DealerPhone = value; }
        }
        private string _DealerEmail;


        public string DealerEmail
        {
            get { return _DealerEmail; }
            set { _DealerEmail = value; }
        }
        private string _DealerAddress;


        public string DealerAddress
        {
            get { return _DealerAddress; }
            set { _DealerAddress = value; }
        }
        private string _DealerCity;


        public string DealerCity
        {
            get { return _DealerCity; }
            set { _DealerCity = value; }
        }
        private string _DealerShipName;


        public string DealerShipName
        {
            get { return _DealerShipName; }
            set { _DealerShipName = value; }
        }
        private string _DealerNotes;


        public string DealerNotes
        {
            get { return _DealerNotes; }
            set { _DealerNotes = value; }
        }
        private string _DealerZip;

        public string DealerZip
        {
            get { return _DealerZip; }
            set { _DealerZip = value; }
        }
    }
}
