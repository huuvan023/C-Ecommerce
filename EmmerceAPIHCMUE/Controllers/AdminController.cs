using EmmerceAPIHCMUE.Models;
using EmmerceAPIHCMUE.Provider;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmmerceAPIHCMUE.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("/admin/")]
    public class AdminController
    {
        [HttpPost("signin")]
        public ResponseData SignIn([FromBody] Admin s)
        {
            try
            {
                if (s.AdminLogin())
                {
                    string token = s.GetToken();
                    return new ResponseData(Constants.Instance.SUCCESS_CODE, Constants.Instance.LOGIN_SUCCESS1, new Token(token));
                }

                return new ResponseData(Constants.Instance.FAIL_CODE, Constants.Instance.LOGIN_FAIL1, null);
            }
            catch (Exception e)
            {
                return new ResponseData(Constants.Instance.FAIL_CODE, Constants.Instance.SOMETHING_WAS_WRONG, null);
            }
        }
        [HttpPost("signup")]
        public ResponseData SignUp([FromBody] Admin s)
        {
            try
            {

                if (s.AdminSignUp())
                {
                    return new ResponseData(Constants.Instance.SUCCESS_CODE, "Sign up success!", null);
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
