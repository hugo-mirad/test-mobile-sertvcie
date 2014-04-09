
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Web.Mail;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using CarsBL;


namespace CarsBL
{
    public class UtilityBL
    {
        /// <summary>
        /// Generic function to send mail
        /// </summary>
        /// <param name="smtpServer">SMTP Server Name/IP</param>
        /// <param name="from">From Email Address</param>
        /// <param name="to">To Email Address</param>
        /// <param name="subject">Subject</param>
        /// <param name="body">Body</param>
        /// <returns>bool</returns>
        public bool SendMail(string strSmtpServer, string strFrom, string strTo, string strSubject, string strBody)
        {
            MailMessage mailMsg = null;
            Boolean blnMailSent = false;

            try
            {
                mailMsg = new MailMessage();
                mailMsg.From = strFrom;
                mailMsg.To = strTo;
                mailMsg.Cc = strFrom;
                mailMsg.Subject = strSubject;
                mailMsg.BodyFormat = MailFormat.Html;
                mailMsg.Body = strBody;

                if (strSmtpServer.Trim().Length != 0)
                {
                    SmtpMail.SmtpServer = strSmtpServer;
                }
                SmtpMail.Send(mailMsg);
                blnMailSent = true;
            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, Global .EXCEPTION_POLICY);

                if (rethrow)
                    throw;
            }
            return blnMailSent;
        }
    }
}