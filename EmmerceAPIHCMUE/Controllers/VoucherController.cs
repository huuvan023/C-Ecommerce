using EmmerceAPIHCMUE.Models;
using EmmerceAPIHCMUE.Provider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EmmerceAPIHCMUE.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("/voucher")]

    public class VoucherController : ControllerBase
    {
        [HttpPost("add")]
        public ResponseData AddVouchers([FromBody] Voucher voucher)
        {
            try
            {
                if (Request.Headers["Authorization"] != "")
                {
                    CustomMiddleware middleware = new CustomMiddleware(Request.Headers["Authorization"]);
                    if (middleware.ValidateToken(Constants.Instance.ADMIN_ROLE1))
                    {
                        if (voucher.AddVoucher())
                        {
                            return new ResponseData(Constants.Instance.SUCCESS_CODE, Constants.Instance.ADD_SUCESS1, null);
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
                return new ResponseData(Constants.Instance.FAIL_CODE, Constants.Instance.SOMETHING_WAS_WRONG, null);
            }
        }

       
        [HttpPost("delete")]
        public ResponseData DeleteVouchers([FromBody] Voucher voucher)
        {
            try
            {
                if (Request.Headers["Authorization"] != "")
                {
                    CustomMiddleware middleware = new CustomMiddleware(Request.Headers["Authorization"]);
                    if (middleware.ValidateToken(Constants.Instance.ADMIN_ROLE1))
                    {
                        if (voucher.DeleteVoucher())
                        {
                            return new ResponseData(Constants.Instance.SUCCESS_CODE, Constants.Instance.DELETE_SUCESS1, null);
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
                return new ResponseData(Constants.Instance.FAIL_CODE, Constants.Instance.SOMETHING_WAS_WRONG, null);
            }
        }

        [HttpGet("all")]
        public ResponseData GetAllVoucher()
        {
            try
            {
                if (Request.Headers["Authorization"] != "")
                {
                    CustomMiddleware middleware = new CustomMiddleware(Request.Headers["Authorization"]);
                    if (middleware.ValidateToken(Constants.Instance.ADMIN_ROLE1))
                    {
                        Voucher voucher = new Voucher();
                        DataTable dt = voucher.GetAllVoucher();

                        List<Voucher> resData = new List<Voucher>();
                        foreach (DataRow row in dt.Rows)
                        {
                            Voucher a = new Voucher();
                            a.IdVoucher = row["idVoucher"].ToString();
                            a.Price = Int32.Parse(row["price"].ToString());
                            a.ExpiredDate = row["expiredDate"].ToString();
                            a.IsUse = Int32.Parse(row["isUse"].ToString());

                            resData.Add(a);
                        }
                        return new ResponseData(Constants.Instance.SUCCESS_CODE, Constants.Instance.SUCCESS_MESSAGE1, resData);
                    }
                }
                return new ResponseData(Constants.Instance.FAIL_CODE, Constants.Instance.FAIL_MESSAGE1, null);
            }
            catch (Exception e)
            {
                return new ResponseData(Constants.Instance.FAIL_CODE, Constants.Instance.SOMETHING_WAS_WRONG, null);
            }
        }
        [HttpPost("get-voucher")]
        public ResponseData GetVoucher([FromBody] Voucher v)
        {
            try
            {
                DataTable dt = v.GetVoucher();
                if(dt.Rows.Count > 0)
                {
                    Voucher a = new Voucher();
                    foreach (DataRow row in dt.Rows)
                    {
                        a.IdVoucher = row["idVoucher"].ToString();
                        a.Price = Int32.Parse(row["price"].ToString());
                        a.ExpiredDate = row["expiredDate"].ToString();
                        a.IsUse = Int32.Parse(row["isUse"].ToString());
                    }
                    return new ResponseData(Constants.Instance.SUCCESS_CODE, Constants.Instance.SUCCESS_MESSAGE1, a);
                }
                else
                {
                    return new ResponseData(Constants.Instance.FAIL_CODE, Constants.Instance.FAIL_MESSAGE1, null);
                }
            }
            catch (Exception e)
            {
                return new ResponseData(Constants.Instance.FAIL_CODE, Constants.Instance.SOMETHING_WAS_WRONG, null);
            }
        }
    }
}
