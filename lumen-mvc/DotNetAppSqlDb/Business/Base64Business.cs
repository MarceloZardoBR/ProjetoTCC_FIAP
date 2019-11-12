using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.Business
{
    public class Base64Business
    {
        public static string Base64Encode(string plainText)
        {
            if (!String.IsNullOrEmpty(plainText))
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
                return Convert.ToBase64String(plainTextBytes);
            }
            else return "";
        }

        public static string Base64Decode(string base64EncodedData)
        {
            if (!String.IsNullOrEmpty(base64EncodedData)) {
                var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
                return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            }
            else return ""; 
           
        }
    }
}