using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VijayTmBar.Models;

namespace VijayTmBar.Controllers
{
    [BasicAuthentication]
    public class AlreadyLoginController : ApiController
    {
        [HttpGet]

        public HttpResponseMessage AlreadyLogin()
        {

            string accessToken = Utility.Token;
            //string isValidToken = AlreadyLogin.ValidateAccessToken(accessToken);
            UesrSecurity us = new UesrSecurity(accessToken);
            try
            {
                if (us.IsTokenValid())  //  us.IsValid
                {
                    // return Request.CreateResponse(HttpStatusCode.OK, successList);

                    var resultItem = new
                    {
                        isSuccess = true,
                    };
                    // successList.Add(resultItem);
                    return Request.CreateResponse(HttpStatusCode.OK, resultItem);
                }
                else
                {
                    var resultItem = new
                    {
                        isSuccess = false,
                    };
                    return Request.CreateResponse(HttpStatusCode.NotFound, resultItem);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }
    }
}
