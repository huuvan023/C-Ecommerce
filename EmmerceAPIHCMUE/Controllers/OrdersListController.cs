using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EmmerceAPIHCMUE.Controllers;
using System.Web;
using EmmerceAPIHCMUE.Models;
using EmmerceAPIHCMUE.Provider;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Net;

namespace EmmerceAPIHCMUE.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("/checkout/")]
    public class OrdersListController: ControllerBase
    {
        [HttpPost("add")]
        public ResponseData AddCheckout([FromBody] OrdersList orders)
        {
            try
            {
                if (Request.Headers["Authorization"] != "")
                {
                    CustomMiddleware middleware = new CustomMiddleware(Request.Headers["Authorization"]);
                    if (middleware.ValidateToken(Constants.Instance.USER_ROLE1))
                    {
                        if (orders.AddCheckout())
                        {
                            return new ResponseData(Constants.Instance.SUCCESS_CODE, Constants.Instance.SUCCESS_MESSAGE1, null);
                        }
                        return new ResponseData(Constants.Instance.FAIL_CODE, Constants.Instance.SOMETHING_WAS_WRONG, null);
                    }
                    else
                    {
                        return new ResponseData(Constants.Instance.FAIL_CODE, Constants.Instance.SESSION_EXPIRED, null);
                    }
                }
                else
                {
                    return new ResponseData(Constants.Instance.FAIL_CODE, Constants.Instance.SESSION_EXPIRED, null);
                }
            }
            catch (Exception e)
            {
                return new ResponseData(Constants.Instance.FAIL_CODE, e.Message.ToString(), null);
            }
        }
        [HttpPost("update-status")]
        public ResponseData UpdateStatus([FromBody] OrdersList orders)
        {
            try
            {
                if (Request.Headers["Authorization"] != "")
                {
                    CustomMiddleware middleware = new CustomMiddleware(Request.Headers["Authorization"]);
                    if (middleware.ValidateToken(Constants.Instance.USER_ROLE1))
                    {
                        if (orders.UpdateStatusCheckout())
                        {
                            return new ResponseData(Constants.Instance.SUCCESS_CODE, Constants.Instance.SUCCESS_MESSAGE1, null);
                        }
                        return new ResponseData(Constants.Instance.FAIL_CODE, Constants.Instance.SOMETHING_WAS_WRONG, null);
                    }
                    else
                    {
                        return new ResponseData(Constants.Instance.FAIL_CODE, Constants.Instance.SESSION_EXPIRED, null);
                    }
                }
                else
                {
                    return new ResponseData(Constants.Instance.FAIL_CODE, Constants.Instance.SESSION_EXPIRED, null);
                }
            }
            catch (Exception e)
            {
                return new ResponseData(Constants.Instance.FAIL_CODE, e.Message.ToString(), null);
            }
        }
    }
}
