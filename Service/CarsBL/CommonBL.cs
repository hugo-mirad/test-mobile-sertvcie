/**********************************************************************
' MODULE       : Common Methods
' FILENAME     : CommonBL.cs
' AUTHOR       : Shravan 
' CREATED      : 02-jan-2012
' COPYRIGHT    : 
' DESCRIPTION  : Common class to handle generic function for the application
'*********************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Data;
using System.Data.Common;
using System.IO;

namespace CarsBL
{
    public class CommonBL
    {
        /// <summary>
        /// This method is used to encrypt the user password, uses System.Security.Cryptography;
        /// </summary>
        /// <param name="Data">Data</param>
        /// <returns></returns>
        public static string GetEncryptedData(string Data)
        {
            byte[] bytesToHash = new UnicodeEncoding().GetBytes(Data);
            byte[] hashedBytes = new SHA256Managed().ComputeHash(bytesToHash);
            string hashedText = BitConverter.ToString(hashedBytes);
            return hashedText;
        }

        /// <summary> 
        /// Encrypt Passwords using Cryptostream 
        /// </summary> 
        /// <param name="Password">Password Paramater</param> 
        /// <returns> bytes[] </returns> 
        public static byte[] EncryptIt(string Password)
        {
            byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(Password);

            byte[] rgbKey = System.Text.ASCIIEncoding.ASCII.GetBytes("56565656");
            byte[] rgbIV = System.Text.ASCIIEncoding.ASCII.GetBytes("78787878");
            //byte[] rgbKey = System.Text.ASCIIEncoding.ASCII.GetBytes("91951822");
            //byte[] rgbIV = System.Text.ASCIIEncoding.ASCII.GetBytes("231518124");

            //1024-bit encryption 
            MemoryStream memoryStream = new MemoryStream(1024);
            DESCryptoServiceProvider desCryptoServiceProvider = new DESCryptoServiceProvider();

            CryptoStream cryptoStream = new CryptoStream(memoryStream, desCryptoServiceProvider.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);

            cryptoStream.Write(data, 0, data.Length);
            cryptoStream.FlushFinalBlock();

            byte[] result = null;

            result = new byte[(int)memoryStream.Position];
            memoryStream.Position = 0;
            memoryStream.Read(result, 0, result.Length);

            cryptoStream.Close();

            return result;
        }

        /// <summary>
        /// Decrypt Passwords using Cryptostream
        /// </summary>
        /// <param name="toDecrypt"> encrpted password </param>
        /// <returns> decrypted password </returns>
        public static string DecryptIt(string toDecrypt)
        {
            byte[] data = System.Convert.FromBase64String(toDecrypt);
            byte[] rgbKey = System.Text.ASCIIEncoding.ASCII.GetBytes("56565656");
            byte[] rgbIV = System.Text.ASCIIEncoding.ASCII.GetBytes("78787878");

            MemoryStream memoryStream = new MemoryStream(data.Length);

            DESCryptoServiceProvider desCryptoServiceProvider =
            new DESCryptoServiceProvider();

            CryptoStream cryptoStream = new CryptoStream(memoryStream,
            desCryptoServiceProvider.CreateDecryptor(rgbKey, rgbIV),
            CryptoStreamMode.Read);

            memoryStream.Write(data, 0, data.Length);
            memoryStream.Position = 0;

            string decrypted = new StreamReader(cryptoStream).ReadToEnd();

            cryptoStream.Close();

            return decrypted;
        }

    }
}
