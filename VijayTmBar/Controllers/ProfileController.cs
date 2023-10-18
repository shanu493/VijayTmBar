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
using System.Reflection.Emit;

namespace VijayTmBar.Controllers
{
    public class ProfileController : ApiController
    {
        string db;

        public ProfileController()
        {


            db = ConfigurationManager.ConnectionStrings["DB_Connection"].ConnectionString;
        }
        [BasicAuthentication]
        [HttpGet]
        public HttpResponseMessage Profile()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(db))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("API_GetProfile", connection))//API_GetProfile_Test
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        command.Parameters.AddWithValue("@Token", Utility.Token);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            List<object> resultList = new List<object>();

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var resultItem = new
                                    {
                                        ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                        EmpCode=reader.GetString(reader.GetOrdinal("EmpCode")),
                                        FullName = reader.GetString(reader.GetOrdinal("FullName")),
                                        EmailID = reader.GetString(reader.GetOrdinal("EmailID")),
                                        MobileNo = reader.GetString(reader.GetOrdinal("MobileNo")),
                                        WhatsAppNo = reader.GetString(reader.GetOrdinal("WhatsAppNo")),
                                        FullAddress = reader.GetString(reader.GetOrdinal("FullAddress")),
                                        DOB = reader.GetDateTime(reader.GetOrdinal("DOB")),
                                        JoiningDate = reader.GetDateTime(reader.GetOrdinal("JoiningDate"))
                                   
                                };
                                    resultList.Add(resultItem);
                                }
                            }
                            return Request.CreateResponse(HttpStatusCode.OK, resultList);

                        }
                    }
                }
            }
            catch (Exception exp)
            {
                throw new Exception(exp.ToString());
            }
        }

    }
}
