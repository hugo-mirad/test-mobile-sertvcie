using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarsInfo
{
    public class File_Info
    {

        private string _UpBatchID;

        public string UpBatchID
        {
            get { return _UpBatchID; }
            set { _UpBatchID = value; }
        }

        private string _File;

        public string File
        {
            get { return _File; }
            set { _File = value; }
        }
        private string _date;

        public string date
        {
            get { return _date; }
            set { _date = value; }
        }
        private string _uploadeddate;

        public string uploadeddate
        {
            get { return _uploadeddate; }
            set { _uploadeddate = value; }
        }
        private string _UploadedBy;

        public string UploadedBy
        {
            get { return _UploadedBy; }
            set { _UploadedBy = value; }
        }
        private string _RecordCount;

        public string RecordCount
        {
            get { return _RecordCount; }
            set { _RecordCount = value; }
        } 

    }
}
