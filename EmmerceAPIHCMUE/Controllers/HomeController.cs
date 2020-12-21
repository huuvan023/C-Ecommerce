using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using EmmerceAPIHCMUE.Provider;

namespace EmmerceAPIHCMUE.Controllers
{
    [ApiController]
    [Route("/home/")]
    public class HomeController : ControllerBase
    {

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        [HttpGet("test")]
        public object Get()
        {
            Connection conn = new Connection();
            object dt = conn.ExecuteNonQuery("insert into admin values('qwe', 'wqe', 'qwe', 'qwe', 'qwe', '2020-12-01 00:00:00.000')");
            return dt;
            //return new Home();
        }
    }
}
