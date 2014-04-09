/**********************************************************************
' MODULE       : Master
' FILENAME     : Master.cs
' AUTHOR       : Shravan
' CREATED      : 31-Jan-2012
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
    public class CallRequestMobileBL
    {

        public bool SaveCallRequestMobile(string BuyerPhoneNo, string CarID, string CustomerPhoneNo)
        {

            string spNameString = string.Empty;


            //objUsedCars.Setting Connection
            //objUsedCars.Global.INSTANCE_NAME = strCurrentConn;

            IDataReader UsedCarsDataReader = null;

            //objUsedCars.Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //objUsedCars.Assign stored procedure name

            spNameString = "[SaveCallRequestMobile]";
            DbCommand dbCommand = null;

            try
            {
                //objUsedCars.Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                dbCommand.CommandTimeout = 10000;
                dbDatabase.AddInParameter(dbCommand, "@BuyerPhoneNo", DbType.String, BuyerPhoneNo);
                dbDatabase.AddInParameter(dbCommand, "@CarID", DbType.String, CarID);
                dbDatabase.AddInParameter(dbCommand, "@CustomerPhoneNo", DbType.String, CustomerPhoneNo);



                //objUsedCars.Executing stored procedure
                dbDatabase.ExecuteNonQuery(dbCommand);


            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, Global.EXCEPTION_POLICY);

                if (rethrow)
                    throw;
            }
            finally
            {
                ///dbCommand.Dispose(); 
            }

            return true;
        }
    }
}
