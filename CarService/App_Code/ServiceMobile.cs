using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CarsBL.Masters;
using CarsInfo;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Web;
using System.ServiceModel.Web;
using CarsBL.Transactions;
using CarsBL;
using System.Collections;
using System.Data;
using CarsBL.Dealer;


public class ServiceMobile : IServiceMobile
{
    public List<CarsInfo.UserLoginInfo> PerformLoginMobile(string Username, string Password)
    {
        MobileBL objUser = new MobileBL();
        var obj = new List<CarsInfo.UserLoginInfo>();
        try
        {
            obj = (List<CarsInfo.UserLoginInfo>)objUser.PerformLoginMobile(Username, Password);
            if (obj.Count <= 0)
            {
                CarsInfo.UserLoginInfo objinfo = new UserLoginInfo();
                objinfo.AASuccess = "Failure";
                obj.Add(objinfo);
            }
        }
        catch (Exception ex)
        {
        }

        return obj;


    }
    public List<CarsInfo.MobileUserRegData> GetUserRegistrationDetailsByID(string UID)
    {

        List<CarsInfo.MobileUserRegData> obj = new List<CarsInfo.MobileUserRegData>();

        MobileBL objReg = new MobileBL();
        try
        {
            obj = (List<CarsInfo.MobileUserRegData>)objReg.GetUSerDetailsByUserID(Convert.ToInt32(UID));
        }
        catch (Exception ex)
        {
        }
        return obj;
    }

