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
using CarsBL;
#endregion Microsoft Application Block References

namespace CarsBL.Dealer
{
    public class FileBL
    {
        public DataSet SaveFileDetails(File_Info objFiles_Info, ref Int64 lngReturn, string sVehicleTypeiD)
        {
            bool returnValue = false;

            DataSet ds = new DataSet();

            string spNameString = string.Empty;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            spNameString = "[USP_SaveFileDetails]";

            DbCommand dbCommand = null;
            try
            {

                //Assign stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                //Assign stored procedure parameters

                dbDatabase.AddInParameter(dbCommand, "@Leaddate", DbType.String, objFiles_Info.date);
                dbDatabase.AddInParameter(dbCommand, "@LeadFile", DbType.String, objFiles_Info.File);
                dbDatabase.AddInParameter(dbCommand, "@LeadCount", DbType.String, objFiles_Info.RecordCount);
                dbDatabase.AddInParameter(dbCommand, "@LeadUploadedBy", DbType.String, objFiles_Info.UploadedBy);




                //Executing stored procedure
                ds = dbDatabase.ExecuteDataSet(dbCommand);

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            lngReturn = Convert.ToInt64(ds.Tables[0].Rows[0][0].ToString());
                        }
                    }
                }
                returnValue = true;
            }

            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, Global.EXCEPTION_POLICY);

                if (rethrow)
                    throw;
            }
            finally
            {
                dbDatabase = null;
            }
            return ds;

        }
        public IDataReader Get_FileByFileName(string FileName)
        {
            //Decalaring Users object collection

            IDataReader IAcDetDatarReader = null;

            string spNameString = string.Empty;

            //Setting Connection


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //Assign stored procedure name
            spNameString = "[USP_Get_FileByFileName]";

            DbCommand dbCommand = null;

            try
            {
                //Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@FileName", DbType.String, FileName);

                //Executing stored procedure
                IAcDetDatarReader = dbDatabase.ExecuteReader(dbCommand);

            }

            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, Global.EXCEPTION_POLICY);

                if (rethrow)
                    throw;
            }
            finally
            {
                dbDatabase = null;
            }
            return IAcDetDatarReader;
        }
    }
}
