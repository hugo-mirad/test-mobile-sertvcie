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

#endregion Application References

#region Microsoft Application Block References
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using CarsInfo;
#endregion Microsoft Application Block References

namespace CarsBL.Masters
{
    public class ModelBL
    {
        public IList<ModelsInfo> GetModels(string MakeID)
        {
            //Decalaring ModelsInfo division object collection
            IList<ModelsInfo> ModelsInfoIList = new List<ModelsInfo>();

            string spNameString = string.Empty;


            //Setting Connection
            //Global.INSTANCE_NAME = strCurrentConn;

            IDataReader ModelsInfoDataReader = null;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //Assign stored procedure name

            spNameString = "[USP_GetAllModels]";
            DbCommand dbCommand = null;

            try
            {
                //Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@makeID", DbType.Int64, 0);

                //Executing stored procedure
                ModelsInfoDataReader = dbDatabase.ExecuteReader(dbCommand);

                while (ModelsInfoDataReader.Read())
                {
                    //Assign values to the ModelsInfo object list
                    ModelsInfo ObjModelsInfo_Info = new ModelsInfo();
                    AssignModelsInfoList(ModelsInfoDataReader, ObjModelsInfo_Info);
                    ModelsInfoIList.Add(ObjModelsInfo_Info);
                }
            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, Global.EXCEPTION_POLICY);

                if (rethrow)
                    throw;
            }
            finally
            {
                ModelsInfoDataReader.Close();
            }

            return ModelsInfoIList;
        }


        public IList<ModelsInfo> GetModelsByMake(string MakeID)
        {
            //Decalaring ModelsInfo division object collection
            IList<ModelsInfo> ModelsInfoIList = new List<ModelsInfo>();

            string spNameString = string.Empty;


            //Setting Connection
            //Global.INSTANCE_NAME = strCurrentConn;

            IDataReader ModelsInfoDataReader = null;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //Assign stored procedure name

            spNameString = "[USP_GetAllModels]";
            DbCommand dbCommand = null;

            try
            {
                //Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@makeID", DbType.Int64, MakeID);

                //Executing stored procedure
                ModelsInfoDataReader = dbDatabase.ExecuteReader(dbCommand);

                while (ModelsInfoDataReader.Read())
                {
                    //Assign values to the ModelsInfo object list
                    ModelsInfo ObjModelsInfo_Info = new ModelsInfo();
                    AssignModelsInfoList(ModelsInfoDataReader, ObjModelsInfo_Info);
                    ModelsInfoIList.Add(ObjModelsInfo_Info);
                }
            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, Global.EXCEPTION_POLICY);

                if (rethrow)
                    throw;
            }
            finally
            {
                ModelsInfoDataReader.Close();
            }

            return ModelsInfoIList;
        }
        private void AssignModelsInfoList(IDataReader ModelsInfoDataReader, ModelsInfo objModelsInfo)
        {
            try
            {

                objModelsInfo.MakeModelID = int.Parse(ModelsInfoDataReader["MakeModelID"].ToString());
                objModelsInfo.MakeID = int.Parse(ModelsInfoDataReader["MakeID"].ToString());
                objModelsInfo.Model = Convert.ToString(ModelsInfoDataReader["Model"]);
            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, Global.EXCEPTION_POLICY);

            }
        }

    }
}
