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
                        var handler = new JwtSecurityTokenHandler();
                        var token = handler.ReadJwtToken(Request.Headers["Authorization"]);
                        var idUser = token.Claims.Where(c => c.Type == "nameid").Select(c => c.Value).SingleOrDefault();
                        orders.idUser = idUser;
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
                    if (middleware.ValidateToken(Constants.Instance.USER_ROLE1) || middleware.ValidateToken(Constants.Instance.ADMIN_ROLE1))
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
        [HttpPost("details")]
        public ResponseData UpdateStatus([FromBody] OrdersDetails details)
        {
            try
            {
                if (Request.Headers["Authorization"] != "")
                {
                    CustomMiddleware middleware = new CustomMiddleware(Request.Headers["Authorization"]);
                    if (middleware.ValidateToken(Constants.Instance.USER_ROLE1) || middleware.ValidateToken(Constants.Instance.ADMIN_ROLE1))
                    {
                        DataTable dt = details.GetDetailsOder();
                        List<OrdersDetails> od = new List<OrdersDetails>();
                        foreach (DataRow row in dt.Rows)
                        {
                          OrdersDetails res = new OrdersDetails();
                          res.idOrderList = row["idOrderList"].ToString();
                          res.idOder = row["idOder"].ToString();
                          res.idProduct = row["idProduct"].ToString();
                          res.quanlity = row["quality"].ToString();
                          od.Add(res);
                        }
                        return new ResponseData(Constants.Instance.SUCCESS_CODE, Constants.Instance.SUCCESS_MESSAGE1, od);
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
