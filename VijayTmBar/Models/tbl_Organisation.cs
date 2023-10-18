using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VijayTmBar.Models
{
    public class tbl_Organisation
    {
        public int id { get; set; }

        public string OrgName { get; set; }

        public string OrgCode { get; set; }

        public string ContactPerson { get; set; }

        public string ContactNo { get; set; }

        public string ContactEmail { get; set; }

        public string HostDomain { get; set; }

        public string MainLogo { get; set; }

        public string SMSGateway { get; set; }

        public string OTPGateway { get; set; }
        public int OTP { get; set; }

        public string Mob_Placeholder { get; set; }

        public string Msg_Placeholder { get; set; }

        public string sts { get; set; }

        public DateTime Edate { get; set; }

        public string PaymentGateway { get; set; }

    }
}