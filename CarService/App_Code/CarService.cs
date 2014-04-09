
#region System References
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Services;
using CarsInfo;
using System.Configuration;
//using CarsBL;


#endregion System References
//using CarsInfo;

#region Application References
using CarsInfo;
using CarsBL;
using CarsBL.Transactions;
using CarsBL.Masters;
using System.Web.Script.Services;
using System.Runtime.Serialization.Json;
using System.IO;
#endregion Application References
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

/// <summary>
/// Summary description for CarService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.ComponentModel.ToolboxItem(false)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class CarService : System.Web.Services.WebService
{

    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Xml)]
    [WebMethod(EnableSession = true)]
    public List<CarsInfo.UCEDealerInfo> UploadCarDetailsFromDealerSite(CarsInfo.DealerSiteCarInfo objDealerCaInfo,string Action)
    {

        var obj = new List<CarsInfo.UCEDealerInfo>();
        try
        {
            CarsBL.DealerSiteBL.UploadCarDealerSiteBL objDealerCar = new CarsBL.DealerSiteBL.UploadCarDealerSiteBL();
            if (Action == "Upload")
            {
                obj = (List<CarsInfo.UCEDealerInfo>)objDealerCar.UploadCar(objDealerCaInfo);
            }
            else
            {
                obj = (List<CarsInfo.UCEDealerInfo>)objDealerCar.UpdateCar(objDealerCaInfo);
            }
        }
        catch (Exception ex)
        {
        }
        return obj;
    }

    //Upload carFeatures from DealerSite to UCE ******(shobha)****
    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Xml)]
    [WebMethod(EnableSession = true)]
    public string UploadCarFeaturesFromDealerSite(string CarID, string FeatureNmae, string FeatureTypeName, string Isactive, string UID)
    {
        string sCarID = string.Empty;
        DataSet dsCarID = new DataSet();
        try
        {
            CarsBL.DealerSiteBL.UploadCarDealerSiteBL objDealerCar = new CarsBL.DealerSiteBL.UploadCarDealerSiteBL();
            dsCarID = objDealerCar.UploadCarFeatures(CarID, FeatureNmae, FeatureTypeName, Isactive, UID);
            if (dsCarID.Tables.Count > 0)
            {
                if (dsCarID.Tables[0].Rows.Count > 0)
                {
                    sCarID = dsCarID.Tables[0].Rows[0]["CarID"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
        }
        return sCarID;

    }

    [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Xml)]
    [WebMethod(EnableSession = true)]
    public void  UploadCarPictures(string PicFullPath, string CarID,string Make,string Model,string Year,string CarNum,string UID)
    {

       // string success = string.Empty;

        try
        {
            CarsBL.DealerSiteBL.UploadCarDealerSiteBL objCar = new CarsBL.DealerSiteBL.UploadCarDealerSiteBL();
            int Carnum = Convert.ToInt32(CarNum);
            string picNeLocation = "CarImages/" + Year + "/" + Make + "/" + Model + "/" + CarID;
            string PicFileNewName = Year + "_" + Make + "_" + Model + "_" + CarID + Carnum + ".jpg";
            string localPath = Server.MapPath("~/CarService/" + picNeLocation + "/");
          
            if (System.IO.Directory.Exists(localPath) == false)
            {
                System.IO.Directory.CreateDirectory(localPath);
            }

            string NewPicFileFullPath = localPath + PicFileNewName;
            //string localpath = "E:\\Jagadesh\\j.jpg";
            using (WebClient Client = new WebClient())
            {
                Client.DownloadFile(PicFullPath, NewPicFileFullPath);
                // Client.DownloadFile(
            }
          
            objCar.SaveCarPicturesFromDealerSite(Convert.ToInt32(CarID), picNeLocation, PicFileNewName, Convert.ToInt32(UID));
        }
        catch (Exception ex)
        {
            while (ex != null)
            {
                Console.WriteLine(ex.Message);
                ex = ex.InnerException;
            }
        }
    }

    [WebMethod(EnableSession = true)]
    public bool CheckZips(string zipId)
    {
        ZipCodesBL objZipCodesBL = new ZipCodesBL();

        List<ZipcodeDistancesInfo> objZipCode = (List<CarsInfo.ZipcodeDistancesInfo>)objZipCodesBL.GetZips(zipId);


        if (objZipCode.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}

