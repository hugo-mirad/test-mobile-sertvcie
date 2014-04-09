/**********************************************************************
' MODULE       : Master
' FILENAME     : Master.cs
' AUTHOR       : Shravan
' CREATED      : 18-Jan-2012
' DESCRIPTION  : Business Logic to manipulate zipCodes.
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
    public class VisitSiteLog
    {
        public bool SaveSiteVisits(string IPAddress, string ReturningURL, string CurrentPage)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_SiteVisits";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                dbDatabase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress) ;
                dbDatabase.AddInParameter(dbCommand, "@ReturningURL", System.Data.DbType.String, ReturningURL);
                dbDatabase.AddInParameter(dbCommand, "@CurrentPage", System.Data.DbType.String, CurrentPage);
                               

                dbDatabase.ExecuteNonQuery(dbCommand);

                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool OfferPageVisits(string IPAddress, string ReturningURL, string CurrentPage)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_OfferPageVisits";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                dbDatabase.AddInParameter(dbCommand, "@IPAddress", System.Data.DbType.String, IPAddress) ;
                dbDatabase.AddInParameter(dbCommand, "@ReturningURL", System.Data.DbType.String, ReturningURL);
                dbDatabase.AddInParameter(dbCommand, "@CurrentPage", System.Data.DbType.String, CurrentPage);
                               

                dbDatabase.ExecuteNonQuery(dbCommand);

                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        public bool SaveSearchLog(string IPAddress, string MakeID, string ModelID, string within, string zip, string SearchName)
        {
            try
            {
                bool bnew = false;
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "[USP_SearchLog]";

                DbCommand dbCommand = null;

                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@SearchName", System.Data.DbType.String, SearchName);
                dbDatabase.AddInParameter(dbCommand, "@IpAddress", System.Data.DbType.String, IPAddress);
                dbDatabase.AddInParameter(dbCommand, "@MakeID ", System.Data.DbType.String, MakeID);
                dbDatabase.AddInParameter(dbCommand, "@ModelID ", System.Data.DbType.String, ModelID);
                dbDatabase.AddInParameter(dbCommand, "@within ", System.Data.DbType.String, within);
                dbDatabase.AddInParameter(dbCommand, "@zip", System.Data.DbType.String, zip);
                               

                dbDatabase.ExecuteNonQuery(dbCommand);

                bnew = true;
                return bnew;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

    }
}
