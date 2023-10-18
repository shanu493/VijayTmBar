//using Dotplus.Database.StoreProcedure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Results;
//using System.Net.Http.HttpResponseMessage;

namespace VijayTmBar.Models
{

    public class UesrSecurity
    {
        private string _Token;
        public string Token
        {
            get
            {
                return _Token;
            }
        }
        public UesrSecurity(string Token)
        {
            _Token = Token;
        }
        public UesrSecurity()
        {
            //HttpContext.Current.User.Identity.Name
        }

        //public bool IsValid
        //{
        //    get
        //    {
        //        SqlParameter[] parameters = new SqlParameter[]
        //        {
        //            new SqlParameter("@Token",  _Token)
        //        };
        //        Database db = Database.GetInstance();
        //        var RV = (int)db.fn_ExecuteScalar("Stud_CheckLogin", parameters);
        //        return RV > 0;
        //    }
        //}

        public bool IsTokenValid()
        {
            string Db;
            Db = ConfigurationManager.ConnectionStrings["DB_Connection"].ConnectionString;
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@Token",  _Token)
            };

            using (SqlConnection connection = new SqlConnection(Db))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("API_CheckLogin", connection))//API_CheckLogin_Test
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(parameters);

                    int returnValue = (int)command.ExecuteScalar();

                    return returnValue > 0;
                }
            }
        }


      


        public string GetOtp
        {
            get {

                string Db;
                Db = ConfigurationManager.ConnectionStrings["DB_Connection"].ConnectionString;
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@Token",  _Token)
                };

                using (SqlConnection connection = new SqlConnection(Db))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("API_GetOtp_Test", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        //command.Parameters.AddRange(parameters);

                        string returnValue = (string)command.ExecuteScalar();

                        return returnValue ;
                    }
                }
            }
        }
     




    }
}