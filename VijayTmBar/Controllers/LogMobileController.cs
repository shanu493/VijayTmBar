using Dotplus.Database.StoreProcedure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using VijayTmBar.Models;

namespace VijayTmBar.Controllers
{
    public class LogMobileController : ApiController
    {
        Database db;
        string Db;
        public LogMobileController()
        {

            Db = ConfigurationManager.ConnectionStrings["DB_Connection"].ConnectionString;
            db = Database.GetInstance("DB_Connection");
        }
        [HttpPost]
        public HttpResponseMessage LogMobile([FromBody] tbl_Employee employee)
        {
          //  string OTP = Utility.GetRandomNumber(5).ToString();

           UesrSecurity Otp = new UesrSecurity();
            string OTP = Otp.GetOtp;
              



            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_Connection"].ConnectionString))

            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("API_spVerifyMobile", connection)) //API_spVerifyMobile_Test
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.AddWithValue("@EmpMobile", employee.MobileNo);
                    command.Parameters.AddWithValue("@OTP", OTP);
                    command.Parameters.AddWithValue("@DomainName", Utility.GetDomain);

                    SqlParameter[] parameter = new SqlParameter[]
                {
                    new SqlParameter("@EmpMobile", employee.MobileNo),
                   // new SqlParameter("@Password", Convert.ToBase64String(Encoding.UTF8.GetBytes(Password))),
                    new SqlParameter("@OTP", OTP),
                    new SqlParameter("@DomainName", Utility.GetDomain)
                };

                    Database db = Database.GetInstance();
                    var Result = db.fn_DataTable("API_spVerifyMobile", parameter).AsEnumerable().Select(s => new
                    {
                        Count = s.Field<int>("Count"),
                        OTP = s.Field<string>("OTP"),
                    }).FirstOrDefault();

                    if (Result.Count > 0)
                    {
                       // string Temp = "Dear Students Your Current Password for Vijay Study circle Online Class is - " + OTP + ". Visit www.vijaystudycircle.com";
                        string Temp = "" + OTP + " is your OTP for Login. Please do not share with other.";

                        alert.SMS(employee.MobileNo, Temp, SMSGateway.Transaction);
                        //return RedirectToAction("Index");

                        var result = new
                        {
                            isSuccess = true,
                            message = "OTP Sent to Your Mobile."
                        };
                        string json = JsonConvert.SerializeObject(result);

                        return new HttpResponseMessage(HttpStatusCode.OK)
                        {
                            Content = new StringContent(json, Encoding.Default, "application/json")
                        };

                        // return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {

                        ModelState.AddModelError(string.Empty, "Please Enter Mobile No");
                    }

                }

            }
            var results = new
            {
                isSuccess = false,
                message = "Invalid Mobile Number "
            };
            string jsons = JsonConvert.SerializeObject(results);
            return new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(jsons, Encoding.Default, "application/json")
            };

        }

      

    }
}
