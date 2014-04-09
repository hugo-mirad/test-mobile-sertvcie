/**********************************************************************
' MODULE       : Master
' FILENAME     : Master.cs
' AUTHOR       : Shravan
' CREATED      : 04-Jan-2012
' DESCRIPTION  : Business Logic to search used cars.
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
    public class CarsPictures
    {

        public DataSet GetCarPictures(string carId)
        {
            ///objUsedCars.Decalaring CarsInfo division object collection
            IList<CarPicturesInfo> UsedCarsIList = new List<CarPicturesInfo>();

            string spNameString = string.Empty;


            //objUsedCars.Setting Connection
            //objUsedCars.Global.INSTANCE_NAME = strCurrentConn;

            DataSet  UsedCarsDataReader = new DataSet() ;


            //objUsedCars.Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //objUsedCars.Assign stored procedure name

            spNameString = "[GetCarPictures]";
            DbCommand dbCommand = null;

            try
            {
                //objUsedCars.Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbCommand.CommandTimeout = 10000;

                dbDatabase.AddInParameter(dbCommand, "@carid", DbType.String, carId);

                //objUsedCars.Executing stored procedure
                UsedCarsDataReader = dbDatabase.ExecuteDataSet(dbCommand);

                //while (UsedCarsDataReader.Read())
                //{
                //    //  objUsedCars.Assign values to the CarsInfo object list
                //    CarPicturesInfo ObjCarsInfo_Info = new CarPicturesInfo();
                //    AssignCarsInfoList(UsedCarsDataReader, ObjCarsInfo_Info);
                //    UsedCarsIList.Add(ObjCarsInfo_Info);
                //}
            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, Global.EXCEPTION_POLICY);

                if (rethrow)
                    throw;
            }
            finally
            {
                //UsedCarsDataReader.Close();
            }

            return UsedCarsDataReader;
        }

        private void AssignCarsInfoList(IDataReader UsedCarsDataReader, CarPicturesInfo objUsedCars)
        {
            try
            {


                objUsedCars.carID = Convert.ToInt32(UsedCarsDataReader["Carid"].ToString());

                



                objUsedCars.SellerName = UsedCarsDataReader["SellerName"].ToString() == "" ? "Emp" : UsedCarsDataReader["SellerName"].ToString();

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
                objUsedCars.Model = UsedCarsDataReader["model"].ToString();
                objUsedCars.Make = UsedCarsDataReader["make"].ToString();
                objUsedCars.YearOfMake = UsedCarsDataReader["yearOfMake"].ToString() == "" ? 0 : Convert.ToInt32(UsedCarsDataReader["yearOfMake"].ToString());

                objUsedCars.Category_Name = UsedCarsDataReader["Category_Name"].ToString() == "" ? "Emp" : (UsedCarsDataReader["Category_Name"].ToString());

                objUsedCars.TypeName = UsedCarsDataReader["TypeName"].ToString() == "" ? "Emp"  : (UsedCarsDataReader["TypeName"].ToString());
                //objUsedCars.MakeModelID = UsedCarsDataReader["makeModelID"].ToString() == "" ? 0 : Convert.ToInt32(UsedCarsDataReader["makeModelID"].ToString());

                //objUsedCars.Bodytype = UsedCarsDataReader["bodytype"].ToString();
                //objUsedCars.BodytypeID = Convert.ToInt32(UsedCarsDataReader["BodytypeID"].ToString() == "" ? "0" : UsedCarsDataReader["BodytypeID"].ToString().ToString());
                //objUsedCars.NumberOfSeats = UsedCarsDataReader["numberOfSeats"].ToString() == "" ? "Emp" : UsedCarsDataReader["numberOfSeats"].ToString();
                //objUsedCars.NumberOfDoors = UsedCarsDataReader["numberOfDoors"].ToString() == "" ? "Emp" : UsedCarsDataReader["numberOfDoors"].ToString();
                //objUsedCars.NumberOfCylinder = UsedCarsDataReader["numberOfCylinder"].ToString() == "" ? "Emp" : UsedCarsDataReader["numberOfCylinder"].ToString();

                objUsedCars.PIC0 = UsedCarsDataReader["PIC0"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC0"].ToString();
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

                //objUsedCars.PICDesc1 = UsedCarsDataReader["PICDesc1"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICDesc1"].ToString();

                //objUsedCars.PICDesc1 = UsedCarsDataReader["PICDesc1"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc1"].ToString();
                //objUsedCars.PICDesc2 = UsedCarsDataReader["PicDesc2"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc2"].ToString();
                //objUsedCars.PICDesc3 = UsedCarsDataReader["PicDesc3"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc3"].ToString();
                //objUsedCars.PICDesc4 = UsedCarsDataReader["PicDesc4"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc4"].ToString();
                //objUsedCars.PICDesc5  = UsedCarsDataReader["PicDesc5"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc5"].ToString();
                //objUsedCars.PICDesc6 = UsedCarsDataReader["PicDesc6"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc6"].ToString();
                //objUsedCars.PICDesc7 = UsedCarsDataReader["PicDesc7"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc7"].ToString();
                //objUsedCars.PICDesc8 = UsedCarsDataReader["PicDesc8"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc8"].ToString();
                //objUsedCars.PICDesc9 = UsedCarsDataReader["PicDesc9"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc9"].ToString();
                //objUsedCars.PICDesc10 = UsedCarsDataReader["PicDesc10"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc10"].ToString();
                //objUsedCars.PICDesc11 = UsedCarsDataReader["PicDesc11"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc11"].ToString();
                //objUsedCars.PICDesc12 = UsedCarsDataReader["PicDesc12"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc12"].ToString();
                //objUsedCars.PICDesc13 = UsedCarsDataReader["PicDesc13"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc13"].ToString();
                //objUsedCars.PICDesc14 = UsedCarsDataReader["PicDesc14"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc14"].ToString();
                //objUsedCars.PICDesc15 = UsedCarsDataReader["PicDesc15"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc15"].ToString();
                //objUsedCars.PICDesc16 = UsedCarsDataReader["PicDesc16"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc16"].ToString();
                //objUsedCars.PICDesc17 = UsedCarsDataReader["PicDesc17"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc17"].ToString();
                //objUsedCars.PICDesc18 = UsedCarsDataReader["PicDesc18"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc18"].ToString();
                //objUsedCars.PICDesc19 = UsedCarsDataReader["PicDesc19"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc19"].ToString();
                //objUsedCars.PICDesc20 = UsedCarsDataReader["PicDesc20"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc20"].ToString();
                //objUsedCars.PICDesc21 = UsedCarsDataReader["PicDesc21"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc21"].ToString();
                //objUsedCars.PICDesc22 = UsedCarsDataReader["PicDesc22"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc22"].ToString();
                //objUsedCars.PICDesc23 = UsedCarsDataReader["PicDesc23"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc23"].ToString();
                //objUsedCars.PICDesc24 = UsedCarsDataReader["PicDesc24"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc24"].ToString();
                //objUsedCars.PICDesc25 = UsedCarsDataReader["PicDesc25"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc25"].ToString();
                //objUsedCars.PICDesc26 = UsedCarsDataReader["PicDesc26"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc26"].ToString();
                //objUsedCars.PICDesc27 = UsedCarsDataReader["PicDesc27"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc27"].ToString();
                //objUsedCars.PICDesc28 = UsedCarsDataReader["PicDesc28"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc28"].ToString();
                //objUsedCars.PICDesc29 = UsedCarsDataReader["PicDesc29"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc29"].ToString();
                //objUsedCars.PICDesc30 = UsedCarsDataReader["PicDesc30"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc30"].ToString();
                //objUsedCars.PICDesc31 = UsedCarsDataReader["PicDesc31"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc31"].ToString();
                //objUsedCars.PICDesc32 = UsedCarsDataReader["PicDesc32"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc32"].ToString();
                //objUsedCars.PICDesc33 = UsedCarsDataReader["PicDesc33"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc33"].ToString();
                //objUsedCars.PICDesc34 = UsedCarsDataReader["PicDesc34"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc34"].ToString();
                //objUsedCars.PICDesc35 = UsedCarsDataReader["PicDesc35"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc35"].ToString();
                //objUsedCars.PICDesc36 = UsedCarsDataReader["PicDesc36"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc36"].ToString();
                //objUsedCars.PICDesc37 = UsedCarsDataReader["PicDesc37"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc37"].ToString();
                //objUsedCars.PICDesc38 = UsedCarsDataReader["PicDesc38"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc38"].ToString();
                //objUsedCars.PICDesc39 = UsedCarsDataReader["PicDesc39"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc39"].ToString();
                //objUsedCars.PICDesc40 = UsedCarsDataReader["PicDesc40"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc40"].ToString();
                //objUsedCars.PICDesc41 = UsedCarsDataReader["PicDesc41"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc41"].ToString();
                //objUsedCars.PICDesc42 = UsedCarsDataReader["PicDesc42"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc42"].ToString();
                //objUsedCars.PICDesc43 = UsedCarsDataReader["PicDesc43"].ToString() == ""? "Emp" : UsedCarsDataReader["PicDesc43"].ToString();
                //objUsedCars.PICDesc44 = UsedCarsDataReader["PicDesc44"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc44"].ToString();
                //objUsedCars.PICDesc45 = UsedCarsDataReader["PicDesc45"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc45"].ToString();
                //objUsedCars.PICDesc46 = UsedCarsDataReader["PicDesc46"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc46"].ToString();
                //objUsedCars.PICDesc47 = UsedCarsDataReader["PicDesc47"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc47"].ToString();
                //objUsedCars.PICDesc48 = UsedCarsDataReader["PicDesc48"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc48"].ToString();
                //objUsedCars.PICDesc49 = UsedCarsDataReader["PicDesc49"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc49"].ToString();
                //objUsedCars.PICDesc50 = UsedCarsDataReader["PicDesc50"].ToString() == "" ? "Emp" : UsedCarsDataReader["PicDesc50"].ToString();
                objUsedCars.Price = UsedCarsDataReader["Price"].ToString() == "" ? "Emp" : UsedCarsDataReader["Price"].ToString();

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


                //objUsedCars.PIC21 = UsedCarsDataReader["PIC21"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC21"].ToString();
                //objUsedCars.PIC22 = UsedCarsDataReader["PIC22"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC22"].ToString();
                //objUsedCars.PIC23 = UsedCarsDataReader["PIC23"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC23"].ToString();
                //objUsedCars.PIC24 = UsedCarsDataReader["PIC24"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC24"].ToString();
                //objUsedCars.PIC25 = UsedCarsDataReader["PIC25"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC25"].ToString();
                //objUsedCars.PIC26 = UsedCarsDataReader["PIC26"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC26"].ToString();
                //objUsedCars.PIC27 = UsedCarsDataReader["PIC27"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC27"].ToString();
                //objUsedCars.PIC28 = UsedCarsDataReader["PIC28"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC28"].ToString();
                //objUsedCars.PIC29 = UsedCarsDataReader["PIC29"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC29"].ToString();
                //objUsedCars.PIC30 = UsedCarsDataReader["PIC30"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC30"].ToString();

                //objUsedCars.PICLOC21 = UsedCarsDataReader["PICLOC21"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC21"].ToString();
                //objUsedCars.PICLOC22 = UsedCarsDataReader["PICLOC22"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC22"].ToString();
                //objUsedCars.PICLOC23 = UsedCarsDataReader["PICLOC23"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC23"].ToString();
                //objUsedCars.PICLOC24 = UsedCarsDataReader["PICLOC24"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC24"].ToString();
                //objUsedCars.PICLOC25 = UsedCarsDataReader["PICLOC25"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC25"].ToString();
                //objUsedCars.PICLOC26 = UsedCarsDataReader["PICLOC26"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC26"].ToString();
                //objUsedCars.PICLOC27 = UsedCarsDataReader["PICLOC27"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC27"].ToString();
                //objUsedCars.PICLOC28 = UsedCarsDataReader["PICLOC28"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC28"].ToString();
                //objUsedCars.PICLOC29 = UsedCarsDataReader["PICLOC29"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC29"].ToString();
                //objUsedCars.PICLOC30 = UsedCarsDataReader["PICLOC30"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC30"].ToString();


                //objUsedCars.PIC31 = UsedCarsDataReader["PIC31"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC31"].ToString();
                //objUsedCars.PIC32 = UsedCarsDataReader["PIC32"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC32"].ToString();
                //objUsedCars.PIC33 = UsedCarsDataReader["PIC33"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC33"].ToString();
                //objUsedCars.PIC34 = UsedCarsDataReader["PIC34"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC34"].ToString();
                //objUsedCars.PIC35 = UsedCarsDataReader["PIC35"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC35"].ToString();
                //objUsedCars.PIC36 = UsedCarsDataReader["PIC36"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC36"].ToString();
                //objUsedCars.PIC37 = UsedCarsDataReader["PIC37"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC37"].ToString();
                //objUsedCars.PIC38 = UsedCarsDataReader["PIC38"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC38"].ToString();
                //objUsedCars.PIC39 = UsedCarsDataReader["PIC39"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC39"].ToString();
                //objUsedCars.PIC40 = UsedCarsDataReader["PIC40"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC40"].ToString();

                //objUsedCars.PICLOC31 = UsedCarsDataReader["PICLOC31"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC31"].ToString();
                //objUsedCars.PICLOC32 = UsedCarsDataReader["PICLOC32"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC32"].ToString();
                //objUsedCars.PICLOC33 = UsedCarsDataReader["PICLOC33"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC33"].ToString();
                //objUsedCars.PICLOC34 = UsedCarsDataReader["PICLOC34"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC34"].ToString();
                //objUsedCars.PICLOC35 = UsedCarsDataReader["PICLOC35"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC35"].ToString();
                //objUsedCars.PICLOC36 = UsedCarsDataReader["PICLOC36"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC36"].ToString();
                //objUsedCars.PICLOC37 = UsedCarsDataReader["PICLOC37"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC37"].ToString();
                //objUsedCars.PICLOC38 = UsedCarsDataReader["PICLOC38"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC38"].ToString();
                //objUsedCars.PICLOC39 = UsedCarsDataReader["PICLOC39"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC39"].ToString();
                //objUsedCars.PICLOC40 = UsedCarsDataReader["PICLOC40"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC40"].ToString();




                //objUsedCars.PIC41 = UsedCarsDataReader["PIC41"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC41"].ToString();
                //objUsedCars.PIC42 = UsedCarsDataReader["PIC42"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC42"].ToString();
                //objUsedCars.PIC43 = UsedCarsDataReader["PIC43"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC43"].ToString();
                //objUsedCars.PIC44 = UsedCarsDataReader["PIC44"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC44"].ToString();
                //objUsedCars.PIC45 = UsedCarsDataReader["PIC45"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC45"].ToString();
                //objUsedCars.PIC46 = UsedCarsDataReader["PIC46"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC46"].ToString();
                //objUsedCars.PIC47 = UsedCarsDataReader["PIC47"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC47"].ToString();
                //objUsedCars.PIC48 = UsedCarsDataReader["PIC48"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC48"].ToString();
                //objUsedCars.PIC49 = UsedCarsDataReader["PIC49"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC49"].ToString();
                //objUsedCars.PIC50 = UsedCarsDataReader["PIC50"].ToString() == "" ? "Emp" : UsedCarsDataReader["PIC50"].ToString();

                //objUsedCars.PICLOC41 = UsedCarsDataReader["PICLOC41"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC41"].ToString();
                //objUsedCars.PICLOC42 = UsedCarsDataReader["PICLOC42"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC42"].ToString();
                //objUsedCars.PICLOC43 = UsedCarsDataReader["PICLOC43"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC43"].ToString();
                //objUsedCars.PICLOC44 = UsedCarsDataReader["PICLOC44"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC44"].ToString();
                //objUsedCars.PICLOC45 = UsedCarsDataReader["PICLOC45"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC45"].ToString();
                //objUsedCars.PICLOC46 = UsedCarsDataReader["PICLOC46"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC46"].ToString();
                //objUsedCars.PICLOC47 = UsedCarsDataReader["PICLOC47"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC47"].ToString();
                //objUsedCars.PICLOC48 = UsedCarsDataReader["PICLOC48"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC48"].ToString();
                //objUsedCars.PICLOC49 = UsedCarsDataReader["PICLOC49"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC49"].ToString();
                //objUsedCars.PICLOC50 = UsedCarsDataReader["PICLOC50"].ToString() == "" ? "Emp" : UsedCarsDataReader["PICLOC50"].ToString();







                //objUsedCars.pic0 = UsedCarsDataReader["pic0"].ToString();


            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, Global.EXCEPTION_POLICY);

            }



        }


    }
}
