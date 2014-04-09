using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CarsInfo;
using System.ServiceModel.Web;
using System.Collections;

// NOTE: If you change the interface name "IServiceMobile" here, you must also update the reference to "IServiceMobile" in Web.config.
[ServiceContract(Namespace = "http://microsoft.wcf.documentation", SessionMode = SessionMode.Allowed)]

public interface IServiceMobile
{
    [OperationContract]
    [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/PerformLoginMobile/{Username}/{Password}/",
    BodyStyle = WebMessageBodyStyle.WrappedResponse)]
    List<CarsInfo.UserLoginInfo> PerformLoginMobile(string Username, string Password);

    [OperationContract]
    [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetUserRegistrationDetailsByID/{UID}/",
      BodyStyle = WebMessageBodyStyle.WrappedResponse)]
    List<CarsInfo.MobileUserRegData> GetUserRegistrationDetailsByID(string UID);

   
    [OperationContract]
    [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/SalesAgentLogin/{Username}/{Password}/{CenterCode}/",
      BodyStyle = WebMessageBodyStyle.WrappedResponse)]
    List<CarsInfo.SalesInfo> SalesAgentLogin(string Username, string Password, string CenterCode);

    [OperationContract]
    [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetRecentCarsMobile/{sCurrentPage}/{PageSize}/{Orderby}/{Sort}/{sPin}/",
            BodyStyle = WebMessageBodyStyle.WrappedResponse)]
    List<UsedCarsInfo> GetRecentCarsMobile(string sCurrentPage, string PageSize, string Orderby, string Sort, string sPin);


    [OperationContract]
    [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/SaveCallRequestMobile/{BuyerPhoneNo}/{CarID}/{CustomerPhoneNo}/",
    BodyStyle = WebMessageBodyStyle.WrappedResponse)]
    bool SaveCallRequestMobile(string BuyerPhoneNo, string CarID, string CustomerPhoneNo);



    [OperationContract]
    [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/SaveBuyerRequestMobile/{BuyerEmail}/{BuyerCity}/{BuyerPhone}/{BuyerFirstName}/{BuyerLastName}/{BuyerComments}/{IpAddress}/{Sellerphone}/{Sellerprice}/{Carid}/{sYear}/{Make}/{Model}/{price}/{ToEmail}/",
    BodyStyle = WebMessageBodyStyle.WrappedResponse)]
    bool SaveBuyerRequestMobile(string BuyerEmail, string BuyerCity, string BuyerPhone, string BuyerFirstName, string BuyerLastName,
        string BuyerComments, string IpAddress, string Sellerphone, string Sellerprice, string Carid, string sYear, string Make,
        string Model, string price, string ToEmail);

    [OperationContract]
    [WebGet(BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
    ArrayList GetCarFeatures(string sCarId);


    [OperationContract]
    [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetCarsSearchJSON/{carMakeid}/{CarModalId}/{ZipCode}/{WithinZip}/{pageNo}/{pageresultscount}/{orderby}/",
        BodyStyle = WebMessageBodyStyle.WrappedResponse)]
    List<CarsInfo.UsedCarsInfo> GetCarsSearchJSON(string carMakeid, string CarModalId, string ZipCode, string WithinZip, string pageNo, string pageresultscount, string orderby);

    [OperationContract]
    [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetMakes/", BodyStyle = WebMessageBodyStyle.WrappedResponse)]
    List<MakesInfo> GetMakes();

    [OperationContract]
    [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetModelsInfo/",
        BodyStyle = WebMessageBodyStyle.WrappedResponse)]
    List<ModelsInfo> GetModelsInfo();

    [OperationContract]
    [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/GetCarsFilterMobile/{carMakeid}/{CarModalId}/{Mileage}/{Year}/{Price}/{Sort}/{Orderby}/{pageSize}/{CurrentPage}/{Zipcode}/",
            BodyStyle = WebMessageBodyStyle.WrappedResponse)]
    List<CarsInfo.UsedCarsInfo> GetCarsFilterMobile(string carMakeID, string CarModalId, string Mileage, string Year, string Price, string Sort, string Orderby, string pageSize, string CurrentPage, string Zipcode);


    [OperationContract]
    [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/FindCarID/{sCarid}/",
            BodyStyle = WebMessageBodyStyle.WrappedResponse)]
    List<CarsInfo.UsedCarsInfo> FindCarID(string sCarid);


}
