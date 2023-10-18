using Dotplus.Database.StoreProcedure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace VijayTmBar.Models
{
    public class BussnessLayer
    {

        public static tbl_Organisation GetOrganisation
        {
            get
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@HostDomain", Utility.GetDomain)
                };
                Database db = Database.GetInstance();
                var Org = db.fn_DataTable("Stud_GetOrganization", parameters).AsEnumerable().Select(s => new tbl_Organisation
                {
                    OrgName = s.Field<string>("OrgName"),
                    OrgCode = s.Field<string>("OrgCode"),
                    ContactPerson = s.Field<string>("ContactPerson"),
                    ContactNo = s.Field<string>("ContactNo"),
                    ContactEmail = s.Field<string>("ContactEmail"),
                    HostDomain = s.Field<string>("HostDomain"),
                    MainLogo = s.Field<string>("MainLogo"),
                    SMSGateway = s.Field<string>("SMSGateway"),
                    OTPGateway = s.Field<string>("OTPGateway"),
                    Mob_Placeholder = s.Field<string>("Mob_Placeholder"),
                    Msg_Placeholder = s.Field<string>("Msg_Placeholder"),
                    PaymentGateway = s.Field<string>("PaymentGateway"),
                }).FirstOrDefault();
                return Org;
            }
        }
        public static tbl_Organisation GetSetting
        {
            get
            {
               
                tbl_Organisation organization = new tbl_Organisation
                {
                    SMSGateway = "https://loginsms.in/api/mt/SendSMS?apikey=9KfWFeH63k2hk2O5Ln165Q&senderid=ASAPSR&channel=Trans&DCS=1&flashsms=0&number=##MOBILENO##&text=##TEXTMESSAGE##",
                    OTPGateway = "https://loginsms.in/api/mt/SendSMS?apikey=9KfWFeH63k2hk2O5Ln165Q&senderid=ASAPSR&channel=Trans&DCS=1&flashsms=0&number=##MOBILENO##&text=##TEXTMESSAGE##",
                    HostDomain = "localhost",
                    Mob_Placeholder = "##MOBILENO##",
                    Msg_Placeholder= "##TEXTMESSAGE##"
                    // Initialize properties of tbl_Organisation here
                };

                return organization; // Return the value
            }

        }
        
    }
}