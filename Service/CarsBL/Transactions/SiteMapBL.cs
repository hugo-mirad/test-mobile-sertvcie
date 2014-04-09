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
    public class SiteMapBL
    {
        public DataSet  SearchUsedCars()
        {
            ///objUsedCars.Decalaring CarsInfo division object collection
           

            string spNameString = string.Empty;


            //objUsedCars.Setting Connection
            //objUsedCars.Global.INSTANCE_NAME = strCurrentConn;

            DataSet  UsedCarsdsSiteMap = null;


            //objUsedCars.Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //objUsedCars.Assign stored procedure name

            spNameString = "[USP_GetXMLSiteMap]";
            DbCommand dbCommand = null;

            try
            {
                
                //objUsedCars.Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbCommand.CommandTimeout= 5000; 


                //objUsedCars.Executing stored procedure
                UsedCarsdsSiteMap = dbDatabase.ExecuteDataSet(dbCommand);

                
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

            return UsedCarsdsSiteMap;
        }


        public DataSet XmlSiteMapbyCityState()
        {
            ///objUsedCars.Decalaring CarsInfo division object collection


            string spNameString = string.Empty;


            //objUsedCars.Setting Connection
            //objUsedCars.Global.INSTANCE_NAME = strCurrentConn;

            DataSet UsedCarsdsSiteMap = null;


            //objUsedCars.Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //objUsedCars.Assign stored procedure name

            spNameString = "[GetStateWiseURL]";
            DbCommand dbCommand = null;

            try
            {

                //objUsedCars.Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbCommand.CommandTimeout = 5000;


                //objUsedCars.Executing stored procedure
                UsedCarsdsSiteMap = dbDatabase.ExecuteDataSet(dbCommand);


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

            return UsedCarsdsSiteMap;
        }



    }
}
