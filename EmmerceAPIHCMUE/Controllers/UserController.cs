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
    [Route("/user/")]
    public class UserController: ControllerBase
    {
        [HttpPost("signup")]
        public ResponseData Post([FromBody] User s)
        {
            try
            {
                if (s.IsEmailExits())
                {
                    return new ResponseData(Constants.Instance.FAIL_CODE, "Email in used!", null);
                }

                if (s.SignUp())
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
        [HttpPost("signin")]
        public ResponseData SignIn([FromBody] User s)
        {
            try
            {
                if(s.SignIn())
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
        public static string DataTableToJSONWithJSONNet(DataTable table)
        {
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(table);
            return JSONString;
        }
        [HttpGet("infor")]
        public ResponseData fetchUser()
        {
            try
            {
                if (Request.Headers["Authorization"] != "" && Helper.Instance.ValidateCurrentToken(Request.Headers["Authorization"]))
                {
                    var handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(Request.Headers["Authorization"]);
                    var idUser = token.Claims.Where(c => c.Type == "nameid").Select(c => c.Value).SingleOrDefault();
                    User a = new User();
                    DataTable dt = a.fetchUser(idUser);
                    foreach (DataRow row in dt.Rows)
                    {
                        a.idUser = row["idUser"].ToString();
                        a.email = row["email"].ToString();
                        a.password = "***";
                        a.firstName = row["firstName"].ToString();
                        a.lastName = row["lastName"].ToString();
                        a.birthday = row["birthday"].ToString();
                        a.phoneNumber = row["phoneNumber"].ToString();
                        a.address = row["address"].ToString();
                        a.note = row["note"].ToString();
                        a.province = row["province"].ToString();
                        a.interestedIn = row["interestedIn"].ToString();
                        a.lastLogin = row["lastLogin"].ToString();
                        a.avatar = row["avatar"].ToString();
                    }
                    return new ResponseData(Constants.Instance.FAIL_CODE, Constants.Instance.SUCCESS_MESSAGE1, a);
                }
                return new ResponseData(Constants.Instance.FAIL_CODE, Constants.Instance.SOMETHING_WAS_WRONG, null);
            }
            catch(Exception e)
            {
                return new ResponseData(Constants.Instance.FAIL_CODE, Constants.Instance.SOMETHING_WAS_WRONG, null);
            }
        }
        [HttpPost("reset-password")]
        public ResponseData ResetPassword([FromBody] User s)
        {
            try
            {
                if (s.IsEmailExits())
                {
                    string To = s.email;
                    string Subject = "Reset password";
                    string Body = "Xin chào" + s.email + ". Đây là mật khẩu mới của bạn";
                    if (SMTPSendMail.Instance.SendEmail(To, Subject, Body))
                    {
                        return new ResponseData(Constants.Instance.FAIL_CODE, Constants.Instance.SUCCESS_MESSAGE1, "Successfully! Please check your email!");
                    }
                }
                return new ResponseData(Constants.Instance.FAIL_CODE, Constants.Instance.EMAIL_NOT_EXIST1, null);
            }
            catch(Exception e)
            {
                return new ResponseData(Constants.Instance.FAIL_CODE, Constants.Instance.SOMETHING_WAS_WRONG, null);
            }
        }
    }
}
