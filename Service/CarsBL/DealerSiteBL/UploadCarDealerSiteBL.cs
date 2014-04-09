/**********************************************************************
' MODULE       : DealerSite
' FILENAME     : UceDealerSite.cs
' AUTHOR       : Shobha
' CREATED      : 25-Jul-2013
' DESCRIPTION  : Business Logic to upload the car details into UCE from DealerSites.
'*********************************************************************/

#region System References
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Linq;

#endregion System References

#region Application References
using CarsInfo;
#endregion Application References

#region Microsoft Application Block References
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using CarsBL.Transactions;
using System.Web.Caching;
#endregion Microsoft Application Block References


namespace CarsBL.DealerSiteBL
{
    public class UploadCarDealerSiteBL
    {
        public List<UCEDealerInfo> UploadCar(DealerSiteCarInfo objCarInfo)
        {
            var objList = new List<UCEDealerInfo>();
            try
            {
                string DealerCode = objCarInfo.DealerCode.ToString().Trim();
                string UserName = objCarInfo.DealerEmailID.ToString().Trim();
                string Password = objCarInfo.DealerPwd.ToString().Trim();
                string UID = string.Empty;

                UCEDealerSiteBL objDealer = new UCEDealerSiteBL();
                DataSet dsDealer = objDealer.PerformLoginIntoUCE(UserName, DealerCode, Password);
                if (dsDealer.Tables.Count > 0)
                {
                    if (dsDealer.Tables[0].Rows.Count > 0)
                    {
                        //CarsBL.Dealer.DealerActions objActions = new CarsBL.Dealer.DealerActions();
                        UID = dsDealer.Tables[0].Rows[0]["UID"].ToString();
                        DealerCode = dsDealer.Tables[0].Rows[0]["DealerCode"].ToString();
                        DataSet dsCheckUser = objDealer.DealerCheckUniqueID(objCarInfo.DealerInventoryID, DealerCode);
                        if (dsCheckUser.Tables[0].Rows.Count > 0)
                        {
                            UCEDealerInfo objInfo = new UCEDealerInfo();
                            objInfo.AASuccess = "8002:DealerInventory ID is existed";
                            objInfo.DealerCode = DealerCode;
                            objInfo.UID = Convert.ToInt32(UID);
                            objList.Add(objInfo);
                        }
                        else
                        {
                            DataSet ds = objDealer.SaveCarDetailsToUCE(objCarInfo, UID);
                            if (ds.Tables.Count > 0)
                            {
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    UCEDealerInfo objDealerCarInfo = new UCEDealerInfo();
                                    objDealerCarInfo.AASuccess = "8000:Car details updated successfully";
                                    objDealerCarInfo.CarID = Convert.ToInt32(ds.Tables[0].Rows[0]["carID"].ToString());
                                    objDealerCarInfo.CarUniqueID = Convert.ToInt64(ds.Tables[0].Rows[0]["CarUniqueID"].ToString());
                                    objDealerCarInfo.DealerCode = ds.Tables[0].Rows[0]["DealerCode"].ToString();
                                    objDealerCarInfo.DealerInventoryID = ds.Tables[0].Rows[0]["DealerUniqueID"].ToString();
                                    objDealerCarInfo.CarStatus = ds.Tables[0].Rows[0]["Adstatus"].ToString();
                                    objDealerCarInfo.UID = Convert.ToInt32(UID);
                                    objList.Add(objDealerCarInfo);
                                }
                                else
                                {
                                    UCEDealerInfo objDealerCarInfo = new UCEDealerInfo();
                                    objDealerCarInfo.AASuccess = "8003:Car details not updated successfully";
                                    objDealerCarInfo.DealerCode = DealerCode;
                                    objDealerCarInfo.UID = Convert.ToInt32(UID);
                                    objList.Add(objDealerCarInfo);

                                }

                            }
                            else
                            {
                                UCEDealerInfo objDealerCarInfo = new UCEDealerInfo();
                                objDealerCarInfo.AASuccess = "8003:Car details not updated successfully";
                                objDealerCarInfo.DealerCode = DealerCode;
                                objDealerCarInfo.UID = Convert.ToInt32(UID);
                                objList.Add(objDealerCarInfo);
                            }

                        }

                    }
                    else
                    {
                        UCEDealerInfo objInfo = new UCEDealerInfo();
                        objInfo.AASuccess = "8001:DealerCode,Username,password not existed";
                        objInfo.DealerCode = DealerCode;
                        objList.Add(objInfo);
                    }
                }
                else
                {
                    UCEDealerInfo objInfo = new UCEDealerInfo();
                    objInfo.AASuccess = "8001:DealerCode,Username,password not existed";
                    objInfo.DealerCode = DealerCode;
                    objList.Add(objInfo);
                }


            }
            catch (Exception ex)
            {
            }
            return objList;
        }

