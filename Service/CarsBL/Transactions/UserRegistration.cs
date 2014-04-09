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
namespace CarsBL.Transactions
{
    public class UserRegistration
    {
        public DataSet Usp_Save_RegisterUser(UserRegistrationInfo objUserregisInfo)
        {
            bool returnValue = false;
            string spNameString = string.Empty;
            DataSet dsUserInfo = new DataSet();
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
            spNameString = "Usp_Save_RegisterUser";
            DbCommand dbCommand = null;

            try
            {
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@Name", System.Data.DbType.String, objUserregisInfo.Name);
                dbDatabase.AddInParameter(dbCommand, "@UserName", System.Data.DbType.String, objUserregisInfo.UserName);
                dbDatabase.AddInParameter(dbCommand, "@Pwd", System.Data.DbType.String, objUserregisInfo.Pwd);
                dbDatabase.AddInParameter(dbCommand, "@PhoneNumber", System.Data.DbType.String, objUserregisInfo.PhoneNumber);
                dbDatabase.AddInParameter(dbCommand, "@isActive", System.Data.DbType.Int32, 1);
                dbDatabase.AddInParameter(dbCommand, "@CouponCode", System.Data.DbType.String, objUserregisInfo.CouponCode);
                dbDatabase.AddInParameter(dbCommand, "@ReferCode", System.Data.DbType.String, objUserregisInfo.ReferCode);
                dbDatabase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.Int32, objUserregisInfo.PackageID);
                dbDatabase.AddInParameter(dbCommand, "@StateID", System.Data.DbType.Int32, objUserregisInfo.StateID);
                dbDatabase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, objUserregisInfo.City);
                dbDatabase.AddInParameter(dbCommand, "@Address", System.Data.DbType.String, objUserregisInfo.Address);
                dbDatabase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, objUserregisInfo.Zip);
                dsUserInfo = dbDatabase.ExecuteDataSet(dbCommand);