    public List<CarsInfo.SalesInfo> SalesAgentLogin(string Username, string Password, string CenterCode)
    {
        List<SalesInfo> objSalesList = new List<SalesInfo>();
        CarsBL.Transactions.MobileBL objReg = new CarsBL.Transactions.MobileBL();
        DataSet dsGetCenterInfo = objReg.GetCenterData(CenterCode);
        if (dsGetCenterInfo.Tables.Count > 0)
        {
            if (dsGetCenterInfo.Tables[0].Rows.Count > 0)
            {
                if (dsGetCenterInfo.Tables[0].Rows[0]["AgentCenterStatus"].ToString() == "1")
                {
                    DataSet dsUserDetails = new DataSet();
                    dsUserDetails = objReg.HotLeadsPerformLogin(Username, Password, CenterCode);
                    if (dsUserDetails.Tables.Count > 0)
                    {
                        if (dsUserDetails.Tables[0].Rows.Count > 0)
                        {
                            string AgentCenterCode = dsUserDetails.Tables[0].Rows[0]["AgentCenterCode"].ToString();
                            string CenterID = dsUserDetails.Tables[0].Rows[0]["AgentCenterID"].ToString();
                            string AgentName = dsUserDetails.Tables[0].Rows[0]["AgentUFirstName"].ToString();
                            DataSet dsDatetime = objReg.GetDatetime();
                            DateTime dtNow = Convert.ToDateTime(dsDatetime.Tables[0].Rows[0]["Datetime"].ToString());
                            string Date = dtNow.ToString("MM/dd/yyyy hh:mm tt");
                            DataSet dsData = objReg.GetAllSalesByCenterForTicker(Convert.ToInt32(CenterID));
                            DataSet dsAllCenters = objReg.GetAllCenterSalesByCenterForTicker(Convert.ToInt32(CenterID));
                            int TotalSales = Convert.ToInt32(dsData.Tables[0].Compute("sum(Count)", ""));
                            Double TotalAmount = Convert.ToDouble(dsData.Tables[0].Compute("sum(TotalAmount)", ""));
                            string Totalsales = TotalSales.ToString() + " ($" + string.Format("{0:0.00}", TotalAmount).ToString() + ")";

                            if (dsData.Tables.Count > 0)
                            {
                                if (dsData.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0; i < dsData.Tables[0].Rows.Count; i++)
                                    {
                                        SalesInfo objsalesInfo = new SalesInfo();
                                        objsalesInfo.Date = Date.ToString();
                                        objsalesInfo.MainCenter = AgentCenterCode.ToString();
                                        objsalesInfo.SalesAgentName = dsData.Tables[0].Rows[i]["SaleAgent"].ToString();
                                        objsalesInfo.AgentSales = dsData.Tables[0].Rows[i]["Count"].ToString();
                                        Double AgentSalesAmount = Convert.ToDouble(dsData.Tables[0].Rows[i]["TotalAmount"].ToString());
                                        objsalesInfo.AgentSalesAmount = string.Format("{0:0.00}", AgentSalesAmount).ToString();
                                        objsalesInfo.CenterCode = AgentCenterCode.ToString();
                                        objsalesInfo.CenterSalesAmount = string.Format("{0:0.00}", TotalAmount).ToString();
                                        objsalesInfo.CenterSalesCount = TotalSales.ToString();
                                        objSalesList.Add(objsalesInfo);
                                    }
                                }
                            }
                            if (dsAllCenters.Tables.Count > 0)
                            {
                                if (dsAllCenters.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0; i < dsAllCenters.Tables[0].Rows.Count; i++)
                                    {
                                        SalesInfo objsalesInfo = new SalesInfo();
                                        objsalesInfo.Date = Date.ToString();
                                        objsalesInfo.MainCenter = AgentCenterCode.ToString();
                                        objsalesInfo.CenterCode = dsAllCenters.Tables[0].Rows[i]["Center"].ToString();
                                        Double CenterSalesAmount = Convert.ToDouble(dsAllCenters.Tables[0].Rows[i]["TotalAmount"].ToString());
                                        objsalesInfo.CenterSalesAmount = string.Format("{0:0.00}", CenterSalesAmount).ToString();
                                        objsalesInfo.CenterSalesCount = dsAllCenters.Tables[0].Rows[i]["Count"].ToString();
                                        objSalesList.Add(objsalesInfo);
                                    }
                                }
                            }

                        }
                    }
                }
            }
        }
        return objSalesList;
    }

    public List<UsedCarsInfo> GetRecentCarsMobile(string sCurrentPage, string PageSize,
          string Orderby, string Sort, string sPin)
    {

        CarsBL.Transactions.MobileData objCarsearch = new CarsBL.Transactions.MobileData();

        var obj = new List<CarsInfo.UsedCarsInfo>();

        try
        {
            obj = (List<CarsInfo.UsedCarsInfo>)objCarsearch.GetRecentCarsMobile(sCurrentPage, PageSize, Orderby, Sort, sPin);

        }
        catch (Exception ex)
        {
        }
        return obj;



    }

    public bool SaveCallRequestMobile(string BuyerPhoneNo, string CarID, string CustomerPhoneNo)
    {
        CallRequestMobileBL objCallRequestMobile = new CallRequestMobileBL();

        objCallRequestMobile.SaveCallRequestMobile(BuyerPhoneNo, CarID, CustomerPhoneNo);

        return true;
    }

    public bool SaveBuyerRequestMobile(string BuyerEmail, string BuyerCity,
          string BuyerPhone, string BuyerFirstName, string BuyerLastName, string BuyerComments,
          string IpAddress, string Sellerphone, string Sellerprice, string Carid,
           string sYear, string Make, string Model, string price, string ToEmail)
    {
        BuyerTranBL objBuyerTranBL = new BuyerTranBL();

        objBuyerTranBL.SaveBuyerRequestMobile(BuyerEmail, BuyerCity,
           BuyerPhone, BuyerFirstName, BuyerLastName, BuyerComments,
           IpAddress, Sellerphone, Sellerprice, Carid,
            sYear, Make, Model, price, "1", ToEmail);

        return true;
    }

    public ArrayList GetCarFeatures(string sCarId)
    {
        DataSet ds = new DataSet();
        CarFeatures objCarFeatures = new CarFeatures();
        ArrayList arr = new ArrayList();
        ds = objCarFeatures.GetCarFeatures(sCarId);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                arr.Add(ds.Tables[0].Rows[i]["FeatureTypeName"].ToString() + "," + ds.Tables[0].Rows[i]["FeatureName"].ToString());
            }
        }
        return arr;
    }

    public List<CarsInfo.UsedCarsInfo> GetCarsSearchJSON(string carMakeid, string CarModalId, string ZipCode, string WithinZip, string pageNo, string pageresultscount, string orderby)
    {

        CarsBL.UsedCarsSearch objCarsearch = new CarsBL.UsedCarsSearch();

        var obj = new List<CarsInfo.UsedCarsInfo>();


        string sort = string.Empty;
        if (orderby != "")
        {

            orderby = "price";
        }
        if (sort != "")
        {
            sort = "desc";
        }

        string IPAddress = string.Empty;

        string SearchName = string.Empty;


        obj = (List<CarsInfo.UsedCarsInfo>)objCarsearch.SearchUsedCars(carMakeid, CarModalId, ZipCode, WithinZip, pageNo, pageresultscount, orderby, sort);

        return obj;
    }

    public List<MakesInfo> GetMakes()
    {

        var obj = new List<MakesInfo>();


        MakesBL objMakesBL = new MakesBL();


        obj = (List<MakesInfo>)objMakesBL.GetMakes();

        return obj;

    }

    public List<ModelsInfo> GetModelsInfo()
    {
        ModelBL objModelBL = new ModelBL();

        var obj = new List<ModelsInfo>();

        obj = (List<ModelsInfo>)objModelBL.GetModels("0");

        return obj;

    }


    public List<CarsInfo.UsedCarsInfo> GetCarsFilterMobile(string carMakeID, string CarModalId,
  string Mileage, string Year, string Price, string Sort, string Orderby, string pageSize, string CurrentPage, string Zipcode)
    {

        CarsFilter objCarsFilter = new CarsFilter();


        Filter objFilter = new Filter();

        List<CarsInfo.UsedCarsInfo> objFilterdata = new List<CarsInfo.UsedCarsInfo>();


        CarsInfo.UsedCarsInfo OBJ = new CarsInfo.UsedCarsInfo();



        string sort = string.Empty;

        objCarsFilter.CurrentPage = CurrentPage;
        objCarsFilter.PageSize = pageSize;
        objCarsFilter.CarMakeid = carMakeID;
        objCarsFilter.CarModalId = CarModalId;
        objCarsFilter.Sort = Sort;
        objCarsFilter.Orderby = Orderby;
        objCarsFilter.ZipCode = Zipcode;



        objCarsFilter.Sort = sort;



        switch (Mileage)
        {
            case "Mileage1":
                objCarsFilter.Mileage1 = "Mileage1";
                break;
            case "Mileage2":
                objCarsFilter.Mileage2 = "Mileage2";
                break;
            case "Mileage3":
                objCarsFilter.Mileage3 = "Mileage3";
                break;
            case "Mileage4":
                objCarsFilter.Mileage4 = "Mileage4";
                break;
            case "Mileage5":
                objCarsFilter.Mileage5 = "Mileage5";
                break;
            case "Mileage6":
                objCarsFilter.Mileage6 = "Mileage6";
                break;
            case "Mileage7":
                objCarsFilter.Mileage7 = "Mileage7";
                break;
        }
        switch (Year)
        {
            case "Year1a":
                objCarsFilter.Year1a = "Year1a";
                break;
            case "Year1b":
                objCarsFilter.Year1b = "Year1b";
                break;
            case "Year1":
                objCarsFilter.Year1 = "Year1";
                break;
            case "Year2":
                objCarsFilter.Year2 = "Year2";
                break;
            case "Year3":
                objCarsFilter.Year3 = "Year3";
                break;
            case "Year4":
                objCarsFilter.Year4 = "Year4";
                break;
            case "Year5":
                objCarsFilter.Year5 = "Year5";
                break;
            case "Year6":
                objCarsFilter.Year6 = "Year6";
                break;
            case "Year7":
                objCarsFilter.Year7 = "Year7";
                break;
        }
        switch (Price)
        {
            case "Price1":
                objCarsFilter.Price1 = "Price1";
                break;
            case "Price2":
                objCarsFilter.Price2 = "Price2";
                break;
            case "Price3":
                objCarsFilter.Price3 = "Price3";
                break;
            case "Price4":
                objCarsFilter.Price4 = "Price4";
                break;
            case "Price5":
                objCarsFilter.Price5 = "Price5";
                break;
        };


        FilterCars objFilterCars = new FilterCars();

        objFilterdata = (List<CarsInfo.UsedCarsInfo>)objFilterCars.FilterSearchMobile(objCarsFilter);

        return objFilterdata;

    }


    public List<CarsInfo.UsedCarsInfo> FindCarID(string sCarid)
    {

        List<CarsInfo.UsedCarsInfo> obUsedCarsInfo = new List<CarsInfo.UsedCarsInfo>();
        UsedCarsSearch obj = new UsedCarsSearch();
        //if (Session["SearchCarsdata"] != null)
        //{
        //    obUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)Session["SearchCarsdata"];

        //    obUsedCarsInfo = obUsedCarsInfo.FindAll(p => p.Carid == Convert.ToInt32(sCarid));

        //    Session["SearchedData"] = obUsedCarsInfo;
        //}
        //else
        //{
        obUsedCarsInfo = (List<CarsInfo.UsedCarsInfo>)obj.FindCarID(sCarid);

        // }

        return obUsedCarsInfo;
    }
}
