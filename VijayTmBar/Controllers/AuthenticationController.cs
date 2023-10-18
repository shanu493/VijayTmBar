using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using Dotplus.Database.StoreProcedure;
using Database = Dotplus.Database.StoreProcedure.Database;
using VijayTmBar.Models;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;

namespace VijayTmBar.Controllers
{
    public class AuthenticationController : ApiController
    {
        Database db;
        string Db;
        public AuthenticationController()
        {
           
            Db = ConfigurationManager.ConnectionStrings["DB_Connection"].ConnectionString;
            db = Database.GetInstance("DB_Connection");
        }

        [HttpPost]
        public HttpResponseMessage Login([FromBody] tbl_Employee employee)
        {
            //string hashedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(employee.UPassword, "SHA1");

            // using (SqlConnection connection = new SqlConnection(Db))
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_Connection"].ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("API_SpLogin", connection)) //    API_SpLogin_Test
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@username", employee.MobileNo);
                    command.Parameters.AddWithValue("@password", employee.UPassword);//Convert.ToBase64String(Encoding.UTF8.GetBytes(hashedPassword))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            // Retrieve the first row from the DataTable
                            DataRow row = dataTable.Rows[0];

                            // Create an anonymous type with the desired properties
                            var result = new
                            {
                                ID = Convert.ToInt32(row["id"]),
                                EmpCode = row["EmpCode"].ToString(),
                                Sts = row["Sts"].ToString(),
                                Token = row["Token"].ToString(),
                                isSuccess = true
                                
                            };

                            // Serialize the anonymous type to JSON
                            string json = JsonConvert.SerializeObject(result);

                            // Create and return an HttpResponseMessage with the JSON content
                            return new HttpResponseMessage(HttpStatusCode.OK)
                            {
                                Content = new StringContent(json, Encoding.Default, "application/json")
                            };
                        }


                    }

                }
            }

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Username & Password");
        }
    }
}
