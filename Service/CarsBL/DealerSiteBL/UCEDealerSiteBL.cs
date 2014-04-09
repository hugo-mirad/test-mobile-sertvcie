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


namespace CarsBL
{
    public class UCEDealerSiteBL
    {
        public DataSet PerformLoginIntoUCE(string UserName, string DealerCode, string Password)
        {
            DataSet ds = new DataSet();
            string spNameString = string.Empty;

            //objUsedCars.Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.CarsConnTest);


            spNameString = "USP_PerformDealerLoginFromDealerSitesToUce";
            DbCommand dbCommand = null;

            try
            {
                //objUsedCars.Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbCommand.CommandTimeout = 10000;

                dbDatabase.AddInParameter(dbCommand, "@DealerEmail", DbType.String, UserName);
                dbDatabase.AddInParameter(dbCommand, "@DealerCode", DbType.String, DealerCode);
                dbDatabase.AddInParameter(dbCommand, "@DealerPassword", DbType.String, Password);

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

        public DataSet SaveCarDetailsToUCE(DealerSiteCarInfo objCarInfo, string UID)
        {

            DataSet ds = new DataSet();
            string spNameString = string.Empty;

            //objUsedCars.Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.CarsConnTest);


            spNameString = "[USP_SaveCarDataFromDealerSite]";
            DbCommand dbCommand = null;

            try
            {
                //objUsedCars.Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbCommand.CommandTimeout = 10000;

                dbDatabase.AddInParameter(dbCommand, "@CarID", DbType.Int64, objCarInfo.CarID);
                dbDatabase.AddInParameter(dbCommand, "@YearOfMake", DbType.Int32, objCarInfo.MakeModelYear);
                dbDatabase.AddInParameter(dbCommand, "@Make", DbType.String, objCarInfo.Make);
                dbDatabase.AddInParameter(dbCommand, "@Model", DbType.String, objCarInfo.Model);
                dbDatabase.AddInParameter(dbCommand, "@BodyType", DbType.String, objCarInfo.BodyType);
                dbDatabase.AddInParameter(dbCommand, "@VehicleCondition", DbType.String, objCarInfo.VehicleCondition);
                dbDatabase.AddInParameter(dbCommand, "@DriveTrain", DbType.String, objCarInfo.DriveTrain);
                dbDatabase.AddInParameter(dbCommand, "@Price", DbType.String, objCarInfo.SellingPrice);
                dbDatabase.AddInParameter(dbCommand, "@Mileage", DbType.Int32, objCarInfo.Mileage);
                dbDatabase.AddInParameter(dbCommand, "@ExteriorColor", DbType.String, objCarInfo.ExtColor);
                dbDatabase.AddInParameter(dbCommand, "@InteriorColor", DbType.String, objCarInfo.IntColor);
                dbDatabase.AddInParameter(dbCommand, "@Transmission", DbType.String, objCarInfo.Transmission);
                dbDatabase.AddInParameter(dbCommand, "@NumberOfDoors", DbType.String, objCarInfo.Doors);
                dbDatabase.AddInParameter(dbCommand, "@VIN", DbType.String, objCarInfo.VIN);
                dbDatabase.AddInParameter(dbCommand, "@NumberOfCylinder", DbType.String, objCarInfo.Cylinders);
                dbDatabase.AddInParameter(dbCommand, "@FuelType", DbType.String, objCarInfo.FuelType);
                dbDatabase.AddInParameter(dbCommand, "@Description", DbType.String, objCarInfo.Description);
                dbDatabase.AddInParameter(dbCommand, "@Title", DbType.String, objCarInfo.Title);
                dbDatabase.AddInParameter(dbCommand, "@CarStatus", DbType.String, objCarInfo.CarStatus);
                dbDatabase.AddInParameter(dbCommand, "@SellerName", DbType.String, objCarInfo.SellerName);
                dbDatabase.AddInParameter(dbCommand, "@City", DbType.String, objCarInfo.SellerCity);
                dbDatabase.AddInParameter(dbCommand, "@State", DbType.String, objCarInfo.SellerState);
                dbDatabase.AddInParameter(dbCommand, "@Email", DbType.String, objCarInfo.SellerEmail);
                dbDatabase.AddInParameter(dbCommand, "@PhoneNum", DbType.String, objCarInfo.SellerPhone);
                dbDatabase.AddInParameter(dbCommand, "@Zip", DbType.String, objCarInfo.Zip);
                dbDatabase.AddInParameter(dbCommand, "@DealerCode", DbType.String, objCarInfo.DealerCode);
                dbDatabase.AddInParameter(dbCommand, "@DealerInventoryID", DbType.String, objCarInfo.DealerInventoryID);
                dbDatabase.AddInParameter(dbCommand, "@UID", DbType.Int32, UID);

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

        public DataSet DealerCheckUniqueID(string DealerUniqueID, string DealerCode)
        {
            try
            {
                DataSet dsCars = new DataSet();

                string spNameString = string.Empty;

                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.CarsConnTest);

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

        public DataSet GetCarImageIDsToDealerSite(int CarID)
        {
            try
            {
                DataSet dsCars = new DataSet();

                string spNameString = string.Empty;

                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.CarsConnTest);

                spNameString = "USP_GetCarImagesIDsToDealerSite";

                DbCommand dbCommand = null;

                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                // dbDatabase.AddInParameter(dbCommand, "@DealerUniqueID", System.Data.DbType.String, DealerUniqueID);

                dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);

                dsCars = dbDatabase.ExecuteDataSet(dbCommand);

                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdatePicturesByIdFromDealerSite(CarsInfo.UsedCarsInfo objCarsInfo, int TranBy)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.CarsConnTest);
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


        public string SaveCarPictureFromDealerSite(string PicLoc, string picName, int UID)
        {
            string picID = string.Empty;
            try
            {
                DataSet dsCars = new DataSet();

                string spNameString = string.Empty;

                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.CarsConnTest);

                spNameString = "[USP_SaveCarPicsFromDealerSite]";

                DbCommand dbCommand = null;

                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                // dbDatabase.AddInParameter(dbCommand, "@DealerUniqueID", System.Data.DbType.String, DealerUniqueID);

                dbDatabase.AddInParameter(dbCommand, "@PicLocation", System.Data.DbType.String, PicLoc);
                dbDatabase.AddInParameter(dbCommand, "@Picname", System.Data.DbType.String, picName);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                //dbDatabase.AddInParameter(dbCommand, "@CarID", System.Data.DbType.Int32, CarID);

                dsCars = dbDatabase.ExecuteDataSet(dbCommand);

                if (dsCars.Tables.Count > 0)
                {
                    if (dsCars.Tables[0].Rows.Count > 0)
                    {
                        picID = dsCars.Tables[0].Rows[0]["picID"].ToString();
                    }
                }

            }
            catch (Exception ex)
            {
            }
            return picID;
        }
    }
}
