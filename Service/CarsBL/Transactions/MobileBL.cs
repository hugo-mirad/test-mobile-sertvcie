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
    public class MobileBL
    {
        public IList<UserLoginInfo> PerformLoginMobile(string UsersID, string sPassword)
        {

            IList<UserLoginInfo> UsersInfoIList = new List<UserLoginInfo>();
            try
            {
                string spNameString = string.Empty;

                //Setting Connection
                //Global.INSTANCE_NAME = strCurrentConn;

                IDataReader CarInfoDataReader = null;

                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.CarsConnTest);
                spNameString = "USP_Perform_Login";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@UName", System.Data.DbType.String, UsersID);
                dbDatabase.AddInParameter(dbCommand, "@Password", System.Data.DbType.String, sPassword);

                CarInfoDataReader = dbDatabase.ExecuteReader(dbCommand);

                while (CarInfoDataReader.Read())
                {
                    //Assign values to the MakesInfo object list
                    UserLoginInfo ObjUserInfo_Info = new UserLoginInfo();
                    AssignUserLoginInfo(CarInfoDataReader, ObjUserInfo_Info);
                    UsersInfoIList.Add(ObjUserInfo_Info);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            return UsersInfoIList;
        }

        private void AssignUserLoginInfo(IDataReader CarInfoDataReader, UserLoginInfo ObjUserInfo_Info)
        {
            try
            {
                ObjUserInfo_Info.AASuccess = "User Existed";
                ObjUserInfo_Info.IsActive = CarInfoDataReader["isActive"].ToString() == "" ? "Emp" : CarInfoDataReader["isActive"].ToString();
                ObjUserInfo_Info.Name = CarInfoDataReader["Name"].ToString() == "" ? "Emp" : CarInfoDataReader["Name"].ToString();
                ObjUserInfo_Info.UserID = CarInfoDataReader["UserID"].ToString() == "" ? "Emp" : CarInfoDataReader["UserID"].ToString();
                ObjUserInfo_Info.UID = CarInfoDataReader["UId"].ToString() == "" ? "Emp" : CarInfoDataReader["UId"].ToString();
                ObjUserInfo_Info.PhoneNumber = CarInfoDataReader["PhoneNumber"].ToString() == "" ? "Emp" : CarInfoDataReader["PhoneNumber"].ToString();
                ObjUserInfo_Info.PackageID = CarInfoDataReader["PackageID"].ToString() == "" ? "Emp" : CarInfoDataReader["PackageID"].ToString();

            }
            catch (Exception ex)
            {
            }
        }
        public IList<MobileUserRegData> GetUSerDetailsByUserID(int UID)
        {
            IList<MobileUserRegData> obj = new List<MobileUserRegData>();
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.CarsConnTest);
                spNameString = "USP_GetUSerDetailsByUserID";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                MobileUserRegData objRegInfo = new MobileUserRegData();
                if (dsCars.Tables.Count > 0)
                {
                    if (dsCars.Tables[0].Rows.Count > 0)
                    {
                        objRegInfo.UId = dsCars.Tables[0].Rows[0]["UId"].ToString() == "" ? 0 : Convert.ToInt32(dsCars.Tables[0].Rows[0]["UId"].ToString());
                        objRegInfo.UserID = dsCars.Tables[0].Rows[0]["UserID"].ToString() == "" ? "Emp" : dsCars.Tables[0].Rows[0]["UserID"].ToString();
                        objRegInfo.Name = dsCars.Tables[0].Rows[0]["Name"].ToString() == "" ? "Emp" : dsCars.Tables[0].Rows[0]["Name"].ToString();
                        objRegInfo.BusinessName = dsCars.Tables[0].Rows[0]["BusinessName"].ToString() == "" ? "Emp" : dsCars.Tables[0].Rows[0]["BusinessName"].ToString();
                        objRegInfo.UserName = dsCars.Tables[0].Rows[0]["UserName"].ToString() == "" ? "Emp" : dsCars.Tables[0].Rows[0]["UserName"].ToString();
                        objRegInfo.AltEmail = dsCars.Tables[0].Rows[0]["AltEmail"].ToString() == "" ? "Emp" : dsCars.Tables[0].Rows[0]["AltEmail"].ToString();
                        objRegInfo.PhoneNumber = dsCars.Tables[0].Rows[0]["PhoneNumber"].ToString() == "" ? "Emp" : dsCars.Tables[0].Rows[0]["PhoneNumber"].ToString();
                        objRegInfo.AltPhone = dsCars.Tables[0].Rows[0]["AltPhone"].ToString() == "" ? "Emp" : dsCars.Tables[0].Rows[0]["AltPhone"].ToString();
                        objRegInfo.Address = dsCars.Tables[0].Rows[0]["Address"].ToString() == "" ? "Emp" : dsCars.Tables[0].Rows[0]["Address"].ToString();
                        objRegInfo.City = dsCars.Tables[0].Rows[0]["City"].ToString() == "" ? "Emp" : dsCars.Tables[0].Rows[0]["City"].ToString();
                        objRegInfo.StateCode = dsCars.Tables[0].Rows[0]["State_Code"].ToString() == "" ? "Emp" : dsCars.Tables[0].Rows[0]["State_Code"].ToString();
                        objRegInfo.StateID = dsCars.Tables[0].Rows[0]["StateID"].ToString() == "" ? 0 : Convert.ToInt32(dsCars.Tables[0].Rows[0]["StateID"].ToString());
                        objRegInfo.Zip = dsCars.Tables[0].Rows[0]["Zip"].ToString() == "" ? "Emp" : dsCars.Tables[0].Rows[0]["Zip"].ToString();
                        string StrCarIDs = string.Empty;
                        if (dsCars.Tables[1].Rows.Count > 0)
                        {
                            for (int i = 0; i < dsCars.Tables[1].Rows.Count; i++)
                            {
                                if (StrCarIDs == "")
                                {
                                    StrCarIDs = dsCars.Tables[1].Rows[i]["carid"].ToString();
                                }
                                else
                                {
                                    StrCarIDs = StrCarIDs + "," + dsCars.Tables[1].Rows[i]["carid"].ToString();
                                }
                            }
                        }
                        objRegInfo.CarIDs = StrCarIDs == "" ? "Emp" : StrCarIDs;
                        obj.Add(objRegInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }
        public IList<MobileUserRegData> GetUserData(int UID)
        {
            IList<MobileUserRegData> obj = new List<MobileUserRegData>();
            try
            {
                DataSet dsCars = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.CarsConnTest);
                spNameString = "USP_GetUSerDetailsByUserID";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);
                dbDatabase.AddInParameter(dbCommand, "@UID", System.Data.DbType.Int32, UID);
                dsCars = dbDatabase.ExecuteDataSet(dbCommand);
                MobileUserRegData objRegInfo = new MobileUserRegData();
                if (dsCars.Tables.Count > 0)
                {
                    if (dsCars.Tables[0].Rows.Count > 0)
                    {
                        objRegInfo.Name = dsCars.Tables[0].Rows[0]["Name"].ToString() == "" ? "Emp" : dsCars.Tables[0].Rows[0]["Name"].ToString();
                        objRegInfo.BusinessName = dsCars.Tables[0].Rows[0]["BusinessName"].ToString() == "" ? "Emp" : dsCars.Tables[0].Rows[0]["BusinessName"].ToString();
                        objRegInfo.UserName = dsCars.Tables[0].Rows[0]["UserName"].ToString() == "" ? "Emp" : dsCars.Tables[0].Rows[0]["UserName"].ToString();
                        objRegInfo.AltEmail = dsCars.Tables[0].Rows[0]["AltEmail"].ToString() == "" ? "Emp" : dsCars.Tables[0].Rows[0]["AltEmail"].ToString();
                        objRegInfo.PhoneNumber = dsCars.Tables[0].Rows[0]["PhoneNumber"].ToString() == "" ? "Emp" : dsCars.Tables[0].Rows[0]["PhoneNumber"].ToString();
                        objRegInfo.AltPhone = dsCars.Tables[0].Rows[0]["AltPhone"].ToString() == "" ? "Emp" : dsCars.Tables[0].Rows[0]["AltPhone"].ToString();
                        objRegInfo.Address = dsCars.Tables[0].Rows[0]["Address"].ToString() == "" ? "Emp" : dsCars.Tables[0].Rows[0]["Address"].ToString();
                        objRegInfo.City = dsCars.Tables[0].Rows[0]["City"].ToString() == "" ? "Emp" : dsCars.Tables[0].Rows[0]["City"].ToString();
                        objRegInfo.StateCode = dsCars.Tables[0].Rows[0]["State_Code"].ToString() == "" ? "Emp" : dsCars.Tables[0].Rows[0]["State_Code"].ToString();
                        objRegInfo.StateID = dsCars.Tables[0].Rows[0]["StateID"].ToString() == "" ? 0 : Convert.ToInt32(dsCars.Tables[0].Rows[0]["StateID"].ToString());
                        objRegInfo.Zip = dsCars.Tables[0].Rows[0]["Zip"].ToString() == "" ? "Emp" : dsCars.Tables[0].Rows[0]["Zip"].ToString();
                        string StrCarIDs = string.Empty;
                        if (dsCars.Tables[1].Rows.Count > 0)
                        {
                            for (int i = 0; i < dsCars.Tables[1].Rows.Count; i++)
                            {
                                if (StrCarIDs == "")
                                {
                                    StrCarIDs = dsCars.Tables[1].Rows[i]["carid"].ToString();
                                }
                                else
                                {
                                    StrCarIDs = StrCarIDs + "," + dsCars.Tables[1].Rows[i]["carid"].ToString();
                                }
                            }
                        }
                        objRegInfo.CarIDs = StrCarIDs == "" ? "Emp" : StrCarIDs;
                        obj.Add(objRegInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }

        public DataSet GetCenterData(string AgentCenterCode)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.CARSALES_INSTANCE_NAME);
                spNameString = "USP_GetCenterData";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);


                dbDatabase.AddInParameter(dbCommand, "@AgentCenterCode", System.Data.DbType.String, AgentCenterCode);

                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet HotLeadsPerformLogin(string UserName, string sPassword, string AgentCenterCode)
        {
            try
            {
                DataSet dsUsers = new DataSet();
                string spNameString = string.Empty;
                Database dbDatabase = DatabaseFactory.CreateDatabase(Global.CARSALES_INSTANCE_NAME);
                spNameString = "USP_HotLeadsPerformLoginForMobile";
                DbCommand dbCommand = null;
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@AgentLogUname", System.Data.DbType.String, UserName);
                dbDatabase.AddInParameter(dbCommand, "@AgentLogPassword", System.Data.DbType.String, sPassword);
                dbDatabase.AddInParameter(dbCommand, "@AgentCenterCode", System.Data.DbType.String, AgentCenterCode);


                dsUsers = dbDatabase.ExecuteDataSet(dbCommand);
                return dsUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetDatetime()
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.CARSALES_INSTANCE_NAME);
                spNameString = "USP_GetDatetime";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);

                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetAllSalesByCenterForTicker(int AgentCenterID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.CARSALES_INSTANCE_NAME);
                spNameString = "USP_GetAllSalesByCenterForTicker";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetAllCenterSalesByCenterForTicker(int AgentCenterID)
        {
            try
            {
                DataSet dsCarsData = new DataSet();
                string spNameString = string.Empty;
                Database dbDataBase = DatabaseFactory.CreateDatabase(Global.CARSALES_INSTANCE_NAME);
                spNameString = "USP_GetAllCenterSalesByCenterForTicker";
                DbCommand dbCommand = null;
                dbCommand = dbDataBase.GetStoredProcCommand(spNameString);
                dbDataBase.AddInParameter(dbCommand, "@AgentCenterID", System.Data.DbType.Int32, AgentCenterID);
                dsCarsData = dbDataBase.ExecuteDataSet(dbCommand);
                return dsCarsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