                //blnSuccess = objUserLog.SaveUserLog(UserLogInfo, ref lngReturn, "");
                return dsUserInfo;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet PerformLogin(string UsersID, string sPassword)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_Perform_Login";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@UName", System.Data.DbType.String, UsersID);
                dbDatabase.AddInParameter(dbCommand, "@Password", System.Data.DbType.String, sPassword);

                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet USP_ChkUserExists(string UserName)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_ChkUserExists";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@UserName", System.Data.DbType.String, UserName);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet USP_GetPasswordByID(string UserName)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                spNameString = "USP_GetPasswordByID";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@UserName", System.Data.DbType.String, UserName);
                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet USP_UpdateRegUserDetails(UserRegistrationInfo objUserregisInfo)
        {
            bool returnValue = false;
            string spNameString = string.Empty;
            DataSet dsUserInfo = new DataSet();
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
            spNameString = "USP_UpdateRegUserDetails";
            DbCommand dbCommand = null;

            try
            {
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@UId", System.Data.DbType.Int32, objUserregisInfo.UId);
                dbDatabase.AddInParameter(dbCommand, "@Name", System.Data.DbType.String, objUserregisInfo.Name);
                dbDatabase.AddInParameter(dbCommand, "@PhoneNumber", System.Data.DbType.String, objUserregisInfo.PhoneNumber);
                dbDatabase.AddInParameter(dbCommand, "@StateID", System.Data.DbType.Int32, objUserregisInfo.StateID);
                dbDatabase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, objUserregisInfo.City);
                dbDatabase.AddInParameter(dbCommand, "@Address", System.Data.DbType.String, objUserregisInfo.Address);
                dbDatabase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, objUserregisInfo.Zip);
                dbDatabase.AddInParameter(dbCommand, "@BusinessName", System.Data.DbType.String, objUserregisInfo.BusinessName);
                dbDatabase.AddInParameter(dbCommand, "@AltEmail", System.Data.DbType.String, objUserregisInfo.AltEmail);
                dbDatabase.AddInParameter(dbCommand, "@AltPhone", System.Data.DbType.String, objUserregisInfo.AltPhone);


                dsUserInfo = dbDatabase.ExecuteDataSet(dbCommand);

                //blnSuccess = objUserLog.SaveUserLog(UserLogInfo, ref lngReturn, "");
                return dsUserInfo;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet Usp_Save_RegisterLogUser(UserRegistrationInfo objUserregisInfo, int EmailExists, string UserID)
        {
            bool returnValue = false;
            string spNameString = string.Empty;
            DataSet dsUserInfo = new DataSet();
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
            spNameString = "Usp_Save_RegisterLogUser";
            DbCommand dbCommand = null;

            try
            {
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@Name", System.Data.DbType.String, objUserregisInfo.Name);
                dbDatabase.AddInParameter(dbCommand, "@UserName", System.Data.DbType.String, objUserregisInfo.UserName);
                dbDatabase.AddInParameter(dbCommand, "@Pwd", System.Data.DbType.String, objUserregisInfo.Pwd);
                dbDatabase.AddInParameter(dbCommand, "@PhoneNumber", System.Data.DbType.String, objUserregisInfo.PhoneNumber);
                dbDatabase.AddInParameter(dbCommand, "@isActive", System.Data.DbType.Int32, 1);
                dbDatabase.AddInParameter(dbCommand, "@CouponCode", System.Data.DbType.String, objUserregisInfo.CouponCode);
                dbDatabase.AddInParameter(dbCommand, "@ReferCode", System.Data.DbType.String, objUserregisInfo.ReferCode);
                dbDatabase.AddInParameter(dbCommand, "@PackageID", System.Data.DbType.Int32, objUserregisInfo.PackageID);
                dbDatabase.AddInParameter(dbCommand, "@StateID", System.Data.DbType.Int32, objUserregisInfo.StateID);
                dbDatabase.AddInParameter(dbCommand, "@City", System.Data.DbType.String, objUserregisInfo.City);
                dbDatabase.AddInParameter(dbCommand, "@Address", System.Data.DbType.String, objUserregisInfo.Address);
                dbDatabase.AddInParameter(dbCommand, "@Zip", System.Data.DbType.String, objUserregisInfo.Zip);

                dbDatabase.AddInParameter(dbCommand, "@BusinessName", System.Data.DbType.String, objUserregisInfo.BusinessName);
                dbDatabase.AddInParameter(dbCommand, "@AltEmail", System.Data.DbType.String, objUserregisInfo.AltEmail);
                dbDatabase.AddInParameter(dbCommand, "@AltPhone", System.Data.DbType.String, objUserregisInfo.AltPhone);
                dbDatabase.AddInParameter(dbCommand, "@EmailExists", System.Data.DbType.Int32, EmailExists);
                dbDatabase.AddInParameter(dbCommand, "@UserID", System.Data.DbType.String, UserID);
                
                dsUserInfo = dbDatabase.ExecuteDataSet(dbCommand);

                //blnSuccess = objUserLog.SaveUserLog(UserLogInfo, ref lngReturn, "");
                return dsUserInfo;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool SaveUserLog(UserLogInfo ObjUserLog, ref Int64 lngReturn, string logid)
        {
            bool returnValue = false;
            bool bNew = false;
            string spNameString = string.Empty;

            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            spNameString = "[USP_Save_UserLogForUCE]";

            DbCommand dbCommand = null;
            try
            {

                if (logid == "")
                {
                    bNew = false;
                    ObjUserLog.Log_Id = 0;
                }
                else
                {
                    ObjUserLog.Log_Id = Int64.Parse(logid);
                    bNew = true;
                }

                //Assign stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                //Assign stored procedure parameters
                dbDatabase.AddInParameter(dbCommand, "@Log_Id", DbType.Int64, ObjUserLog.Log_Id);
                dbDatabase.AddInParameter(dbCommand, "@User_Id", DbType.Int64, ObjUserLog.User_Id);
                dbDatabase.AddInParameter(dbCommand, "@Login_Ip", DbType.String, ObjUserLog.Login_Ip);
                dbDatabase.AddInParameter(dbCommand, "@Log_Status_Id", DbType.Int32, ObjUserLog.Log_Status_Id);
                dbDatabase.AddInParameter(dbCommand, "@Login_DateTime", DbType.DateTime, ObjUserLog.Login_DateTime);
                dbDatabase.AddInParameter(dbCommand, "@Logout_time", DbType.DateTime, ObjUserLog.Logout_time);
                dbDatabase.AddInParameter(dbCommand, "@Session_Id", DbType.String, ObjUserLog.Session_Id);
                dbDatabase.AddInParameter(dbCommand, "@CookieID", DbType.String, ObjUserLog.CookieID);
                dbDatabase.AddInParameter(dbCommand, "@bNew", DbType.Boolean, bNew);

                dbDatabase.AddOutParameter(dbCommand, "@ID", DbType.Int64, 1);

                dbDatabase.ExecuteNonQuery(dbCommand);


                lngReturn = Int64.Parse(dbDatabase.GetParameterValue(dbCommand, "@Id").ToString());



                returnValue = true;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbDatabase = null;
            }
            return returnValue;
        }




    }
}
