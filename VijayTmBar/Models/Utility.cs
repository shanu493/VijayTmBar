using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using Dotplus.Database.StoreProcedure;
using System.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;

namespace VijayTmBar.Models
{

    static class Utility
    {


        public static string Token
        {
            get
            {
                return Thread.CurrentPrincipal.Identity.Name;
            }
        }

        public static string Base64Encode(string PlanText)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(PlanText));
        }

        public static string Base64Decode(string Code)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(Code));
        }
        #region Get Random Number
        public static int GetRandomNumber(int Digit)
        {
            Random random = new Random();
            return random.Next(Digit.GetMinNum(), Digit.GetMaxNum());
        }
        private static int GetMinNum(this int digit)
        {
            return Convert.ToInt32(Math.Pow(10, digit - 1));
        }
        private static int GetMaxNum(this int digit)
        {
            return Convert.ToInt32(Math.Pow(10, digit) - 1);
        }
        #endregion
        //public static string GetDomain
        //{
        //    get
        //    {
        //        try
        //        {
        //            var re = HttpContext.Current.Request.Headers;
        //            var AppDomain = re.GetValues("AppDomain").First();
        //            //var AppDomain = re.GetValues("localhost").First();
        //            return Base64Decode(AppDomain);
        //            //return AppDomain;

        //        }
        //        catch (Exception exp)
        //        {
        //            //throw new Exception("Invalid App. Please Update Your App With Letest Version", new Exception("App Key in not founded in this app"));
        //            throw new Exception("Invalid App. Please Update Your App With Letest Version", exp);
        //        }
        //    }
        //}

        public static string GetDomain                                //GetHostDomain
        {
            get
            {
                string HostDom = HttpContext.Current.Request.Url.Host;
                //return "vijaystudycircle.com";
                return "vijaytmt.dotplus.app";
            }
        }
    }
}

