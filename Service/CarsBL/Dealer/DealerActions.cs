/**********************************************************************
' MODULE       : Master
' FILENAME     : Master.cs
    ' AUTHOR       : Shravan
    ' CREATED      : 04-Jan-2012
    ' DESCRIPTION  : Business Logic to manipulate .
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
#endregion Microsoft Application Block References

namespace CarsBL.Dealer
{
    public class DealerActions
    {

        public DataSet GetDealerCarDetails(string DealerCode, string DealerUniqUeID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "[USP_GetDealerCarDetails]";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                dbDatabase.AddInParameter(dbCommand, "@DealerCode", System.Data.DbType.String, DealerCode);
                dbDatabase.AddInParameter(dbCommand, "@DealerUniqUeID", System.Data.DbType.String, DealerUniqUeID);


                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataSet DealerUpdateCarAdStatus(string PostingID, string AdStatusID)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "[USP_DealerUpdateCarAdStatus]";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.String, PostingID);
                dbDatabase.AddInParameter(dbCommand, "@AdStatusID", System.Data.DbType.String, AdStatusID);


                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet USP_SaveCarDetails(CarsInfo.UsedCarsInfo objCarsInfo, string Description, string ConditionDescription, string Title, int TranBy)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "[USP_SaveDealerCarDetails]";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@YearOfMake", System.Data.DbType.Int32, objCarsInfo.YearOfMake);
                dbDatabase.AddInParameter(dbCommand, "@MakeModelID", System.Data.DbType.Int32, objCarsInfo.MakeModelID);
                dbDatabase.AddInParameter(dbCommand, "@BodyTypeID", System.Data.DbType.Int32, objCarsInfo.BodytypeID);
                dbDatabase.AddInParameter(dbCommand, "@VehicleConditionID", System.Data.DbType.Int32, objCarsInfo.VehicleConditionID);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, objCarsInfo.Carid);
                dbDatabase.AddInParameter(dbCommand, "@Price", System.Data.DbType.String, objCarsInfo.Price);
                dbDatabase.AddInParameter(dbCommand, "@Mileage", System.Data.DbType.String, objCarsInfo.Mileage);
                dbDatabase.AddInParameter(dbCommand, "@ExteriorColor", System.Data.DbType.String, objCarsInfo.ExteriorColor);
                dbDatabase.AddInParameter(dbCommand, "@Transmission", System.Data.DbType.String, objCarsInfo.Transmission);
                dbDatabase.AddInParameter(dbCommand, "@InteriorColor", System.Data.DbType.String, objCarsInfo.InteriorColor);
                dbDatabase.AddInParameter(dbCommand, "@NumberOfDoors", System.Data.DbType.String, objCarsInfo.NumberOfDoors);
                dbDatabase.AddInParameter(dbCommand, "@VIN", System.Data.DbType.String, objCarsInfo.VIN);
                dbDatabase.AddInParameter(dbCommand, "@NumberOfCylinder", System.Data.DbType.String, objCarsInfo.NumberOfCylinder);
                dbDatabase.AddInParameter(dbCommand, "@FuelTypeID", System.Data.DbType.Int32, objCarsInfo.FueltypeId);
                dbDatabase.AddInParameter(dbCommand, "@Zipcode", System.Data.DbType.String, objCarsInfo.Zipcode);
                dbDatabase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, objCarsInfo.City);
                dbDatabase.AddInParameter(dbCommand, "@StateID", System.Data.DbType.Int32, objCarsInfo.StateID);
                dbDatabase.AddInParameter(dbCommand, "@Description", System.Data.DbType.String, Description);
                dbDatabase.AddInParameter(dbCommand, "@ConditionDescription", System.Data.DbType.String, ConditionDescription);
                dbDatabase.AddInParameter(dbCommand, "@DriveTrain", System.Data.DbType.String, objCarsInfo.DriveTrain);
                dbDatabase.AddInParameter(dbCommand, "@Title", System.Data.DbType.String, Title);
                dbDatabase.AddInParameter(dbCommand, "@TranBy", System.Data.DbType.Int32, TranBy);

                dbDatabase.AddInParameter(dbCommand, "@SellingPrice", System.Data.DbType.String, objCarsInfo.CurrentPrice);
                dbDatabase.AddInParameter(dbCommand, "@PurchaseCost", System.Data.DbType.String, objCarsInfo.PurchaseCost);



                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet USP_SaveSellerInfo(UsedCarsInfo objUsedCarsInfo, int CarID, int UID, int PackageID, int PaymentID, int UserPackID, int PostingID, string Ip)
        {
            try
            {
                bool bnew = false;
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "[USP_DealerSaveSellerInfo]";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@sellerID", System.Data.DbType.Int32, objUsedCarsInfo.SellerID);
                dbDatabase.AddInParameter(dbCommand, "@sellerName", System.Data.DbType.String, objUsedCarsInfo.SellerName);
                dbDatabase.AddInParameter(dbCommand, "@address1", System.Data.DbType.String, objUsedCarsInfo.Address1);
                dbDatabase.AddInParameter(dbCommand, "@city", System.Data.DbType.String, objUsedCarsInfo.City);
                dbDatabase.AddInParameter(dbCommand, "@state", System.Data.DbType.String, objUsedCarsInfo.State);
                dbDatabase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, objUsedCarsInfo.Zip);
                dbDatabase.AddInParameter(dbCommand, "@Phone", System.Data.DbType.String, objUsedCarsInfo.Phone);
                dbDatabase.AddInParameter(dbCommand, "@email", System.Data.DbType.String, objUsedCarsInfo.Email);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dbDatabase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.Int32, PackageID);
                dbDatabase.AddInParameter(dbCommand, "@PaymentID", System.Data.DbType.Int32, PaymentID);
                dbDatabase.AddInParameter(dbCommand, "@UserPackID", System.Data.DbType.Int32, UserPackID);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);
                dbDatabase.AddInParameter(dbCommand, "@Ip", System.Data.DbType.String, Ip);

                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataSet SaveCarDetailsForBulkUploadDealers(UsedCarsInfo objCarsInfo,
            string SellerID, String SellerTypeID, string Source, String SourcePicID, string DealerCarid, string UserPackID, string DealerCode)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SaveCarDetailsForBulkUploadDealers";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbCommand.CommandTimeout = 1500;

                dbDatabase.AddInParameter(dbCommand, "@YearOfMake", System.Data.DbType.String, objCarsInfo.YearOfMake);
                dbDatabase.AddInParameter(dbCommand, "@Make", System.Data.DbType.String, objCarsInfo.Make);
                dbDatabase.AddInParameter(dbCommand, "@Model", System.Data.DbType.String, objCarsInfo.Model);
                dbDatabase.AddInParameter(dbCommand, "@BodyType", System.Data.DbType.String, objCarsInfo.Bodytype);
                dbDatabase.AddInParameter(dbCommand, "@VehicleCondition", System.Data.DbType.String, objCarsInfo.VehicleConditionID);
                dbDatabase.AddInParameter(dbCommand, "@Price", System.Data.DbType.String, objCarsInfo.Price);
                dbDatabase.AddInParameter(dbCommand, "@Mileage", System.Data.DbType.String, objCarsInfo.Mileage);
                dbDatabase.AddInParameter(dbCommand, "@ExteriorColor", System.Data.DbType.String, objCarsInfo.ExteriorColor);
                dbDatabase.AddInParameter(dbCommand, "@InteriorColor", System.Data.DbType.String, objCarsInfo.InteriorColor);

                dbDatabase.AddInParameter(dbCommand, "@Transmission", System.Data.DbType.String, objCarsInfo.Transmission);
                dbDatabase.AddInParameter(dbCommand, "@NumberOfDoors", System.Data.DbType.String, objCarsInfo.NumberOfDoors);
                dbDatabase.AddInParameter(dbCommand, "@VIN", System.Data.DbType.String, objCarsInfo.VIN);
                dbDatabase.AddInParameter(dbCommand, "@NumberOfCylinder", System.Data.DbType.String, objCarsInfo.NumberOfCylinder);

                dbDatabase.AddInParameter(dbCommand, "@FuelTypeID", System.Data.DbType.String, objCarsInfo.Fueltype);
                dbDatabase.AddInParameter(dbCommand, "@Zipcode", System.Data.DbType.String, objCarsInfo.Zipcode);
                dbDatabase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, objCarsInfo.City);
                dbDatabase.AddInParameter(dbCommand, "@StateID", System.Data.DbType.String, objCarsInfo.State);
                dbDatabase.AddInParameter(dbCommand, "@Description", System.Data.DbType.String, objCarsInfo.Description);
                dbDatabase.AddInParameter(dbCommand, "@ConditionDescription", System.Data.DbType.String, objCarsInfo.ConditionDescription);
                dbDatabase.AddInParameter(dbCommand, "@DriveTrain", System.Data.DbType.String, objCarsInfo.DriveTrain);
                dbDatabase.AddInParameter(dbCommand, "@sellerID", System.Data.DbType.String, SellerID);
                dbDatabase.AddInParameter(dbCommand, "@SellerType", System.Data.DbType.String, SellerTypeID);
                dbDatabase.AddInParameter(dbCommand, "@Source", System.Data.DbType.String, Source);
                dbDatabase.AddInParameter(dbCommand, "@SourcePicID", System.Data.DbType.String, SourcePicID);
                dbDatabase.AddInParameter(dbCommand, "@DealerCarID", System.Data.DbType.String, DealerCarid);

                dbDatabase.AddInParameter(dbCommand, "@address1", System.Data.DbType.String, objCarsInfo.Address1);
                dbDatabase.AddInParameter(dbCommand, "@sellerName", System.Data.DbType.String, objCarsInfo.SellerName);
                dbDatabase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.String, objCarsInfo.PackageID);
                dbDatabase.AddInParameter(dbCommand, "@UserPackID", System.Data.DbType.String, UserPackID);
                dbDatabase.AddInParameter(dbCommand, "@Phone", System.Data.DbType.String, objCarsInfo.Phone);
                dbDatabase.AddInParameter(dbCommand, "@Email", System.Data.DbType.String, objCarsInfo.Email);
                dbDatabase.AddInParameter(dbCommand, "@DealerCode", System.Data.DbType.String, DealerCode);

                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.String, objCarsInfo.Uid);

                //dbDatabase.AddInParameter(dbCommand, "@SellingPrice", System.Data.DbType.String, objCarsInfo.CurrentPrice);
                //dbDatabase.AddInParameter(dbCommand, "@PurchaseCost", System.Data.DbType.String, objCarsInfo.PurchaseCost);



                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdatePicturesById(CarsInfo.UsedCarsInfo objCarsInfo, int TranBy)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_UpdatePicturesById";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@pic1", System.Data.DbType.String, objCarsInfo.PIC1);
                dbDatabase.AddInParameter(dbCommand, "@pic2", System.Data.DbType.String, objCarsInfo.PIC2);
                dbDatabase.AddInParameter(dbCommand, "@pic3", System.Data.DbType.String, objCarsInfo.PIC3);
                dbDatabase.AddInParameter(dbCommand, "@pic4", System.Data.DbType.String, objCarsInfo.PIC4);
                dbDatabase.AddInParameter(dbCommand, "@pic5", System.Data.DbType.String, objCarsInfo.PIC5);
                dbDatabase.AddInParameter(dbCommand, "@pic6", System.Data.DbType.String, objCarsInfo.PIC6);
                dbDatabase.AddInParameter(dbCommand, "@pic7", System.Data.DbType.String, objCarsInfo.PIC7);
                dbDatabase.AddInParameter(dbCommand, "@pic8", System.Data.DbType.String, objCarsInfo.PIC8);
                dbDatabase.AddInParameter(dbCommand, "@pic9", System.Data.DbType.String, objCarsInfo.PIC9);
                dbDatabase.AddInParameter(dbCommand, "@pic10", System.Data.DbType.String, objCarsInfo.PIC10);
                dbDatabase.AddInParameter(dbCommand, "@Pic11", System.Data.DbType.String, objCarsInfo.PIC11);
                dbDatabase.AddInParameter(dbCommand, "@pic12", System.Data.DbType.String, objCarsInfo.PIC12);
                dbDatabase.AddInParameter(dbCommand, "@pic13", System.Data.DbType.String, objCarsInfo.PIC13);
                dbDatabase.AddInParameter(dbCommand, "@pic14", System.Data.DbType.String, objCarsInfo.PIC14);
                dbDatabase.AddInParameter(dbCommand, "@pic15", System.Data.DbType.String, objCarsInfo.PIC15);
                dbDatabase.AddInParameter(dbCommand, "@pic16", System.Data.DbType.String, objCarsInfo.PIC16);
                dbDatabase.AddInParameter(dbCommand, "@pic17", System.Data.DbType.String, objCarsInfo.PIC17);
                dbDatabase.AddInParameter(dbCommand, "@pic18", System.Data.DbType.String, objCarsInfo.PIC18);
                dbDatabase.AddInParameter(dbCommand, "@pic19", System.Data.DbType.String, objCarsInfo.PIC19);
                dbDatabase.AddInParameter(dbCommand, "@pic20", System.Data.DbType.String, objCarsInfo.PIC20);
                dbDatabase.AddInParameter(dbCommand, "@Pic0", System.Data.DbType.String, objCarsInfo.PIC0);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, objCarsInfo.Carid);
                dbDatabase.AddInParameter(dbCommand, "@TranBy", System.Data.DbType.Int32, TranBy);

                dbDatabase.ExecuteDataSet(dbCommand);
                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet USP_ChkPackageForAddCar(int UID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_ChkPackageForAddCar";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet USP_ChkExistingPackage(int UID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_ChkExistingPackage";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public DataSet SavePictures(string picturelocation, string picturename, string picturetype, int UserID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SavePictures";
                DbCommand dbCommand = null;

                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@picturelocation", System.Data.DbType.String, picturelocation);
                dbDatabase.AddInParameter(dbCommand, "@picturename", System.Data.DbType.String, picturename);
                dbDatabase.AddInParameter(dbCommand, "@picturetype", System.Data.DbType.String, picturetype);
                dbDatabase.AddInParameter(dbCommand, "@UserID", System.Data.DbType.Int32, UserID);

                dsCars = dbDatabase.ExecuteDataSet(dbCommand);

                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet DealerDefaultSellerInfo(string DealerCode, int UserID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_DealerDefaultSellerInfo";
                DbCommand dbCommand = null;

                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@DealerCode", System.Data.DbType.String, DealerCode);
                dbDatabase.AddInParameter(dbCommand, "@UserID", System.Data.DbType.Int32, UserID);

                dsCars = dbDatabase.ExecuteDataSet(dbCommand);

                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet UpdateDealerSellerInfo(UserRegistrationInfo objUserregisInfo, string SellarID, string DealerCode, string Email)
        {
            bool returnValue = false;

            string spNameString = string.Empty;

            DataSet dsUserInfo = new DataSet();

            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            spNameString = "[USP_UpdateDealerSellerInfo]";

            DbCommand dbCommand = null;

            try
            {
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@UId", System.Data.DbType.Int32, objUserregisInfo.UId);
                dbDatabase.AddInParameter(dbCommand, "@Name", System.Data.DbType.String, objUserregisInfo.Name);
                dbDatabase.AddInParameter(dbCommand, "@Phone", System.Data.DbType.String, objUserregisInfo.PhoneNumber);
                dbDatabase.AddInParameter(dbCommand, "@StateID", System.Data.DbType.Int32, objUserregisInfo.StateID);
                dbDatabase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, objUserregisInfo.City);
                dbDatabase.AddInParameter(dbCommand, "@Address", System.Data.DbType.String, objUserregisInfo.Address);
                dbDatabase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, objUserregisInfo.Zip);
                dbDatabase.AddInParameter(dbCommand, "@BusinessName", System.Data.DbType.String, objUserregisInfo.BusinessName);
                dbDatabase.AddInParameter(dbCommand, "@AltEmail", System.Data.DbType.String, objUserregisInfo.AltEmail);
                dbDatabase.AddInParameter(dbCommand, "@AltPhone", System.Data.DbType.String, objUserregisInfo.AltPhone);
                dbDatabase.AddInParameter(dbCommand, "@SellarID", System.Data.DbType.String, SellarID);
                dbDatabase.AddInParameter(dbCommand, "@DealerCode", System.Data.DbType.String, DealerCode);
                dbDatabase.AddInParameter(dbCommand, "@Email", System.Data.DbType.String, Email);



                dsUserInfo = dbDatabase.ExecuteDataSet(dbCommand);

                //blnSuccess = objUserLog.SaveUserLog(UserLogInfo, ref lngReturn, "");
                return dsUserInfo;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




        public DataSet SaveCarAndSellerInfo(UsedCarsInfo objCarsInfo, string Description, string ConditionDescription, string Title, int TranBy,
            int UID, int PackageID, int PaymentID, int UserPackID, int PostingID, string Ip, string DealerCode)
        {
            try
            {
                DataSet dsCars = new DataSet();

                string spNameString = string.Empty;

                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

                spNameString = "USP_SaveDealerCarAndSellerInfo";

                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@YearOfMake", System.Data.DbType.Int32, objCarsInfo.YearOfMake);
                dbDatabase.AddInParameter(dbCommand, "@MakeModelID", System.Data.DbType.Int32, objCarsInfo.MakeModelID);
                dbDatabase.AddInParameter(dbCommand, "@BodyTypeID", System.Data.DbType.Int32, objCarsInfo.BodytypeID);
                dbDatabase.AddInParameter(dbCommand, "@VehicleConditionID", System.Data.DbType.Int32, objCarsInfo.VehicleConditionID);
                dbDatabase.AddInParameter(dbCommand, "@DriveTrain", System.Data.DbType.String, objCarsInfo.DriveTrain);

                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, objCarsInfo.Carid);
                dbDatabase.AddInParameter(dbCommand, "@Price", System.Data.DbType.String, objCarsInfo.Price);
                dbDatabase.AddInParameter(dbCommand, "@CurrentPrice", System.Data.DbType.String, objCarsInfo.CurrentPrice);
                dbDatabase.AddInParameter(dbCommand, "@PurchaseCost", System.Data.DbType.String, objCarsInfo.PurchaseCost);

                dbDatabase.AddInParameter(dbCommand, "@Mileage", System.Data.DbType.String, objCarsInfo.Mileage);
                dbDatabase.AddInParameter(dbCommand, "@ExteriorColor", System.Data.DbType.String, objCarsInfo.ExteriorColor);
                dbDatabase.AddInParameter(dbCommand, "@Transmission", System.Data.DbType.String, objCarsInfo.Transmission);
                dbDatabase.AddInParameter(dbCommand, "@InteriorColor", System.Data.DbType.String, objCarsInfo.InteriorColor);
                dbDatabase.AddInParameter(dbCommand, "@NumberOfDoors", System.Data.DbType.String, objCarsInfo.NumberOfDoors);

                dbDatabase.AddInParameter(dbCommand, "@VIN", System.Data.DbType.String, objCarsInfo.VIN);
                dbDatabase.AddInParameter(dbCommand, "@NumberOfCylinder", System.Data.DbType.String, objCarsInfo.NumberOfCylinder);
                dbDatabase.AddInParameter(dbCommand, "@FuelTypeID", System.Data.DbType.Int32, objCarsInfo.FueltypeId);
                dbDatabase.AddInParameter(dbCommand, "@Zipcode", System.Data.DbType.String, objCarsInfo.Zipcode);
                dbDatabase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, objCarsInfo.City);


                dbDatabase.AddInParameter(dbCommand, "@StateID", System.Data.DbType.Int32, objCarsInfo.StateID);
                dbDatabase.AddInParameter(dbCommand, "@Description", System.Data.DbType.String, Description);
                dbDatabase.AddInParameter(dbCommand, "@ConditionDescription", System.Data.DbType.String, ConditionDescription);
                dbDatabase.AddInParameter(dbCommand, "@Title", System.Data.DbType.String, Title);
                dbDatabase.AddInParameter(dbCommand, "@TranBy", System.Data.DbType.Int32, TranBy);

                dbDatabase.AddInParameter(dbCommand, "@sellerName", System.Data.DbType.String, objCarsInfo.SellerName);
                dbDatabase.AddInParameter(dbCommand, "@address1", System.Data.DbType.String, objCarsInfo.Address1);
                dbDatabase.AddInParameter(dbCommand, "@state", System.Data.DbType.String, objCarsInfo.State);
                dbDatabase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, objCarsInfo.Zip);
                dbDatabase.AddInParameter(dbCommand, "@Phone", System.Data.DbType.String, objCarsInfo.Phone);

                dbDatabase.AddInParameter(dbCommand, "@email", System.Data.DbType.String, objCarsInfo.Email);
                dbDatabase.AddInParameter(dbCommand, "@sellerID", System.Data.DbType.Int32, objCarsInfo.SellerID);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dbDatabase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.Int32, PackageID);
                dbDatabase.AddInParameter(dbCommand, "@PaymentID", System.Data.DbType.Int32, PaymentID);

                dbDatabase.AddInParameter(dbCommand, "@UserPackID", System.Data.DbType.Int32, UserPackID);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", System.Data.DbType.Int32, PostingID);
                dbDatabase.AddInParameter(dbCommand, "@Ip", System.Data.DbType.String, Ip);
                dbDatabase.AddInParameter(dbCommand, "@AdStatus", System.Data.DbType.String, objCarsInfo.AdStatus);
                dbDatabase.AddInParameter(dbCommand, "@DealerCode", System.Data.DbType.String, DealerCode);
                dbDatabase.AddInParameter(dbCommand, "@DealerUniqueID", System.Data.DbType.String, objCarsInfo.DealerUniqueID);





                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet USP_GetImages(int CarID, int PackageID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetImages";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.Int32, PackageID);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetPictureLocationByID(string picID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetPictureLocationByID";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@picID", System.Data.DbType.String, picID);                
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet DealerCheckUniqueID(string DealerUniqueID, string DealerCode)
        {
            try
            {
                DataSet dsCars = new DataSet();

                string spNameString = string.Empty;

                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

                spNameString = "USP_DealerCheckUniqueID";

                DbCommand dbCommand = null;

                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@DealerUniqueID", System.Data.DbType.String, DealerUniqueID);

                dbDatabase.AddInParameter(dbCommand, "@DealerCode", System.Data.DbType.String, DealerCode);

                dsCars = dbDatabase.ExecuteDataSet(dbCommand);

                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet USP_GetCustomerDetailsByPostingID(int PostingID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetCustomerDetailsByPostingID";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@postingID", System.Data.DbType.Int32, PostingID);

                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet DealerLogoUpdate(string LogoPath, string sellerID)
        {
            try
            {
                DataSet dsCars = new DataSet();

                string spNameString = string.Empty;

                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

                spNameString = "[USP_DealerLogoUpdate]";
                DbCommand dbCommand = null;

                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@LogoPath", System.Data.DbType.String, LogoPath);

                dbDatabase.AddInParameter(dbCommand, "@sellerID", System.Data.DbType.String, sellerID);

                dsCars = dbDatabase.ExecuteDataSet(dbCommand);

                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet GetDealerLogo(string sellerID)
        {
            try
            {
                DataSet dsCars = new DataSet();

                string spNameString = string.Empty;

                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

                spNameString = "[USP_GetDealerLogo]";
                DbCommand dbCommand = null;

                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                dbDatabase.AddInParameter(dbCommand, "@sellerID", System.Data.DbType.String, sellerID);

                dsCars = dbDatabase.ExecuteDataSet(dbCommand);

                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet USP_SaveCarFeatures(int CarID, int FeatureID, int Isactive, int TranBy)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SaveCarFeatures";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@FeatureID", System.Data.DbType.Int32, FeatureID);
                dbDatabase.AddInParameter(dbCommand, "@Isactive", System.Data.DbType.Int32, Isactive);
                dbDatabase.AddInParameter(dbCommand, "@TranBy", System.Data.DbType.Int32, TranBy);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDealerMultiSitePostings(string  postingID)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetDealerMultiSitePostings";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@postingID", System.Data.DbType.String, postingID);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}
