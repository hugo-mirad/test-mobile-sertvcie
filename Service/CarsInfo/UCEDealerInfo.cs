/**********************************************************************
' MODULE       : DealerSite
' FILENAME     : UCEDealerInfo.cs
' AUTHOR       : Shobha
' CREATED      : 25-Jul-2013
' DESCRIPTION  : Info for Dealersites
'*********************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarsInfo
{
    public class UCEDealerInfo
    {

        private string _AASuccess;

        public string AASuccess
        {
            get { return _AASuccess; }
            set { _AASuccess = value; }
        }
        private int _CarID;

        public int CarID
        {
            get { return _CarID; }
            set { _CarID = value; }
        }

        private Int64 _CarUniqueID;

        public Int64 CarUniqueID
        {
            get { return _CarUniqueID; }
            set { _CarUniqueID = value; }
        }

        private int _DealerID;

        public int DealerID
        {
            get { return _DealerID; }
            set { _DealerID = value; }
        }

        private string _DealerCode;

        public string DealerCode
        {
            get { return _DealerCode; }
            set { _DealerCode = value; }
        }

        private int _UID;

        public int UID
        {
            get { return _UID; }
            set { _UID = value; }
        }

        private string _DealerInventoryID;

        public string DealerInventoryID
        {
            get { return _DealerInventoryID; }
            set { _DealerInventoryID = value; }
        }

        private string _CarStatus;

        public string CarStatus
        {
            get { return _CarStatus; }
            set { _CarStatus = value; }
        }


    }
}
