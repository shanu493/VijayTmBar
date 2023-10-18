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

namespace VijayTmBar.Controllers
{
    
  
    public class Checkin_CheckoutListController : ApiController
    {
        string db;

        public Checkin_CheckoutListController()
        {


            db = ConfigurationManager.ConnectionStrings["DB_Connection"].ConnectionString;
        }
        [BasicAuthentication]
        [HttpGet]
        public HttpResponseMessage Checkin_CheckoutList()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(db))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("API_GetCheckin_Checkout", connection))
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
                                        EmpId = reader.GetInt32(reader.GetOrdinal("EmpId")),
                                        //FullName = reader.GetString(reader.GetOrdinal("FullName")),
                                        //Image = reader.GetString(reader.GetOrdinal("Image")),
                                        DIO_Time = reader.GetDateTime(reader.GetOrdinal("DIO_Time")),
                                        InLat = reader.GetString(reader.GetOrdinal("InLat")),
                                        InLong = reader.GetString(reader.GetOrdinal("InLong")),
                                        DeviceID = reader.GetString(reader.GetOrdinal("DeviceID")),
                                        Type = reader.GetString(reader.GetOrdinal("Type")),
                                        //Distance_Mtr = reader.GetInt32(reader.GetOrdinal("Distance_Mtr"))
                                        //Sts = reader.GetChars(reader.GetOrdinal("Sts")),

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
