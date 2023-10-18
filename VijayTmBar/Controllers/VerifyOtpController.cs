using Dotplus.Database.StoreProcedure;
using Microsoft.Ajax.Utilities;
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
using System.Web.Http.Results;
using System.Web.UI.WebControls;
using VijayTmBar.Models;

namespace VijayTmBar.Controllers
{


    public class VerifyOtpController : ApiController
    {


        Database db;
        string Db;
        public VerifyOtpController()
        {

            Db = ConfigurationManager.ConnectionStrings["DB_Connection"].ConnectionString;
            db = Database.GetInstance("DB_Connection");
        }

        [HttpPost]
        public HttpResponseMessage VerifyOtp([FromBody] tbl_Employee employee)
        {

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_Connection"].ConnectionString))

            {
                connection.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand("API_spVerifyOtps", connection)) //API_spVerifyOtps_Test
                    {
                      command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                      command.Parameters.AddWithValue("@Mobile", employee.MobileNo);
                      command.Parameters.AddWithValue("@OTP", employee.OTP);
                    
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            if (dataTable.Rows.Count > 0)
                            {
                                DataRow row = dataTable.Rows[0];

                                var result = new
                                {
                                    isSuccess = true,
                                    Token = row["Token"].ToString()
                                };
                                string json = JsonConvert.SerializeObject(result);

                                return new HttpResponseMessage(HttpStatusCode.OK)
                                {
                                    Content = new StringContent(json, Encoding.Default, "application/json")
                                };

                            }
                            else
                            {
                                var result = new
                                {
                                    isSuccess = false,
                                    message = "Invalid OTP"
                                };
                                string json = JsonConvert.SerializeObject(result);

                                return new HttpResponseMessage(HttpStatusCode.OK)
                                {
                                    Content = new StringContent(json, Encoding.Default, "application/json")
                                };
                            }
                        }

                    }
                   
                   
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.ToString());
                }
            }
            //return Request.CreateErrorResponse(HttpStatusCode.OK);
        }

    }
}
