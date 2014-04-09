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
using CarsInfo;
#region Application References

#endregion Application References

#region Microsoft Application Block References
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;

#endregion Microsoft Application Block References

namespace CarsBL.Transactions
{
    public class NewCarsBl
    {
        public DataSet USP_SaveNewCarRequest(NewCarsInfo objNewcarsInfo)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SaveNewCarRequest";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@NewCarRequestName", System.Data.DbType.String, objNewcarsInfo.NewCarRequestName);
                dbDatabase.AddInParameter(dbCommand, "@NewCarReqPhoneNumber", System.Data.DbType.String, objNewcarsInfo.NewCarReqPhoneNumber);
                dbDatabase.AddInParameter(dbCommand, "@NewCarReqEmail", System.Data.DbType.String, objNewcarsInfo.NewCarReqEmail);                
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet USP_SaveDealerRequest(DealersInfo objDealersInfo)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SaveDealerRequest";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@DealerName", System.Data.DbType.String, objDealersInfo.DealerName);
                dbDatabase.AddInParameter(dbCommand, "@DealerPhone", System.Data.DbType.String, objDealersInfo.DealerPhone);
                dbDatabase.AddInParameter(dbCommand, "@DealerEmail", System.Data.DbType.String, objDealersInfo.DealerEmail);
                dbDatabase.AddInParameter(dbCommand, "@DealerAddress", System.Data.DbType.String, objDealersInfo.DealerAddress);
                dbDatabase.AddInParameter(dbCommand, "@DealerCity", System.Data.DbType.String, objDealersInfo.DealerCity);
                dbDatabase.AddInParameter(dbCommand, "@DealerShipName", System.Data.DbType.String, objDealersInfo.DealerShipName);
                dbDatabase.AddInParameter(dbCommand, "@DealerNotes", System.Data.DbType.String, objDealersInfo.DealerNotes);
                dbDatabase.AddInParameter(dbCommand, "@DealerZip", System.Data.DbType.String, objDealersInfo.DealerZip); 
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    
}
