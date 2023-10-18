using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VijayTmBar.Models
{
    public class ResponseMessage
    {
        public bool isSuccess { get; set; }
        public string Message { get; set; }
        public int ResponceCode { get; set; }
    }
}