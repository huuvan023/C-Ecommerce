using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EmmerceAPIHCMUE.Controllers;
using EmmerceAPIHCMUE.Models;
using EmmerceAPIHCMUE.Provider;

namespace EmmerceAPIHCMUE.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("/home/")]
    public class HomeController : ControllerBase
    {

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        [HttpGet("test")]
        public ResponseData Get()
        {
            //object dt = Connection.Instance.ExecuteNonQuery("insert into admin values('qwae', 'awqe', 'qdwe', 'qwae', 'qwe', '2020-12-01 00:00:00.000')");
            //return dt;
            //return new Home();
            //return new Home(2,3,"asd").getAll();
            return new ResponseData(1, "SUCCESS", null);
        }
       
        
    }
}
