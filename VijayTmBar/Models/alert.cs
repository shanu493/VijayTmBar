using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace VijayTmBar.Models
{
    public class alert
    {
        public static void SMS(string MobileNo, string Message, SMSGateway gateway)
        {
            try
            {


                string URLAPI = string.Empty;
                //var Result = BussnessLayer.GetOrganisation;
                var Result = BussnessLayer.GetSetting;

                URLAPI = Result.OTPGateway;
                if (gateway == SMSGateway.Promotional)
                {
                    URLAPI = Result.SMSGateway;
                }
                if (!string.IsNullOrEmpty(URLAPI))
                {
                    URLAPI = URLAPI.Replace(Result.Mob_Placeholder, MobileNo).Replace(Result.Msg_Placeholder, Message);
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URLAPI);
                    request.MaximumAutomaticRedirections = 4;
                    request.Credentials = CredentialCache.DefaultCredentials;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                    string sResponse = readStream.ReadToEnd();
                    response.Close();
                    readStream.Close();
                }

            }
            catch (Exception exp)
            {
                throw new Exception(exp.ToString());
            }
        }
    }
    public enum SMSGateway
    {
        Promotional,
        Transaction
    }
}