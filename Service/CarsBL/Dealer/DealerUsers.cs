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


namespace CarsBL.Dealer
{
    public class DealerUsers
    {

        public DataSet GetDealerGetUsers(string DealerCode)
        {
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_DealerGetUsers";
                DbCommand dbCommand = null;

                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@DealerCode", System.Data.DbType.String, DealerCode);
                

                dsCars = dbDatabase.ExecuteDataSet(dbCommand);

                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataSet AddDealerUsers(string DealerCode, string UId, string Name, string UserID, string Pwd,string UserName,
            string PhoneNumber,int isActive )
        {
            try
            {
                DataSet dsCars = new DataSet();

                string spNameString = string.Empty;

                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

                spNameString = "USP_DealerAddUsers";

                DbCommand dbCommand = null;

                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@DealerCode", System.Data.DbType.String, DealerCode);
                dbDatabase.AddInParameter(dbCommand, "@UId", System.Data.DbType.String, UId);
                dbDatabase.AddInParameter(dbCommand, "@Name", System.Data.DbType.String, Name);
                dbDatabase.AddInParameter(dbCommand, "@UserName", System.Data.DbType.String, UserName);
                dbDatabase.AddInParameter(dbCommand, "@UserID", System.Data.DbType.String, UserID);
                dbDatabase.AddInParameter(dbCommand, "@Pwd", System.Data.DbType.String, Pwd);
                dbDatabase.AddInParameter(dbCommand, "@PhoneNumber", System.Data.DbType.String, PhoneNumber);
                dbDatabase.AddInParameter(dbCommand, "@isActive", System.Data.DbType.String, isActive);

                dsCars = dbDatabase.ExecuteDataSet(dbCommand);

                return dsCars;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //
    }

  

}
