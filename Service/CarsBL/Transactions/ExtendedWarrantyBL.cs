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
using System.Web;
using System.IO;
#endregion Microsoft Application Block References


namespace CarsBL.Transactions
{
    public class ExtendedWarrantyBL
    {

        public bool SaveExtendedWarranty(ExtendedWarrantyInfo objExtendedWarrantyInfo)
        {
            string spNameString = string.Empty;
            bool bsucess = false;
            //Setting Connection
            //Global.INSTANCE_NAME = strCurrentConn;

            IDataReader ModelsInfoDataReader = null;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.CENTRAL_INSTANCE_NAME);

            //Assign stored procedure name

            spNameString = "[USP_SaveCarwarranty]";
            DbCommand dbCommand = null;

            try
            {
                //Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                dbDatabase.AddInParameter(dbCommand, "@Firstname", DbType.String, objExtendedWarrantyInfo.Firstname);
                dbDatabase.AddInParameter(dbCommand, "@LastName", DbType.String, objExtendedWarrantyInfo.LastName);
                dbDatabase.AddInParameter(dbCommand, "@Email", DbType.String, objExtendedWarrantyInfo.Email);
                dbDatabase.AddInParameter(dbCommand, "@Phone", DbType.String, objExtendedWarrantyInfo.Phone);
                dbDatabase.AddInParameter(dbCommand, "@CellNo", DbType.String, objExtendedWarrantyInfo.CellNo);
                dbDatabase.AddInParameter(dbCommand, "@Address", DbType.String, objExtendedWarrantyInfo.Address);
                dbDatabase.AddInParameter(dbCommand, "@city", DbType.String, objExtendedWarrantyInfo.City);
                dbDatabase.AddInParameter(dbCommand, "@state", DbType.String, objExtendedWarrantyInfo.State);
                dbDatabase.AddInParameter(dbCommand, "@BestTimetoContact", DbType.String, objExtendedWarrantyInfo.BestTimetoContact);
                dbDatabase.AddInParameter(dbCommand, "@MakeID", DbType.String, objExtendedWarrantyInfo.MakeID);
                dbDatabase.AddInParameter(dbCommand, "@ModelID", DbType.String, objExtendedWarrantyInfo.ModelID);
                dbDatabase.AddInParameter(dbCommand, "@Year", DbType.String, objExtendedWarrantyInfo.Year);
                dbDatabase.AddInParameter(dbCommand, "@Mileage", DbType.String, objExtendedWarrantyInfo.Mileage);
                
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

    }
}
