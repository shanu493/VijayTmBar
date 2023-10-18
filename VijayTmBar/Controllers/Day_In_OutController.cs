using Dotplus.Database.StoreProcedure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using VijayTmBar.Models;
using static System.Net.WebRequestMethods;

namespace VijayTmBar.Controllers
{

    [BasicAuthentication]
    public class Day_In_OutController : ApiController
    {

        Database db;
        string Db;
        public Day_In_OutController()
        {

            Db = ConfigurationManager.ConnectionStrings["DB_Connection"].ConnectionString;
            db = Database.GetInstance("DB_Connection");
        }

        [HttpPost]
        public HttpResponseMessage DayIn_Out([FromBody] tbl_Employee employee)
        {


            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_Connection"].ConnectionString))

            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("API_Dayin_Dayout", connection)) //API_spVerifyMobile_Test
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.AddWithValue("@DeviceId", employee.DeviceId);
                    command.Parameters.AddWithValue("@Type", employee.Type);
                    command.Parameters.AddWithValue("@Token", Utility.Token);
                    command.Parameters.AddWithValue("@InLate", employee.InLate);
                    command.Parameters.AddWithValue("@InLong", employee.InLong);
                    command.Parameters.AddWithValue("@Distance_Mtr", employee.Distance_Mtr);




                    try
                    {
                        command.ExecuteNonQuery();

                        var result = new
                        {
                            isSuccess = true,
                            message = "Data inserted successfully"
                        };

                        string json = JsonConvert.SerializeObject(result);

                        return new HttpResponseMessage(HttpStatusCode.OK)
                        {
                            Content = new StringContent(json, Encoding.Default, "application/json")
                        };
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions here, and return an appropriate error response.
                        var result = new
                        {
                            isSuccess = false,
                            message = "Failed to insert data: " + ex.Message
                        };

                        string json = JsonConvert.SerializeObject(result);

                        return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                        {
                            Content = new StringContent(json, Encoding.Default, "application/json")
                        };

                    }

                }

            }
           

        }

    }
}
