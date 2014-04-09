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
    public class BankDetailsBL
    {

        public bool UpdatePmntStatus(PmntDetailsinfo objPmntDetailsinfo, int PackageID, int UID, int CarID, int UserPackID, int PostingID)
        {



            string spNameString = string.Empty;

            bool bsucess = false;


            //Setting Connection
            //Global.INSTANCE_NAME = strCurrentConn;

            IDataReader ModelsInfoDataReader = null;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //Assign stored procedure name

            spNameString = "[Usp_Save_PaymentStatus]";
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

                dbDatabase.AddInParameter(dbCommand, "@Amount", DbType.String, objPmntDetailsinfo.Amount);
                dbDatabase.AddInParameter(dbCommand, "@TransactionID", DbType.String, objPmntDetailsinfo.TransactionID);
                dbDatabase.AddInParameter(dbCommand, "@pmntStatus", DbType.Int32, objPmntDetailsinfo.PmntStatus);
                dbDatabase.AddInParameter(dbCommand, "@PackageID", DbType.Int32, PackageID);
                dbDatabase.AddInParameter(dbCommand, "@UID", DbType.Int32, UID);
                dbDatabase.AddInParameter(dbCommand, "@CarID", DbType.Int32, CarID);
                dbDatabase.AddInParameter(dbCommand, "@pmntType", DbType.Int32, objPmntDetailsinfo.PmntType);
                dbDatabase.AddInParameter(dbCommand, "@IPAddress", DbType.String, objPmntDetailsinfo.IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@UserPackID", DbType.Int32, UserPackID);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", DbType.Int32, PostingID);

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
        public bool SavePmntDetails(PmntDetailsinfo objPmntDetailsinfo, int PackageID, int UID, int CarID)
        {



            string spNameString = string.Empty;

            bool bsucess = false;


            //Setting Connection
            //Global.INSTANCE_NAME = strCurrentConn;

            IDataReader ModelsInfoDataReader = null;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //Assign stored procedure name

            spNameString = "[Usp_Save_BankDetails]";
            DbCommand dbCommand = null;

            try
            {
                //Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@pmntType", DbType.Int64, objPmntDetailsinfo.PmntType);
                dbDatabase.AddInParameter(dbCommand, "@cardNumber", DbType.String, objPmntDetailsinfo.CardNumber);
                dbDatabase.AddInParameter(dbCommand, "@cardType", DbType.String, objPmntDetailsinfo.CardType);
                dbDatabase.AddInParameter(dbCommand, "@cardExpDt", DbType.String, objPmntDetailsinfo.CardExpDt);
                dbDatabase.AddInParameter(dbCommand, "@cardholderName", DbType.String, objPmntDetailsinfo.CardholderName);
                dbDatabase.AddInParameter(dbCommand, "@cardCode", DbType.String, objPmntDetailsinfo.CardCode);
                dbDatabase.AddInParameter(dbCommand, "@BillingName", DbType.String, objPmntDetailsinfo.BillingName);
                dbDatabase.AddInParameter(dbCommand, "@BillingPhone", DbType.String, objPmntDetailsinfo.BillingPhone);
                dbDatabase.AddInParameter(dbCommand, "@BillingZip", DbType.String, objPmntDetailsinfo.BillingZip);
                dbDatabase.AddInParameter(dbCommand, "@billingAdd", DbType.String, objPmntDetailsinfo.BillingAdd);
                dbDatabase.AddInParameter(dbCommand, "@billingCity", DbType.String, objPmntDetailsinfo.BillingCity);
                dbDatabase.AddInParameter(dbCommand, "@billingState", DbType.String, objPmntDetailsinfo.BillingState);
                dbDatabase.AddInParameter(dbCommand, "@IPAddress", DbType.String, objPmntDetailsinfo.IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@bankRouting", DbType.String, objPmntDetailsinfo.BankRouting);
                dbDatabase.AddInParameter(dbCommand, "@bankName", DbType.String, objPmntDetailsinfo.BankName);
                dbDatabase.AddInParameter(dbCommand, "@bankAccountNumber", DbType.String, objPmntDetailsinfo.BankAccountNumber);
                dbDatabase.AddInParameter(dbCommand, "@AuthorizationDt", DbType.String, objPmntDetailsinfo.AuthorizationDt);
                dbDatabase.AddInParameter(dbCommand, "@Amount", DbType.String, objPmntDetailsinfo.Amount);
                dbDatabase.AddInParameter(dbCommand, "@pmntStatus", DbType.Int32, objPmntDetailsinfo.PmntStatus);
                dbDatabase.AddInParameter(dbCommand, "@PackageID", DbType.Int32, PackageID);
                dbDatabase.AddInParameter(dbCommand, "@UID", DbType.Int32, UID);
                dbDatabase.AddInParameter(dbCommand, "@CarID", DbType.Int32, CarID);


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



        public bool USP_UpdateInfoForFreePackage(int PostingID, int UserPackID, int UId)
        {
            string spNameString = string.Empty;
            bool bsucess = false;
            //Setting Connection
            //Global.INSTANCE_NAME = strCurrentConn;

            IDataReader ModelsInfoDataReader = null;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //Assign stored procedure name

            spNameString = "[USP_UpdateInfoForFreePackage]";
            DbCommand dbCommand = null;

            try
            {
                //Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@PostingID", DbType.Int32, PostingID);
                dbDatabase.AddInParameter(dbCommand, "@UserPackID", DbType.Int32, UserPackID);
                dbDatabase.AddInParameter(dbCommand, "@UId", DbType.Int32, UId);

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
        public DataSet USP_GetNext12years()
        {
            try
            {
                DataSet dsyears = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetNext12years";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dsyears = dbDatabase.ExecuteDataSet(dbCommand);
                return dsyears;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }


}


