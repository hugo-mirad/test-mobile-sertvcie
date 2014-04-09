using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarsInfo
{
    public class PmntDetailsinfo
    {

        private string _TransactionID;

        public string TransactionID
        {
            get { return _TransactionID; }
            set { _TransactionID = value; }
        }
        private string _Currency;

        public string Currency
        {
            get { return _Currency; }
            set { _Currency = value; }
        }
        private int pmntType;

        public int PmntType
        {
            get { return pmntType; }
            set { pmntType = value; }
        }
        private string _cardNumber;

        public string CardNumber
        {
            get { return _cardNumber; }
            set { _cardNumber = value; }
        }
        private string _cardType;

        public string CardType
        {
            get { return _cardType; }
            set { _cardType = value; }
        }
        private string _cardExpDt;

        public string CardExpDt
        {
            get { return _cardExpDt; }
            set { _cardExpDt = value; }
        }
        private string _cardholderName;

        public string CardholderName
        {
            get { return _cardholderName; }
            set { _cardholderName = value; }
        }
        private string _cardCode;

        public string CardCode
        {
            get { return _cardCode; }
            set { _cardCode = value; }
        }
        private string _billingAdd;

        public string BillingAdd
        {
            get { return _billingAdd; }
            set { _billingAdd = value; }
        }
        private string _billingCity;

        public string BillingCity
        {
            get { return _billingCity; }
            set { _billingCity = value; }
        }
        private string _billingState;

        public string BillingState
        {
            get { return _billingState; }
            set { _billingState = value; }
        }
        private string _IPAddress;

        public string IPAddress
        {
            get { return _IPAddress; }
            set { _IPAddress = value; }
        }
        private string _bankRouting;

        public string BankRouting
        {
            get { return _bankRouting; }
            set { _bankRouting = value; }
        }
        private string _bankName;

        public string BankName
        {
            get { return _bankName; }
            set { _bankName = value; }
        }
        private string _bankAccountNumber;

        public string BankAccountNumber
        {
            get { return _bankAccountNumber; }
            set { _bankAccountNumber = value; }
        }
        private string _AuthorizationDt;

        public string AuthorizationDt
        {
            get { return _AuthorizationDt; }
            set { _AuthorizationDt = value; }
        }
        private string _Amount;

        public string Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }
        private int _pmntStatus;

        public int PmntStatus
        {
            get { return _pmntStatus; }
            set { _pmntStatus = value; }
        }
        private string _billingName;


        public string BillingName
        {
            get { return _billingName; }
            set { _billingName = value; }
        }
        private string _billingPhone;


        public string BillingPhone
        {
            get { return _billingPhone; }
            set { _billingPhone = value; }
        }
        private string _billingZip;


        public string BillingZip
        {
            get { return _billingZip; }
            set { _billingZip = value; }
        }
    }
}
