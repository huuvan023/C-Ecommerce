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
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace EmmerceAPIHCMUE.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("/user/")]
    public class UserController: ControllerBase
    {
        public static IWebHostEnvironment _environment;
        public UserController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
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
                    s.UpdateLastLogin();
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
                    User userUpdatePass = new User();
                    string randomPassword = Helper.Instance.CreateRandomPassword(8);
                    if (!s.ResetPassword(randomPassword))
                    {
                        return new ResponseData(Constants.Instance.FAIL_CODE, Constants.Instance.RESET_PASSWORD_FAIL1, null);
                    }
                    string To = s.email;
                    string Subject = "Reset password";
                    string Body = "Xin chào " + s.email + ". Đây là mật khẩu mới của bạn là: " + randomPassword;
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
        [HttpPost("update")]
        public ResponseData UpdateUser([FromBody]  User s)
        {
            try
            {
                if (s.UpdateUser())
                {
                    return new ResponseData(Constants.Instance.SUCCESS_CODE, Constants.Instance.UPDATE_SUCESS1, null);
                }
                return new ResponseData(Constants.Instance.FAIL_CODE, Constants.Instance.UPDATE_FAIL1, null);
            }
            catch (Exception e)
            {
                return new ResponseData(Constants.Instance.FAIL_CODE, Constants.Instance.SOMETHING_WAS_WRONG, null);
            }
        } 
        [HttpGet("all")]
        public ResponseData GetAllUser()
        {
           try
            {
                if (Request.Headers["Authorization"] != "")
                {
                    CustomMiddleware middleware = new CustomMiddleware(Request.Headers["Authorization"]);
                    if (middleware.ValidateToken(Constants.Instance.ADMIN_ROLE1))
                    {
                        User s = new User();
                        DataTable dt = s.GetAllUser();

                        List<User> resData = new List<User>();
                        foreach (DataRow row in dt.Rows)
                        {
                            User a = new User();
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
                            resData.Add(a);
                        }
                        return new ResponseData(Constants.Instance.SUCCESS_CODE, Constants.Instance.SUCCESS_MESSAGE1, resData);
                    }
                }
                return new ResponseData(Constants.Instance.FAIL_CODE, Constants.Instance.FAIL_MESSAGE1, null);
            }
            catch(Exception e)
            {
                return new ResponseData(Constants.Instance.FAIL_CODE, Constants.Instance.SOMETHING_WAS_WRONG, null);
            }
        }
        [HttpPost("files")]
        public async Task<string> UploadFile(IFormFile objFile)
        {
            try
            {
                if (objFile.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + objFile.FileName))
                    {
                        objFile.CopyTo(fileStream);
                        fileStream.Flush();
                        return "Upload success!";
                    }
                }
                return "Upload fail!";
            }
            catch(Exception e)
            {
                return "Upload fail! Something went wrong";
            }
        }
    }
}
