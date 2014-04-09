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
    public class PreferencesBL
    {

        public DataSet SaveSubscribe(PreferenceInfo  ObjPreferncesInfo,int  Isactive)
        {
            DataSet dsResult = new DataSet();

            string spNameString = string.Empty;

            bool bsucess = false;


            //Setting Connection
            //Global.INSTANCE_NAME = strCurrentConn;

            IDataReader ModelsInfoDataReader = null;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //Assign stored procedure name

            spNameString = "[Save_SubScribe]";
            DbCommand dbCommand = null;

            try
            {

                //Set stored procedure to the command object


                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@UserPreferID", DbType.Int64, ObjPreferncesInfo.PreferenceID);
                dbDatabase.AddInParameter(dbCommand, "@Name", DbType.String, ObjPreferncesInfo.Name );
                dbDatabase.AddInParameter(dbCommand, "@Email", DbType.String, ObjPreferncesInfo.Email  );

                dbDatabase.AddInParameter(dbCommand, "@Phone", DbType.String, ObjPreferncesInfo.Phone );
                dbDatabase.AddInParameter(dbCommand, "@IPAddress", DbType.String, ObjPreferncesInfo.IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@Zip", DbType.String, ObjPreferncesInfo.Zip);

                dbDatabase.AddInParameter(dbCommand, "@Isactive", DbType.Int32, Isactive);

                
                

                //Executing stored procedure


                dsResult = dbDatabase.ExecuteDataSet(dbCommand);


                bsucess = true;

            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, Global.EXCEPTION_POLICY);

                if (rethrow)
                    throw;
            }

            return dsResult;
        }

        public DataSet SaveSubScribeItems(PreferncesItemsInfo ObjPreferncesInfo, bool IsActive)
        {
            DataSet dsResult = new DataSet();

            string spNameString = string.Empty;

            bool bsucess = false;


            //Setting Connection
            //Global.INSTANCE_NAME = strCurrentConn;

            IDataReader ModelsInfoDataReader = null;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //Assign stored procedure name

            spNameString = "[Save_SubScribeItems]";
            DbCommand dbCommand = null;

            try
            {

                //Set stored procedure to the command object


                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@PreferenceID", DbType.String, ObjPreferncesInfo.PreferenceID);
                dbDatabase.AddInParameter(dbCommand, "@UserPreferenceID", DbType.String, ObjPreferncesInfo.UserPreferID);
                dbDatabase.AddInParameter(dbCommand, "@Makeid", DbType.String, ObjPreferncesInfo.Makeid);
                dbDatabase.AddInParameter(dbCommand, "@ModelID", DbType.String, ObjPreferncesInfo.ModelID);
                dbDatabase.AddInParameter(dbCommand, "@PriceRange", DbType.String, ObjPreferncesInfo.PriceRange);
                dbDatabase.AddInParameter(dbCommand, "@IsActive", DbType.Boolean, IsActive);
                
                //Executing stored procedure


                dsResult = dbDatabase.ExecuteDataSet(dbCommand);


                bsucess = true;

            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, Global.EXCEPTION_POLICY);

                if (rethrow)
                    throw;
            }

            return dsResult;
        }
        public bool SubScribeStatus(string PreferenceID, int Status)
        {


            string spNameString = string.Empty;

            bool bsucess = false;


            //Setting Connection
            //Global.INSTANCE_NAME = strCurrentConn;

            IDataReader ModelsInfoDataReader = null;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //Assign stored procedure name

            spNameString = "[UpdateSubScribeStatus]";
            DbCommand dbCommand = null;

            try
            {

                //@pmntStatus int,
                //@TransactionID varchar(500),
                //@Currency varchar(500),
                //@UID int,
                //@PackageID int,
                //@CarID int
                //Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@PrefercenceID", DbType.String, PreferenceID);
                dbDatabase.AddInParameter(dbCommand, "@Status", DbType.String, Status);

                //Executing stored procedure
                dbDatabase.ExecuteNonQuery(dbCommand);


                bsucess = true;

            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, Global.EXCEPTION_POLICY);

                if (rethrow)
                    throw;
            }

            return bsucess;
        }

        public DataSet GetEmailPreferences(string PreferenceID)
        {

            DataSet dsPreferences = new DataSet();
            string spNameString = string.Empty;

            bool bsucess = false;


            //Setting Connection
            //Global.INSTANCE_NAME = strCurrentConn;

            IDataReader ModelsInfoDataReader = null;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //Assign stored procedure name

            spNameString = "[GetEmailPreferences]";
            DbCommand dbCommand = null;

            try
            {


                //Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@PrefercenceID", DbType.String, PreferenceID);

                //Executing stored procedure
                dsPreferences = dbDatabase.ExecuteDataSet(dbCommand);


                bsucess = true;

            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, Global.EXCEPTION_POLICY);

                if (rethrow)
                    throw;
            }

            return dsPreferences;
        }
        public DataSet GetEmailPreferencesbyEmail(string PreferenceEMail)
        {

            DataSet dsPreferences = new DataSet();
            string spNameString = string.Empty;

            bool bsucess = false;


            //Setting Connection
            //Global.INSTANCE_NAME = strCurrentConn;

            IDataReader ModelsInfoDataReader = null;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //Assign stored procedure name

            spNameString = "[GetEmailPreferencesbyEmail]";
            DbCommand dbCommand = null;

            try
            {


                //Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@Email", DbType.String, PreferenceEMail);

                //Executing stored procedure
                dsPreferences = dbDatabase.ExecuteDataSet(dbCommand);


                bsucess = true;

            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, Global.EXCEPTION_POLICY);

                if (rethrow)
                    throw;
            }

            return dsPreferences;
        }


        //
        //
    }
}
