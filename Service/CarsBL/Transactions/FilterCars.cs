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

#endregion Application References

#region Microsoft Application Block References
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using CarsInfo;
#endregion Microsoft Application Block References

namespace CarsBL.Transactions
{
    public class FilterCars
    {
        public IList<UsedCarsInfo> FilterSearch(CarsInfo.CarsFilter objCarsFilter)
        {
            string spNameString = string.Empty;


            //Setting Connection
            //Global.INSTANCE_NAME = strCurrentConn;

            IDataReader ModelsInfoDataReader = null;
            IList<UsedCarsInfo> UsedCarsIList = new List<UsedCarsInfo>();



            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //Assign stored procedure name

            spNameString = "[FilterSearch]";
            DbCommand dbCommand = null;


            IDataReader UsedCarsDataReader = null;

            try
            {
                //Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbCommand.CommandTimeout = 10000;


                dbDatabase.AddInParameter(dbCommand, "@makeModelID", DbType.String, objCarsFilter.CarModalId);
                dbDatabase.AddInParameter(dbCommand, "@Nearby", DbType.String, objCarsFilter.WithinZip);
                dbDatabase.AddInParameter(dbCommand, "@Pin", DbType.Int64, objCarsFilter.ZipCode);
                dbDatabase.AddInParameter(dbCommand, "@currentPage", DbType.Int64, objCarsFilter.CurrentPage);
                dbDatabase.AddInParameter(dbCommand, "@makeID", DbType.String, objCarsFilter.CarMakeid);
                dbDatabase.AddInParameter(dbCommand, "@Orderby", DbType.String, objCarsFilter.Orderby);
                dbDatabase.AddInParameter(dbCommand, "@sort", DbType.String, objCarsFilter.Sort);
                dbDatabase.AddInParameter(dbCommand, "@pageSize", DbType.Int64, objCarsFilter.PageSize);


                dbDatabase.AddInParameter(dbCommand, "@Mileage1", DbType.String , objCarsFilter.Mileage1);
                dbDatabase.AddInParameter(dbCommand, "@Mileage2", DbType.String, objCarsFilter.Mileage2);
                dbDatabase.AddInParameter(dbCommand, "@Mileage3", DbType.String, objCarsFilter.Mileage3);
                dbDatabase.AddInParameter(dbCommand, "@Mileage4", DbType.String, objCarsFilter.Mileage4);
                dbDatabase.AddInParameter(dbCommand, "@Mileage5", DbType.String, objCarsFilter.Mileage5);
                dbDatabase.AddInParameter(dbCommand, "@Mileage6", DbType.String, objCarsFilter.Mileage6);
                dbDatabase.AddInParameter(dbCommand, "@Mileage7", DbType.String, objCarsFilter.Mileage7);
                dbDatabase.AddInParameter(dbCommand, "@Year1a", DbType.String, objCarsFilter.Year1a);
                dbDatabase.AddInParameter(dbCommand, "@Year1b", DbType.String, objCarsFilter.Year1b);
                dbDatabase.AddInParameter(dbCommand, "@Year1", DbType.String, objCarsFilter.Year1);
                dbDatabase.AddInParameter(dbCommand, "@Year2", DbType.String, objCarsFilter.Year2);
                dbDatabase.AddInParameter(dbCommand, "@Year3", DbType.String, objCarsFilter.Year3);
                dbDatabase.AddInParameter(dbCommand, "@Year4", DbType.String, objCarsFilter.Year4);
                dbDatabase.AddInParameter(dbCommand, "@Year5", DbType.String, objCarsFilter.Year5);
                dbDatabase.AddInParameter(dbCommand, "@Year6", DbType.String, objCarsFilter.Year6);
                dbDatabase.AddInParameter(dbCommand, "@Year7", DbType.String, objCarsFilter.Year7);
                dbDatabase.AddInParameter(dbCommand, "@Price1", DbType.String, objCarsFilter.Price1);
                dbDatabase.AddInParameter(dbCommand, "@Price2", DbType.String, objCarsFilter.Price2);
                dbDatabase.AddInParameter(dbCommand, "@Price3", DbType.String, objCarsFilter.Price3);
                dbDatabase.AddInParameter(dbCommand, "@Price4", DbType.String, objCarsFilter.Price4);
                dbDatabase.AddInParameter(dbCommand, "@Price5", DbType.String, objCarsFilter.Price5);
                dbDatabase.AddInParameter(dbCommand, "@Body1", DbType.String, objCarsFilter.Body1);
                dbDatabase.AddInParameter(dbCommand, "@Body2", DbType.String, objCarsFilter.Body2);
                dbDatabase.AddInParameter(dbCommand, "@Body3", DbType.String, objCarsFilter.Body3);
                dbDatabase.AddInParameter(dbCommand, "@Body4", DbType.String, objCarsFilter.Body4);
                dbDatabase.AddInParameter(dbCommand, "@Body5", DbType.String, objCarsFilter.Body5);
                dbDatabase.AddInParameter(dbCommand, "@Body6", DbType.String, objCarsFilter.Body6);
                dbDatabase.AddInParameter(dbCommand, "@Body7", DbType.String, objCarsFilter.Body7);
                dbDatabase.AddInParameter(dbCommand, "@Body8", DbType.String, objCarsFilter.Body8);
                dbDatabase.AddInParameter(dbCommand, "@Body9", DbType.String, objCarsFilter.Body9);
                dbDatabase.AddInParameter(dbCommand, "@Fuel1", DbType.String, objCarsFilter.Fuel1);
                dbDatabase.AddInParameter(dbCommand, "@Fuel2", DbType.String, objCarsFilter.Fuel2);
                dbDatabase.AddInParameter(dbCommand, "@Fuel3", DbType.String, objCarsFilter.Fuel3);
                dbDatabase.AddInParameter(dbCommand, "@Fuel4", DbType.String, objCarsFilter.Fuel4);
                dbDatabase.AddInParameter(dbCommand, "@Fuel5", DbType.String, objCarsFilter.Fuel5);
                dbDatabase.AddInParameter(dbCommand, "@Seller1", DbType.String, objCarsFilter.Seller1);
                dbDatabase.AddInParameter(dbCommand, "@Seller2", DbType.String, objCarsFilter.Seller2);
                dbDatabase.AddInParameter(dbCommand, "@withPic", DbType.Boolean, objCarsFilter.WithPic);
                


                //objUsedCars.Executing stored procedure
                UsedCarsDataReader = dbDatabase.ExecuteReader(dbCommand);

                //'DataSet  DS = dbDatabase.ExecuteDataSet(dbCommand);

                while (UsedCarsDataReader.Read())
                {
                    //  objUsedCars.Assign values to the CarsInfo object list
                    UsedCarsInfo ObjCarsInfo_Info = new UsedCarsInfo();
                    AssignCarsInfoList(UsedCarsDataReader, ObjCarsInfo_Info);
                    UsedCarsIList.Add(ObjCarsInfo_Info);
                }


            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, Global.EXCEPTION_POLICY);

                if (rethrow)
                    throw;
            }
            finally
            {
                UsedCarsDataReader.Close();
            }

