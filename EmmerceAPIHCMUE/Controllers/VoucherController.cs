using EmmerceAPIHCMUE.Models;
using EmmerceAPIHCMUE.Provider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
                if (voucher.AddVoucher())
                {
                    return new ResponseData(Constants.Instance.SUCCESS_CODE, Constants.Instance.ADD_SUCESS1, null);
                }
                return new ResponseData(Constants.Instance.FAIL_CODE, Constants.Instance.SOMETHING_WAS_WRONG, null);
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
                if (voucher.DeleteVoucher())
                {
                    return new ResponseData(Constants.Instance.SUCCESS_CODE, Constants.Instance.DELETE_SUCESS1, null);
                }
                return new ResponseData(Constants.Instance.FAIL_CODE, Constants.Instance.SOMETHING_WAS_WRONG, null);
            }
            catch (Exception e)
            {
                return new ResponseData(Constants.Instance.FAIL_CODE, Constants.Instance.SOMETHING_WAS_WRONG, null);
            }
        }
    }
}