        public DataSet UploadCarFeatures(string CarID, string FeatureName, string FeatureTypeName, string Isactive, string UID)
        {
            DataSet ds = new DataSet();
            string spNameString = string.Empty;

            //objUsedCars.Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.CarsConnTest);


            spNameString = "[USP_SaveCarFeaturesFromDealerSite]";
            DbCommand dbCommand = null;

            try
            {
                //objUsedCars.Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbCommand.CommandTimeout = 10000;

                dbDatabase.AddInParameter(dbCommand, "@CarID", DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@FeatureName", DbType.String, FeatureName);
                dbDatabase.AddInParameter(dbCommand, "@FeatureTypeName", DbType.String, FeatureTypeName);
                dbDatabase.AddInParameter(dbCommand, "@IsActive", DbType.Boolean, Isactive);
                dbDatabase.AddInParameter(dbCommand, "@TranBy", DbType.Int32, UID);

                //objUsedCars.Executing stored procedure
                ds = dbDatabase.ExecuteDataSet(dbCommand);
                // DataSet  ds =dbDatabase.ExecuteDataSet(dbCommand);

            }
            catch (Exception ex)
            {

            }
            finally
            {

            }

            return ds;
        }

        public void SaveCarPicturesFromDealerSite(int CarID, string PicLocation, string PicName, int UserID)
        {
            UCEDealerSiteBL objDealer = new UCEDealerSiteBL();
            UsedCarsInfo objCarPicInfo = new UsedCarsInfo();
            Dealer.DealerActions objAction = new CarsBL.Dealer.DealerActions();
            string bSuccess = string.Empty;
            try
            {
                DataSet ds = objDealer.GetCarImageIDsToDealerSite(CarID);
                objCarPicInfo.Carid = Convert.ToInt32(CarID);
                string picId = objDealer.SaveCarPictureFromDealerSite(PicLocation, PicName, UserID);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objCarPicInfo.PIC0 = ds.Tables[0].Rows[0]["pic0"].ToString() == "" ? null : ds.Tables[0].Rows[0]["pic0"].ToString();
                        objCarPicInfo.PIC1 = ds.Tables[0].Rows[0]["pic1"].ToString() == "" ? null : ds.Tables[0].Rows[0]["pic1"].ToString();
                        objCarPicInfo.PIC2 = ds.Tables[0].Rows[0]["pic2"].ToString() == "" ? null: ds.Tables[0].Rows[0]["pic2"].ToString();
                        objCarPicInfo.PIC3 = ds.Tables[0].Rows[0]["pic3"].ToString() == "" ? null : ds.Tables[0].Rows[0]["pic3"].ToString();
                        objCarPicInfo.PIC4 = ds.Tables[0].Rows[0]["pic4"].ToString() == "" ? null : ds.Tables[0].Rows[0]["pic4"].ToString();
                        objCarPicInfo.PIC5 = ds.Tables[0].Rows[0]["pic5"].ToString() == "" ? null : ds.Tables[0].Rows[0]["pic5"].ToString();
                        objCarPicInfo.PIC6 = ds.Tables[0].Rows[0]["pic6"].ToString() == "" ? null : ds.Tables[0].Rows[0]["pic6"].ToString();
                        objCarPicInfo.PIC7 = ds.Tables[0].Rows[0]["pic7"].ToString() == "" ? null : ds.Tables[0].Rows[0]["pic7"].ToString();
                        objCarPicInfo.PIC8 = ds.Tables[0].Rows[0]["pic8"].ToString() == "" ? null : ds.Tables[0].Rows[0]["pic8"].ToString();
                        objCarPicInfo.PIC9 = ds.Tables[0].Rows[0]["pic9"].ToString() == "" ? null : ds.Tables[0].Rows[0]["pic9"].ToString();
                        objCarPicInfo.PIC10 = ds.Tables[0].Rows[0]["pic10"].ToString() == "" ? null : ds.Tables[0].Rows[0]["pic10"].ToString();
                        objCarPicInfo.PIC11 = ds.Tables[0].Rows[0]["pic11"].ToString() == "" ? null : ds.Tables[0].Rows[0]["pic11"].ToString();
                        objCarPicInfo.PIC12 = ds.Tables[0].Rows[0]["pic12"].ToString() == "" ? null : ds.Tables[0].Rows[0]["pic12"].ToString();
                        objCarPicInfo.PIC13 = ds.Tables[0].Rows[0]["pic13"].ToString() == "" ? null : ds.Tables[0].Rows[0]["pic13"].ToString();
                        objCarPicInfo.PIC14 = ds.Tables[0].Rows[0]["pic14"].ToString() == "" ? null : ds.Tables[0].Rows[0]["pic14"].ToString();
                        objCarPicInfo.PIC15 = ds.Tables[0].Rows[0]["pic15"].ToString() == "" ? null : ds.Tables[0].Rows[0]["pic15"].ToString();
                        objCarPicInfo.PIC16 = ds.Tables[0].Rows[0]["pic16"].ToString() == "" ? null : ds.Tables[0].Rows[0]["pic16"].ToString();
                        objCarPicInfo.PIC17 = ds.Tables[0].Rows[0]["pic17"].ToString() == "" ? null : ds.Tables[0].Rows[0]["pic17"].ToString();
                        objCarPicInfo.PIC18 = ds.Tables[0].Rows[0]["pic18"].ToString() == "" ? null : ds.Tables[0].Rows[0]["pic18"].ToString();
                        objCarPicInfo.PIC19 = ds.Tables[0].Rows[0]["pic19"].ToString() == "" ? null : ds.Tables[0].Rows[0]["pic19"].ToString();
                        objCarPicInfo.PIC20 = ds.Tables[0].Rows[0]["pic20"].ToString() == "" ? null : ds.Tables[0].Rows[0]["pic20"].ToString();

                        if (objCarPicInfo.PIC0 == null || objCarPicInfo.PIC0 == "")
                        {
                            objCarPicInfo.PIC0 = picId;
                        }
                        else if (objCarPicInfo.PIC1 == null || objCarPicInfo.PIC1 == "")
                        {
                            objCarPicInfo.PIC1 = picId;
                        }
                        else if (objCarPicInfo.PIC2 == null || objCarPicInfo.PIC2 == "")
                        {
                            objCarPicInfo.PIC2 = picId;
                        }
                        else if (objCarPicInfo.PIC3 == null || objCarPicInfo.PIC3 == "")
                        {
                            objCarPicInfo.PIC3 = picId;

                        }
                        else if (objCarPicInfo.PIC4 == null || objCarPicInfo.PIC4 == "")
                        {
                            objCarPicInfo.PIC4 = picId;
                        }
                        else if (objCarPicInfo.PIC5 == null || objCarPicInfo.PIC5 == "")
                        {
                            objCarPicInfo.PIC5 = picId;
                        }
                        else if (objCarPicInfo.PIC6 == null || objCarPicInfo.PIC6 == "")
                        {
                            objCarPicInfo.PIC6 = picId;
                        }
                        else if (objCarPicInfo.PIC7 == null || objCarPicInfo.PIC7 == "")
                        {
                            objCarPicInfo.PIC7 = picId;
                        }
                        else if (objCarPicInfo.PIC8 == null || objCarPicInfo.PIC8 == "")
                        {
                            objCarPicInfo.PIC8 = picId;
                        }
                        else if (objCarPicInfo.PIC9 == null || objCarPicInfo.PIC9 == "")
                        {
                            objCarPicInfo.PIC9 = picId;
                        }
                        else if (objCarPicInfo.PIC10 == null || objCarPicInfo.PIC10 == "")
                        {
                            objCarPicInfo.PIC10 = picId;
                        }
                        else if (objCarPicInfo.PIC11 == null || objCarPicInfo.PIC11 == "")
                        {
                            objCarPicInfo.PIC11 = picId;
                        }
                        else if (objCarPicInfo.PIC12 == null || objCarPicInfo.PIC12 == "")
                        {
                            objCarPicInfo.PIC12 = picId;
                        }
                        else if (objCarPicInfo.PIC13 == null || objCarPicInfo.PIC13 == "")
                        {
                            objCarPicInfo.PIC13 = picId;
                        }
                        else if (objCarPicInfo.PIC14 == null || objCarPicInfo.PIC14 == "")
                        {
                            objCarPicInfo.PIC14 = picId;
                        }
                        else if (objCarPicInfo.PIC15 == null || objCarPicInfo.PIC15 == "")
                        {
                            objCarPicInfo.PIC15 = picId;
                        }
                        else if (objCarPicInfo.PIC16 == null || objCarPicInfo.PIC16 == "")
                        {
                            objCarPicInfo.PIC16 = picId;
                        }
                        else if (objCarPicInfo.PIC17 == null || objCarPicInfo.PIC17 == "")
                        {
                            objCarPicInfo.PIC17 = picId;
                        }
                        else if (objCarPicInfo.PIC18 == null || objCarPicInfo.PIC18 == "")
                        {
                            objCarPicInfo.PIC18 = picId;
                        }
                        else if (objCarPicInfo.PIC19 == null || objCarPicInfo.PIC19 == "")
                        {
                            objCarPicInfo.PIC19 = picId;
                        }
                        else if (objCarPicInfo.PIC20 == null || objCarPicInfo.PIC19 == "")
                        {
                            objCarPicInfo.PIC20 = picId;
                        }

                        objDealer.UpdatePicturesByIdFromDealerSite(objCarPicInfo, UserID);

                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public List<UCEDealerInfo> UpdateCar(DealerSiteCarInfo objCarInfo)
        {
            var objList = new List<UCEDealerInfo>();
            try
            {
                string DealerCode = objCarInfo.DealerCode.ToString().Trim();
                string UserName = objCarInfo.DealerEmailID.ToString().Trim();
                string Password = objCarInfo.DealerPwd.ToString().Trim();
                string UID = string.Empty;

                UCEDealerSiteBL objDealer = new UCEDealerSiteBL();
                DataSet dsDealer = objDealer.PerformLoginIntoUCE(UserName, DealerCode, Password);
                if (dsDealer.Tables.Count > 0)
                {
                    if (dsDealer.Tables[0].Rows.Count > 0)
                    {
                        //CarsBL.Dealer.DealerActions objActions = new CarsBL.Dealer.DealerActions();
                        UID = dsDealer.Tables[0].Rows[0]["UID"].ToString();
                        DealerCode = dsDealer.Tables[0].Rows[0]["DealerCode"].ToString();
                        DataSet ds = objDealer.SaveCarDetailsToUCE(objCarInfo, UID);
                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                UCEDealerInfo objDealerCarInfo = new UCEDealerInfo();
                                objDealerCarInfo.AASuccess = "8000:Car details updated successfully";
                                objDealerCarInfo.CarID = Convert.ToInt32(ds.Tables[0].Rows[0]["carID"].ToString());
                                objDealerCarInfo.CarUniqueID = Convert.ToInt64(ds.Tables[0].Rows[0]["CarUniqueID"].ToString());
                                objDealerCarInfo.DealerCode = ds.Tables[0].Rows[0]["DealerCode"].ToString();
                                objDealerCarInfo.DealerInventoryID = ds.Tables[0].Rows[0]["DealerUniqueID"].ToString();
                                objDealerCarInfo.CarStatus = ds.Tables[0].Rows[0]["Adstatus"].ToString();
                                objDealerCarInfo.UID = Convert.ToInt32(UID);
                                objList.Add(objDealerCarInfo);
                            }
                            else
                            {
                                UCEDealerInfo objDealerCarInfo = new UCEDealerInfo();
                                objDealerCarInfo.AASuccess = "8003:Car details not updated successfully";
                                objDealerCarInfo.DealerCode = DealerCode;
                                objDealerCarInfo.UID = Convert.ToInt32(UID);
                                objList.Add(objDealerCarInfo);

                            }

                        }
                        else
                        {
                            UCEDealerInfo objDealerCarInfo = new UCEDealerInfo();
                            objDealerCarInfo.AASuccess = "8003:Car details not updated successfully";
                            objDealerCarInfo.DealerCode = DealerCode;
                            objDealerCarInfo.UID = Convert.ToInt32(UID);
                            objList.Add(objDealerCarInfo);
                        }

                      }

                    }
                    else
                    {
                        UCEDealerInfo objInfo = new UCEDealerInfo();
                        objInfo.AASuccess = "8001:DealerCode,Username,password not existed";
                        objInfo.DealerCode = DealerCode;
                        objList.Add(objInfo);
                    }
               
            }
            catch (Exception ex)
            {
            }
            return objList;
        }

    }
}