            return UsedCarsIList;
        }


        public IList<UsedCarsInfo> FilterSearchMobile(CarsInfo.CarsFilter objCarsFilter)
        {
            string spNameString = string.Empty;


            //Setting Connection
            //Global.INSTANCE_NAME = strCurrentConn;

            IDataReader ModelsInfoDataReader = null;
            IList<UsedCarsInfo> UsedCarsIList = new List<UsedCarsInfo>();



            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //Assign stored procedure name

            spNameString = "[FilterSearchMobile]";
            DbCommand dbCommand = null;


            IDataReader UsedCarsDataReader = null;

            try
            {
                //Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbCommand.CommandTimeout = 10000;

                dbDatabase.AddInParameter(dbCommand, "@makeID", DbType.String, objCarsFilter.CarMakeid);
                dbDatabase.AddInParameter(dbCommand, "@makeModelID", DbType.String, objCarsFilter.CarModalId);
                
                dbDatabase.AddInParameter(dbCommand, "@Orderby", DbType.String, objCarsFilter.Orderby);
                dbDatabase.AddInParameter(dbCommand, "@currentPage", DbType.Int64, objCarsFilter.CurrentPage);
                dbDatabase.AddInParameter(dbCommand, "@sort", DbType.String, objCarsFilter.Sort);
                dbDatabase.AddInParameter(dbCommand, "@pageSize", DbType.Int64, objCarsFilter.PageSize);
                dbDatabase.AddInParameter(dbCommand, "@zipcode", DbType.String, objCarsFilter.ZipCode);


                dbDatabase.AddInParameter(dbCommand, "@Mileage1", DbType.String, objCarsFilter.Mileage1);
                dbDatabase.AddInParameter(dbCommand, "@Mileage2", DbType.String, objCarsFilter.Mileage2);
                dbDatabase.AddInParameter(dbCommand, "@Mileage3", DbType.String, objCarsFilter.Mileage3);
                dbDatabase.AddInParameter(dbCommand, "@Mileage4", DbType.String, objCarsFilter.Mileage4);
                dbDatabase.AddInParameter(dbCommand, "@Mileage5", DbType.String, objCarsFilter.Mileage5);
                dbDatabase.AddInParameter(dbCommand, "@Mileage6", DbType.String, objCarsFilter.Mileage6);
                dbDatabase.AddInParameter(dbCommand, "@Mileage7", DbType.String, objCarsFilter.Mileage7);

                dbDatabase.AddInParameter(dbCommand, "@Year1a", DbType.String, objCarsFilter.Year1a);
                dbDatabase.AddInParameter(dbCommand, "@Year1b", DbType.String, objCarsFilter.Year1b);
                dbDatabase.AddInParameter(dbCommand, "@Year1", DbType.String, objCarsFilter.Year1);
                dbDatabase.AddInParameter(dbCommand, "@Year2", DbType.String, objCarsFilter.Year2);
                dbDatabase.AddInParameter(dbCommand, "@Year3", DbType.String, objCarsFilter.Year3);
                dbDatabase.AddInParameter(dbCommand, "@Year4", DbType.String, objCarsFilter.Year4);
                dbDatabase.AddInParameter(dbCommand, "@Year5", DbType.String, objCarsFilter.Year5);
                dbDatabase.AddInParameter(dbCommand, "@Year6", DbType.String, objCarsFilter.Year6);
                dbDatabase.AddInParameter(dbCommand, "@Year7", DbType.String, objCarsFilter.Year7);
                dbDatabase.AddInParameter(dbCommand, "@Price1", DbType.String, objCarsFilter.Price1);
                dbDatabase.AddInParameter(dbCommand, "@Price2", DbType.String, objCarsFilter.Price2);
                dbDatabase.AddInParameter(dbCommand, "@Price3", DbType.String, objCarsFilter.Price3);
                dbDatabase.AddInParameter(dbCommand, "@Price4", DbType.String, objCarsFilter.Price4);
                dbDatabase.AddInParameter(dbCommand, "@Price5", DbType.String, objCarsFilter.Price5);               


                //objUsedCars.Executing stored procedure
                UsedCarsDataReader = dbDatabase.ExecuteReader(dbCommand);

                //DataSet  DS = dbDatabase.ExecuteDataSet(dbCommand);

                while (UsedCarsDataReader.Read())
                {
                    //  objUsedCars.Assign values to the CarsInfo object list
                    UsedCarsInfo ObjCarsInfo_Info = new UsedCarsInfo();
                    AssignCarsInfoList(UsedCarsDataReader, ObjCarsInfo_Info);
                    UsedCarsIList.Add(ObjCarsInfo_Info);
                }


            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, Global.EXCEPTION_POLICY);

                if (rethrow)
                    throw;
            }
            finally
            {
                UsedCarsDataReader.Close();
            }

