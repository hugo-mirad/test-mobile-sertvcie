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

namespace CarsBL.Transactions
{
    public class CarsBL
    {
        public IList<CarsInfo.CarsInfo> GetCarsearch(string Carid)
        {
            //Decalaring CarsInfo division object collection
            IList<CarsInfo.CarsInfo> CarsInfoIList = new List<CarsInfo.CarsInfo>();

            string spNameString = string.Empty;


            //Setting Connection
            //Global.INSTANCE_NAME = strCurrentConn;

            IDataReader CarsInfoDataReader = null;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //Assign stored procedure name

            spNameString = "[USP_SearchCars]";
            DbCommand dbCommand = null;

            try
            {
                //Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter( dbCommand, "@makeID", DbType.Int64, Carid);
                


                //Executing stored procedure
                CarsInfoDataReader = dbDatabase.ExecuteReader(dbCommand);

                while (CarsInfoDataReader.Read())
                {
                    //Assign values to the CarsInfo object list
                    CarsInfo.CarsInfo ObjCarsInfo_Info = new CarsInfo.CarsInfo();
                    AssignCarsInfoList(CarsInfoDataReader, ObjCarsInfo_Info);
                    CarsInfoIList.Add(ObjCarsInfo_Info);
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
                CarsInfoDataReader.Close();
            }

            return CarsInfoIList;
        }
        private void AssignCarsInfoList(IDataReader CarsInfoDataReader, CarsInfo.CarsInfo objCarsInfo)
        {
            try
            {
                objCarsInfo.CarID = int.Parse(CarsInfoDataReader["makeID"].ToString());
                objCarsInfo.YearOfMake  = int.Parse( CarsInfoDataReader["yearOfMake"].ToString());
                objCarsInfo.MakeModelID=int.Parse(CarsInfoDataReader["makeModelID"].ToString());
                objCarsInfo.MakeModel = CarsInfoDataReader["MakeModel"].ToString();
                objCarsInfo.Make = CarsInfoDataReader["Make"].ToString();
                objCarsInfo.Mileage = CarsInfoDataReader["mileage"].ToString();
                objCarsInfo.Zipcode = CarsInfoDataReader["zipcode"].ToString();
                objCarsInfo.VehicleConditionID = CarsInfoDataReader["vehicleConditionID"].ToString();
                objCarsInfo.VehicleCondition = CarsInfoDataReader["VehicleCondition"].ToString();
                objCarsInfo.Description = CarsInfoDataReader["description"].ToString();
                objCarsInfo.Price = CarsInfoDataReader["price"].ToString();
                objCarsInfo.Pic1  = CarsInfoDataReader["pic1"].ToString();
                objCarsInfo.Pic2 = CarsInfoDataReader["pic2"].ToString();
                objCarsInfo.Pic3 = CarsInfoDataReader["pic3"].ToString();
                objCarsInfo.Pic4 = CarsInfoDataReader["pic4"].ToString();
                objCarsInfo.Pic5 = CarsInfoDataReader["pic5"].ToString();
                objCarsInfo.Pic6 = CarsInfoDataReader["pic6"].ToString();
                objCarsInfo.Pic7 = CarsInfoDataReader["pic7"].ToString();
                objCarsInfo.Pic8 = CarsInfoDataReader["pic8"].ToString();
                objCarsInfo.Pic9 = CarsInfoDataReader["pic9"].ToString();
                objCarsInfo.Pic10 = CarsInfoDataReader["pic10"].ToString();
                objCarsInfo.BodyTypeID = int.Parse(CarsInfoDataReader["bodyTypeID"].ToString());
                objCarsInfo.BodyType = CarsInfoDataReader["BodyType"].ToString();
                objCarsInfo.Miles_per_gallon = CarsInfoDataReader["Miles_per_gallon"].ToString();
                objCarsInfo.FuelTypeID = int.Parse(CarsInfoDataReader["fuelTypeID"].ToString());
                objCarsInfo.FuelType = int.Parse(CarsInfoDataReader["FuelType"].ToString());
                objCarsInfo.UserFeedback = CarsInfoDataReader["userFeedback"].ToString();
                objCarsInfo.ExteriorColor = CarsInfoDataReader["exteriorColor"].ToString();
                objCarsInfo.InteriorColor = CarsInfoDataReader["interiorColor"].ToString();
                objCarsInfo.NumberOfCylinder = CarsInfoDataReader["numberOfCylinder"].ToString();
                objCarsInfo.Transmission=CarsInfoDataReader["makeModelID"].ToString();
                objCarsInfo.NumberOfDoors=CarsInfoDataReader["numberOfDoors"].ToString();
                objCarsInfo.NumberOfSeats=CarsInfoDataReader["numberOfSeats"].ToString();
                objCarsInfo.VIN=CarsInfoDataReader["VIN"].ToString();

                
            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, Global.EXCEPTION_POLICY);

            }
        }
    }
}
