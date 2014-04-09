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
    public class BuyerTranBL
    {

        public bool SaveBuyerRequest(string BuyerEmail, string BuyerCity,
            string BuyerPhone, string BuyerFirstName, string BuyerLastName, string BuyerComments,
            string IpAddress, string Sellerphone, string Sellerprice, string Carid, string RequestType)
        {
            string spNameString = string.Empty;
            bool bsucess = false;
            //Setting Connection
            //Global.INSTANCE_NAME = strCurrentConn;

            IDataReader ModelsInfoDataReader = null;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);

            //Assign stored procedure name

            spNameString = "[USP_Save_BuyerRequest]";
            DbCommand dbCommand = null;

            try
            {
                //Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@BuyerEmail", DbType.String, BuyerEmail);
                dbDatabase.AddInParameter(dbCommand, "@BuyerCity", DbType.String, BuyerCity);
                dbDatabase.AddInParameter(dbCommand, "@BuyerPhone", DbType.String, BuyerPhone);
                dbDatabase.AddInParameter(dbCommand, "@BuyerFirstName", DbType.String, BuyerFirstName);
                dbDatabase.AddInParameter(dbCommand, "@BuyerLastName", DbType.String, BuyerLastName);
                dbDatabase.AddInParameter(dbCommand, "@BuyerComments", DbType.String, BuyerComments);
                dbDatabase.AddInParameter(dbCommand, "@IpAddress", DbType.String, IpAddress);
                dbDatabase.AddInParameter(dbCommand, "@Sellerphone", DbType.String, Sellerphone);
                dbDatabase.AddInParameter(dbCommand, "@Sellerprice", DbType.String, Sellerprice);
                dbDatabase.AddInParameter(dbCommand, "@Carid", DbType.String, Carid);
                dbDatabase.AddInParameter(dbCommand, "@RequestType", DbType.String, RequestType);


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



        public bool SaveBuyerRequestMobile(string BuyerEmail, string BuyerCity,
           string BuyerPhone, string BuyerFirstName, string BuyerLastName, string BuyerComments,
           string IpAddress, string Sellerphone, string Sellerprice, string Carid,
            string sYear, string Make, string Model, string price, string RequestType,string ToEmail)
        {
            string spNameString = string.Empty;
            bool bsucess = false;
            //Setting Connection
            //Global.INSTANCE_NAME = strCurrentConn;

            IDataReader ModelsInfoDataReader = null;


            //Connect to the database
            Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME );

            //Assign stored procedure name

            spNameString = "[USP_Save_BuyerRequest]";
            DbCommand dbCommand = null;

            try
            {
                //Set stored procedure to the command object
                dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                dbDatabase.AddInParameter(dbCommand, "@BuyerEmail", DbType.String, BuyerEmail);
                dbDatabase.AddInParameter(dbCommand, "@BuyerCity", DbType.String, BuyerCity);
                dbDatabase.AddInParameter(dbCommand, "@BuyerPhone", DbType.String, BuyerPhone);
                dbDatabase.AddInParameter(dbCommand, "@BuyerFirstName", DbType.String, BuyerFirstName);
                dbDatabase.AddInParameter(dbCommand, "@BuyerLastName", DbType.String, BuyerLastName);
                dbDatabase.AddInParameter(dbCommand, "@BuyerComments", DbType.String, BuyerComments);
                dbDatabase.AddInParameter(dbCommand, "@IpAddress", DbType.String, IpAddress);
                dbDatabase.AddInParameter(dbCommand, "@Sellerphone", DbType.String, Sellerphone);
                dbDatabase.AddInParameter(dbCommand, "@Sellerprice", DbType.String, Sellerprice);
                dbDatabase.AddInParameter(dbCommand, "@Carid", DbType.String, Carid);
                dbDatabase.AddInParameter(dbCommand, "@RequestType", DbType.String, RequestType);


                //Executing stored procedure
                dbDatabase.ExecuteNonQuery(dbCommand);


                string strMailFormat = string.Empty;                
                
                StringBuilder sbQuery;
                string line;
                 
                string SalesMailFile = System.Web.Hosting.HostingEnvironment.MapPath("~/MailTemplate/SellarRequest.txt");

                StreamReader objStreamReader;

                objStreamReader = File.OpenText(SalesMailFile);

                sbQuery = new StringBuilder();

                while ((line = objStreamReader.ReadLine()) != null)
                {
                    string strMail = string.Empty;

                    strMail = line + "<br />";

                    if (line.Contains("###SellarName###"))
                    {
                        if (strMail == "")
                        {
                            strMail = line.Replace("###SellarName###", BuyerFirstName);
                        }
                        else
                        {
                            strMail = strMail.Replace("###SellarName###", BuyerFirstName);
                        }
                    }

                    if (line.Contains("###Phone###"))
                    {
                        if (strMail == "")
                        {
                            strMail = line.Replace("###Phone###", BuyerPhone);
                        }
                        else
                        {
                            strMail = strMail.Replace("###Phone###", BuyerPhone);
                        }
                    }
                    if (line.Contains("###Email###"))
                    {
                        if (strMail == "")
                        {
                            strMail += line.Replace("###Email###", BuyerEmail );
                        }
                        else
                        {
                            strMail = strMail.Replace("###Email###", BuyerEmail);
                        }
                    }
                    if (line.Contains("###Year###"))
                    {
                        if (strMail == "")
                        {
                            strMail += line.Replace("###Year###", sYear );
                        }
                        else
                        {
                            strMail = strMail.Replace("###Year###", sYear);
                        }
                    }


                            
                    if (line.Contains("###Make###"))
                    {
                        if (strMail == "")
                        {
                            strMail += line.Replace("###Make###", Make);
                        }
                        else
                        {
                            strMail = strMail.Replace("###Make###", Make);
                        }
                    }
                    if (line.Contains("###Model###"))
                    {
                        if (strMail == "")
                        {
                            strMail += line.Replace("###Model###", Model);
                        }
                        else
                        {
                            strMail = strMail.Replace("###Model###", Model);
                        }
                    }
                    if (line.Contains("###price###"))
                    {
                        if (strMail == "")
                        {
                            strMail += line.Replace("###price###", price);
                        }
                        else
                        {
                            strMail = strMail.Replace("###price###", price);
                        }
                    }
                    if (line.Contains("###Comments###"))
                    {
                        if (strMail == "")
                        {
                            strMail = line.Replace("###Comments###", BuyerComments);
                        }
                        else
                        {
                            strMail = strMail.Replace("###Comments###", BuyerComments);
                        }
                    }
                    if (line.Contains("###firstName###"))
                    {
                        if (strMail == "")
                        {
                            strMail = line.Replace("###firstName###", BuyerFirstName);
                        }
                        else
                        {
                            strMail = strMail.Replace("###firstName###", BuyerFirstName);
                        }
                    }
                    if (line.Contains("###lastName###"))
                    {
                        if (strMail == "")
                        {
                            strMail = line.Replace("###lastName###", BuyerLastName );
                        }
                        else
                        {
                            strMail = strMail.Replace("###lastName###", BuyerLastName);
                        }
                    }

                    if (line.Contains("###City###"))
                    {
                        if (strMail == "")
                        {
                            strMail = line.Replace("###City###", BuyerCity);
                        }
                        else
                        {
                            strMail = strMail.Replace("###City###", BuyerCity);
                        }
                    }


                    strMailFormat = strMailFormat + strMail;
                }
                UtilityBL objUtility = new UtilityBL();
                if (BuyerEmail == "")
                {
                    BuyerEmail = "info@unitedcarexchange.com";
                }

                objUtility.SendMail("127.0.0.1", BuyerEmail, ToEmail, "Regarding Buyer request", strMailFormat);
 

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