            return UsedCarsIList;
        }
        private void AssignCarsInfoList(IDataReader UsedCarsDataReader, UsedCarsInfo objUsedCars)
        {
            try
            {


                objUsedCars.PostingID = Convert.ToInt32(UsedCarsDataReader["PostingID"].ToString());
                objUsedCars.Carid = Convert.ToInt32(UsedCarsDataReader["Carid"].ToString());
                objUsedCars.SellerType = UsedCarsDataReader["SellerType"].ToString();
                objUsedCars.SellerID = Convert.ToInt32(UsedCarsDataReader["SellerID"].ToString());
                objUsedCars.DateOfPosting = Convert.ToDateTime(UsedCarsDataReader["DateOfPosting"].ToString());
                objUsedCars.ExpirtyDate = UsedCarsDataReader["ExpirtyDate"].ToString() == "" ? System.DateTime.Now : Convert.ToDateTime(UsedCarsDataReader["ExpirtyDate"].ToString());
                objUsedCars.PackageID = UsedCarsDataReader["PackageID"].ToString() == "" ? 0 : Convert.ToInt32(UsedCarsDataReader["PackageID"].ToString());
                objUsedCars.PaymentID = UsedCarsDataReader["PaymentID"].ToString() == "" ? 0 : Convert.ToInt32(UsedCarsDataReader["PaymentID"].ToString());
                objUsedCars.IsActive = UsedCarsDataReader["IsActive"].ToString() == "" ? true : Convert.ToBoolean(UsedCarsDataReader["IsActive"].ToString());
                objUsedCars.InternalreviewID = UsedCarsDataReader["InternalreviewID"].ToString() == "" ? 0 : Convert.ToInt32(UsedCarsDataReader["InternalreviewID"].ToString());
                objUsedCars.CancelledBy = UsedCarsDataReader["CancelledBy"].ToString() == "" ? 0 : Convert.ToInt32(UsedCarsDataReader["CancelledBy"].ToString());
                objUsedCars.CancelledReason = UsedCarsDataReader["CancelledReason"].ToString();
                objUsedCars.CancelledDate = UsedCarsDataReader["CancelledDate"].ToString() == "" ? System.DateTime.Now : Convert.ToDateTime(UsedCarsDataReader["CancelledDate"].ToString());
                objUsedCars.Zipcode = UsedCarsDataReader["Zipcode"].ToString();
                objUsedCars.Uid = UsedCarsDataReader["Uid"].ToString() == "" ? 0 : Convert.ToInt32(UsedCarsDataReader["Uid"].ToString());

                objUsedCars.SellerName = UsedCarsDataReader["SellerName"].ToString();
                objUsedCars.Address1 = UsedCarsDataReader["Address1"].ToString() == "" ? "Emp" : UsedCarsDataReader["Address1"].ToString();
                objUsedCars.Address2 = UsedCarsDataReader["Address2"].ToString() == "" ? "Emp" : UsedCarsDataReader["Address2"].ToString();
                objUsedCars.City = UsedCarsDataReader["City"].ToString() == "" ? "Emp" : UsedCarsDataReader["City"].ToString();
                objUsedCars.State = UsedCarsDataReader["State"].ToString();
                objUsedCars.Zip = UsedCarsDataReader["Zip"].ToString();
                objUsedCars.Country = UsedCarsDataReader["Country"].ToString() == "1" ? "USA" : UsedCarsDataReader["Country"].ToString();
                objUsedCars.Phone = UsedCarsDataReader["Phone"].ToString();
                objUsedCars.AltPhone = UsedCarsDataReader["AltPhone"].ToString();
                objUsedCars.Fax = UsedCarsDataReader["Fax"].ToString();
                objUsedCars.Email = UsedCarsDataReader["Email"].ToString() == "" ? "Emp" : UsedCarsDataReader["Email"].ToString();
                objUsedCars.AltEmail = UsedCarsDataReader["AltEmail"].ToString() == "" ? "Emp" : UsedCarsDataReader["Email"].ToString();
                objUsedCars.NotesForBuyers = UsedCarsDataReader["NotesForBuyers"].ToString();
                objUsedCars.Model = UsedCarsDataReader["model"].ToString();
                objUsedCars.Make = UsedCarsDataReader["make"].ToString();
                objUsedCars.YearOfMake = UsedCarsDataReader["yearOfMake"].ToString() == "" ? 0 : Convert.ToInt32(UsedCarsDataReader["yearOfMake"].ToString());
                objUsedCars.Mileage = UsedCarsDataReader["mileage"].ToString() == "" ? "0" : (UsedCarsDataReader["mileage"].ToString());
                objUsedCars.MakeID = UsedCarsDataReader["makeID"].ToString() == "" ? 0 : Convert.ToInt32(UsedCarsDataReader["makeID"].ToString());
                objUsedCars.MakeModelID = UsedCarsDataReader["makeModelID"].ToString() == "" ? 0 : Convert.ToInt32(UsedCarsDataReader["makeModelID"].ToString());
                objUsedCars.Price = UsedCarsDataReader["price"].ToString() == "" ? 0.00 : Convert.ToDouble(UsedCarsDataReader["price"].ToString());
                objUsedCars.Description = UsedCarsDataReader["description"].ToString() == "" ? "Emp" : UsedCarsDataReader["description"].ToString();

                objUsedCars.Bodytype = UsedCarsDataReader["bodytype"].ToString();
                objUsedCars.BodytypeID = Convert.ToInt32(UsedCarsDataReader["BodytypeID"].ToString());
                objUsedCars.FueltypeId = Convert.ToInt32(UsedCarsDataReader["FueltypeID"].ToString());
                objUsedCars.Fueltype = UsedCarsDataReader["Fueltype"].ToString();

                objUsedCars.ExteriorColor = UsedCarsDataReader["exteriorColor"].ToString() == "" ? "Emp" : UsedCarsDataReader["exteriorColor"].ToString();
                objUsedCars.NumberOfSeats = UsedCarsDataReader["numberOfSeats"].ToString() == "" ? "Emp" : UsedCarsDataReader["numberOfSeats"].ToString();
                objUsedCars.NumberOfDoors = UsedCarsDataReader["numberOfDoors"].ToString() == "" ? "Emp" : UsedCarsDataReader["numberOfDoors"].ToString();
                objUsedCars.NumberOfCylinder = UsedCarsDataReader["numberOfCylinder"].ToString() == "" ? "Emp" : UsedCarsDataReader["numberOfCylinder"].ToString();
                objUsedCars.Transmission = UsedCarsDataReader["Transmission"].ToString() == "" ? "Emp" : UsedCarsDataReader["Transmission"].ToString();
                objUsedCars.InteriorColor = UsedCarsDataReader["interiorColor"].ToString() == "" ? "Emp" : UsedCarsDataReader["interiorColor"].ToString();
                objUsedCars.UserFeedback = UsedCarsDataReader["UserFeedback"].ToString();
                objUsedCars.VIN = UsedCarsDataReader["VIN"].ToString() == "" ? "Emp" : UsedCarsDataReader["VIN"].ToString();

                objUsedCars.PIC0 = UsedCarsDataReader["PIC0"].ToString() == "" ? GetStockURL(objUsedCars.Make, objUsedCars.Model) : UsedCarsDataReader["PIC0"].ToString();
                objUsedCars.PIC1 = UsedCarsDataReader["PIC1"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC1"].ToString();
                objUsedCars.PIC2 = UsedCarsDataReader["PIC2"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC2"].ToString();
                objUsedCars.PIC3 = UsedCarsDataReader["PIC3"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC3"].ToString();
                objUsedCars.PIC4 = UsedCarsDataReader["PIC4"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC4"].ToString();
                objUsedCars.PIC5 = UsedCarsDataReader["PIC5"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC5"].ToString();
                objUsedCars.PIC6 = UsedCarsDataReader["PIC6"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC6"].ToString();
                objUsedCars.PIC7 = UsedCarsDataReader["PIC7"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC7"].ToString();
                objUsedCars.PIC8 = UsedCarsDataReader["PIC8"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC8"].ToString();
                objUsedCars.PIC9 = UsedCarsDataReader["PIC9"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC9"].ToString();
                objUsedCars.PIC10 = UsedCarsDataReader["PIC10"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC10"].ToString();
                objUsedCars.PICLOC0 = UsedCarsDataReader["PICLOC0"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC0"].ToString();
                objUsedCars.PICLOC1 = UsedCarsDataReader["PICLOC1"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC1"].ToString();
                objUsedCars.PICLOC2 = UsedCarsDataReader["PICLOC2"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC2"].ToString();
                objUsedCars.PICLOC3 = UsedCarsDataReader["PICLOC3"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC3"].ToString();
                objUsedCars.PICLOC4 = UsedCarsDataReader["PICLOC4"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC4"].ToString();
                objUsedCars.PICLOC5 = UsedCarsDataReader["PICLOC5"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC5"].ToString();
                objUsedCars.PICLOC6 = UsedCarsDataReader["PICLOC6"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC6"].ToString();
                objUsedCars.PICLOC7 = UsedCarsDataReader["PICLOC7"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC7"].ToString();
                objUsedCars.PICLOC8 = UsedCarsDataReader["PICLOC8"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC8"].ToString();
                objUsedCars.PICLOC9 = UsedCarsDataReader["PICLOC9"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC9"].ToString();
                objUsedCars.PICLOC10 = UsedCarsDataReader["PICLOC10"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC10"].ToString();

                objUsedCars.PIC11 = UsedCarsDataReader["PIC11"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC11"].ToString();
                objUsedCars.PIC12 = UsedCarsDataReader["PIC12"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC12"].ToString();
                objUsedCars.PIC13 = UsedCarsDataReader["PIC13"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC13"].ToString();
                objUsedCars.PIC14 = UsedCarsDataReader["PIC14"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC14"].ToString();
                objUsedCars.PIC15 = UsedCarsDataReader["PIC15"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC15"].ToString();
                objUsedCars.PIC16 = UsedCarsDataReader["PIC16"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC16"].ToString();
                objUsedCars.PIC17 = UsedCarsDataReader["PIC17"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC17"].ToString();
                objUsedCars.PIC18 = UsedCarsDataReader["PIC18"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC18"].ToString();
                objUsedCars.PIC19 = UsedCarsDataReader["PIC19"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC19"].ToString();
                objUsedCars.PIC20 = UsedCarsDataReader["PIC20"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC20"].ToString();


                objUsedCars.PICLOC11 = UsedCarsDataReader["PICLOC11"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC11"].ToString();
                objUsedCars.PICLOC12 = UsedCarsDataReader["PICLOC12"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC12"].ToString();
                objUsedCars.PICLOC13 = UsedCarsDataReader["PICLOC13"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC13"].ToString();
                objUsedCars.PICLOC14 = UsedCarsDataReader["PICLOC14"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC14"].ToString();
                objUsedCars.PICLOC15 = UsedCarsDataReader["PICLOC15"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC15"].ToString();
                objUsedCars.PICLOC16 = UsedCarsDataReader["PICLOC16"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC16"].ToString();
                objUsedCars.PICLOC17 = UsedCarsDataReader["PICLOC17"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC17"].ToString();
                objUsedCars.PICLOC18 = UsedCarsDataReader["PICLOC18"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC18"].ToString();
                objUsedCars.PICLOC19 = UsedCarsDataReader["PICLOC19"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC19"].ToString();
                objUsedCars.PICLOC20 = UsedCarsDataReader["PICLOC20"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC20"].ToString();


                objUsedCars.ConditionDescription = UsedCarsDataReader["ConditionDescription"].ToString() == "" ? "Emp" : UsedCarsDataReader["ConditionDescription"].ToString();
                objUsedCars.DriveTrain = UsedCarsDataReader["DriveTrain"].ToString() == "" ? "Emp" : UsedCarsDataReader["DriveTrain"].ToString();


                objUsedCars.RowNumber = UsedCarsDataReader["RowNumber"].ToString() == "" ? "Emp" : UsedCarsDataReader["RowNumber"].ToString();
                objUsedCars.TotalRecords = UsedCarsDataReader["TotalRecords"].ToString() == "" ? "Emp" : UsedCarsDataReader["TotalRecords"].ToString();

                objUsedCars.PageCount = UsedCarsDataReader["PageCount"].ToString() == "" ? "Emp" : UsedCarsDataReader["PageCount"].ToString();

                objUsedCars.Title = UsedCarsDataReader["Title"].ToString() == "" ? "Emp" : UsedCarsDataReader["Title"].ToString();

                objUsedCars.AdStatus = UsedCarsDataReader["AdStatus"].ToString() == "" ? "Emp" : UsedCarsDataReader["AdStatus"].ToString();

                objUsedCars.CarUniqueID = UsedCarsDataReader["CarUniqueID"].ToString() == "" ? "Emp" : UsedCarsDataReader["CarUniqueID"].ToString();



                //objUsedCars.pic0 = UsedCarsDataReader["pic0"].ToString();


            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, Global.EXCEPTION_POLICY);

            }



        }
        private string GetStockURL(string Make, string Model)
        {
            string StockUrl = string.Empty;

            {
                string StockMake = Make;
                StockMake = StockMake.Replace(" ", "-");
                StockMake = StockMake.Replace("/", "@");
                StockMake = StockMake.Replace("&", "@");
                string StockType = Model.ToString().Replace('&', '@');
                StockType = StockType.Replace("/", "@");
                StockType = StockType.Replace(" ", "-");
                StockUrl = "images/MakeModelThumbs/" + StockMake + "_" + StockType + ".jpg";
            }




            return StockUrl;
        }

    }
}
