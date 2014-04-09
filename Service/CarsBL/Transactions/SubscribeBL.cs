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
    public class SubscribeBL
    {
        //


        public DataSet SaveSubscribe(string MakeID, string ModelID, string Zipcode,
            string Withinzip, string PriceRange, string Name, string Email)
        {
            ///objUsedCars.Decalaring CarsInfo division object collection


            string spNameString = string.Empty;


            //objUsedCars.Setting Connection
            //objUsedCars.Global.INSTANCE_NAME = strCurrentConn;

            DataSet dsSubscribeID = null;


            //objUsedCars.Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.CENTRAL_INSTANCE_NAME);

            //objUsedCars.Assign stored procedure name

            spNameString = "[Save_SubScribeItems]";
            DbCommand dbCommand = null;

            try
            {
                //objUsedCars.Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                dbCommand.CommandTimeout = 10000;

                dbDatabase.AddInParameter(dbCommand, "@MakeID", DbType.String, MakeID);
                dbDatabase.AddInParameter(dbCommand, "@ModelID", DbType.String, ModelID);
                dbDatabase.AddInParameter(dbCommand, "@Zipcode", DbType.Int64, Zipcode);
                dbDatabase.AddInParameter(dbCommand, "@Withinzip", DbType.String, Withinzip);
                dbDatabase.AddInParameter(dbCommand, "@PriceRange", DbType.String, PriceRange);
                dbDatabase.AddInParameter(dbCommand, "@Name", DbType.String, Name);
                dbDatabase.AddInParameter(dbCommand, "@Email", DbType.String, Email);


                //objUsedCars.Executing stored procedure
                dsSubscribeID = dbDatabase.ExecuteDataSet(dbCommand);


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

            return dsSubscribeID;
        }

        public DataSet SaveSubscribe(string SubScribeID)
        {
            ///objUsedCars.Decalaring CarsInfo division object collection


            string spNameString = string.Empty;


            //objUsedCars.Setting Connection
            //objUsedCars.Global.INSTANCE_NAME = strCurrentConn;

            DataSet dsSubscribeID = null;


            //objUsedCars.Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.CENTRAL_INSTANCE_NAME);

            //objUsedCars.Assign stored procedure name

            spNameString = "[USP_GetSubScribeItems]";
            DbCommand dbCommand = null;

            try
            {
                //objUsedCars.Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                dbCommand.CommandTimeout = 10000;

                dbDatabase.AddInParameter(dbCommand, "@SubscribeID", DbType.String, SubScribeID);


                //objUsedCars.Executing stored procedure
                dsSubscribeID = dbDatabase.ExecuteDataSet(dbCommand);


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

            return dsSubscribeID;
        }

        //UpdateSubScribeStatus


    }
}
