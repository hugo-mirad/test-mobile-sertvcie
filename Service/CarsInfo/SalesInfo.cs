using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarsInfo
{
    public class SalesInfo
    {
        private string _Date;

        public string Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        private string _MainCenter;

        public string MainCenter
        {
            get { return _MainCenter; }
            set { _MainCenter = value; }
        }
        private string _SalesAgentName;

        public string SalesAgentName
        {
            get { return _SalesAgentName; }
            set { _SalesAgentName = value; }
        }

        private string _AgentSalesAmount;


        public string AgentSalesAmount
        {
            get { return _AgentSalesAmount; }
            set { _AgentSalesAmount = value; }
        }

        private string _AgentSales;



        public string AgentSales
        {
            get { return _AgentSales; }
            set { _AgentSales = value; }
        }

        private string _CenterCode;

        public string CenterCode
        {
            get { return _CenterCode; }
            set { _CenterCode = value; }
        }

        private string _CenterSalesAmount;

        public string CenterSalesAmount
        {
            get { return _CenterSalesAmount; }
            set { _CenterSalesAmount = value; }
        }

        private string _CenterSalesCount;


        public string CenterSalesCount
        {
            get { return _CenterSalesCount; }
            set { _CenterSalesCount = value; }
        }

        private string _AgentID;


        public string AgentID
        {
            get { return _AgentID; }
            set { _AgentID = value; }
        }

    }
}
