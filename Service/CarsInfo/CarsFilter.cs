using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarsInfo
{
    public class CarsFilter
    {
        private string _carMakeid;

        public string CarMakeid
        {
            get { return _carMakeid; }
            set { _carMakeid = value; }
        }
        private string _CarModalId;

        public string CarModalId
        {
            get { return _CarModalId; }
            set { _CarModalId = value; }
        }
        private string _WithinZip;

        public string WithinZip
        {
            get { return _WithinZip; }
            set { _WithinZip = value; }
        }
        private string _ZipCode;

        public string ZipCode
        {
            get { return _ZipCode; }
            set { _ZipCode = value; }
        }
        private string _currentPage;

        public string CurrentPage
        {
            get { return _currentPage; }
            set { _currentPage = value; }
        }

        private string _Orderby;

        public string Orderby
        {
            get { return _Orderby; }
            set { _Orderby = value; }
        }
        private string _sort;

        public string Sort
        {
            get { return _sort; }
            set { _sort = value; }
        }
        private string _pageSize;

        public string PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }       

        private string _Mileage1;

        public string Mileage1
        {
            get { return _Mileage1; }
            set { _Mileage1 = value; }
        }
        private string _Mileage2;

        public string Mileage2
        {
            get { return _Mileage2; }
            set { _Mileage2 = value; }
        }
        private string _Mileage3;

        public string Mileage3
        {
            get { return _Mileage3; }
            set { _Mileage3 = value; }
        }
        private string _Mileage4;

        public string Mileage4
        {
            get { return _Mileage4; }
            set { _Mileage4 = value; }
        }
        private string _Mileage5;

        public string Mileage5
        {
            get { return _Mileage5; }
            set { _Mileage5 = value; }
        }
        private string _Mileage6;

        public string Mileage6
        {
            get { return _Mileage6; }
            set { _Mileage6 = value; }
        }
        private string _Mileage7;

        public string Mileage7
        {
            get { return _Mileage7; }
            set { _Mileage7 = value; }
        }
        private string _Year1a;

        public string Year1a
        {
            get { return _Year1a; }
            set { _Year1a = value; }
        }
        private string _Year1b;

        public string Year1b
        {
            get { return _Year1b; }
            set { _Year1b = value; }
        }
        private string _Year1;

        public string Year1
        {
            get { return _Year1; }
            set { _Year1 = value; }
        }
        private string _Year2;

        public string Year2
        {
            get { return _Year2; }
            set { _Year2 = value; }
        }
        private string _Year3;

        public string Year3
        {
            get { return _Year3; }
            set { _Year3 = value; }
        }
        private string _Year4;

        public string Year4
        {
            get { return _Year4; }
            set { _Year4 = value; }
        }
        private string _Year5;

        public string Year5
        {
            get { return _Year5; }
            set { _Year5 = value; }
        }
        private string _Year6;

        public string Year6
        {
            get { return _Year6; }
            set { _Year6 = value; }
        }
        private string _Year7;

        public string Year7
        {
            get { return _Year7; }
            set { _Year7 = value; }
        }
        private string _Price1;

        public string Price1
        {
            get { return _Price1; }
            set { _Price1 = value; }
        }
        private string _Price2;

        public string Price2
        {
            get { return _Price2; }
            set { _Price2 = value; }
        }
        private string _Price3;

        public string Price3
        {
            get { return _Price3; }
            set { _Price3 = value; }
        }
        private string _Price4;

        public string Price4
        {
            get { return _Price4; }
            set { _Price4 = value; }
        }
        private string _Price5;

        public string Price5
        {
            get { return _Price5; }
            set { _Price5 = value; }
        }
        private string _Body1;

        public string Body1
        {
            get { return _Body1; }
            set { _Body1 = value; }
        }
        private string _Body2;

        public string Body2
        {
            get { return _Body2; }
            set { _Body2 = value; }
        }
        private string _Body3;

        public string Body3
        {
            get { return _Body3; }
            set { _Body3 = value; }
        }
        private string _Body4;

        public string Body4
        {
            get { return _Body4; }
            set { _Body4 = value; }
        }
        private string _Body5;

        public string Body5
        {
            get { return _Body5; }
            set { _Body5 = value; }
        }
        private string _Body6;

        public string Body6
        {
            get { return _Body6; }
            set { _Body6 = value; }
        }
        private string _Body7;

        public string Body7
        {
            get { return _Body7; }
            set { _Body7 = value; }
        }
        private string _Body8;

        public string Body8
        {
            get { return _Body8; }
            set { _Body8 = value; }
        }
        private string _Body9;

        public string Body9
        {
            get { return _Body9; }
            set { _Body9 = value; }
        }
        private string _Fuel1;

        public string Fuel1
        {
            get { return _Fuel1; }
            set { _Fuel1 = value; }
        }
        private string _Fuel2;

        public string Fuel2
        {
            get { return _Fuel2; }
            set { _Fuel2 = value; }
        }
        private string _Fuel3;

        public string Fuel3
        {
            get { return _Fuel3; }
            set { _Fuel3 = value; }
        }
        private string _Fuel4;

        public string Fuel4
        {
            get { return _Fuel4; }
            set { _Fuel4 = value; }
        }
        private string _Fuel5;

        public string Fuel5
        {
            get { return _Fuel5; }
            set { _Fuel5 = value; }
        }
        private string _Seller1;

        public string Seller1
        {
            get { return _Seller1; }
            set { _Seller1 = value; }
        }
        private string _Seller2;

        public string Seller2
        {
            get { return _Seller2; }
            set { _Seller2 = value; }
        }
        private bool _withPic;

        public bool WithPic
        {
            get { return _withPic; }
            set { _withPic = value; }
        }
    }
}
