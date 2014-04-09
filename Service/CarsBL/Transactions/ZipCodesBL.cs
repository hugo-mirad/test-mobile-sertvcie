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

namespace CarsBL.Masters
{
    public class ZipCodesBL
    {
        public IList<ZipcodeDistancesInfo> GetZips(string zipcode)
        {
            //Decalaring MakesInfo division object collection
            IList<ZipcodeDistancesInfo> ZipCodeIList = new List<ZipcodeDistancesInfo>();

            string spNameString = string.Empty;


            //Setting Connection
            //Global.INSTANCE_NAME = strCurrentConn;

            IDataReader ZipCodeInfoDataReader = null;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //Assign stored procedure name

            spNameString = "[GetAllZipCocde]";
            DbCommand dbCommand = null;

            try
            {
                //Set stored procedure to the command object


                //if (System.Web.Caching.Cache["Zips"] == null)
                //{
                    dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                    dbDatabase.AddInParameter(dbCommand, "@zipcode", DbType.String, zipcode);
                    //Executing stored procedure
                    ZipCodeInfoDataReader = dbDatabase.ExecuteReader(dbCommand);

                    while (ZipCodeInfoDataReader.Read())
                    {
                        //Assign values to the MakesInfo object list
                        ZipcodeDistancesInfo ZipCodeInfo_Info = new ZipcodeDistancesInfo();
                        AssignMakesInfoList(ZipCodeInfoDataReader, ZipCodeInfo_Info);
                        ZipCodeIList.Add(ZipCodeInfo_Info);
                    }

                //}
                //else
                //{ 
                //objZips = (List<CarsInfo.ZipcodeDistancesInfo>)System.Web.Caching.Cache["Zips"] ;
                
                //}
                
            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, Global.EXCEPTION_POLICY);

                if (rethrow)
                    throw;
            }
            finally
            {
                ZipCodeInfoDataReader.Close();
            }

            return ZipCodeIList;
        }


        private void AssignMakesInfoList(IDataReader ZipCodeInfoDataReader, ZipcodeDistancesInfo objZipcodeDistancesInfo)
        {
            try
            {
                objZipcodeDistancesInfo.ZipCode = ZipCodeInfoDataReader["ZipCode"].ToString();
                
            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, Global.EXCEPTION_POLICY);

            }
        }

    }
}
