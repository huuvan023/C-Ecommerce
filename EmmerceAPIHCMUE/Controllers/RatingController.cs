using EmmerceAPIHCMUE.Models;
using EmmerceAPIHCMUE.Provider;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace EmmerceAPIHCMUE.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("/rating")]
    public class RatingController : Controller
    {
        [HttpPost("add")]
        public ResponseData AddRating([FromBody] Rating rating)
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
                        rating.idUser = idUser;

                        if (rating.AddRating())
                        {
                            return new ResponseData(Constants.Instance.SUCCESS_CODE, Constants.Instance.ADD_SUCESS1, null);
                        }
                        return new ResponseData(Constants.Instance.FAIL_CODE, Constants.Instance.USER_NOT_AUTHENTICATED, null);
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
        public ResponseData DeleteRating([FromBody] Rating rating)
        {
            try
            {
                if (Request.Headers["Authorization"] != "")
                {
                    CustomMiddleware middleware = new CustomMiddleware(Request.Headers["Authorization"]);
                    if (middleware.ValidateToken(Constants.Instance.USER_ROLE1))
                    {
                        if (rating.DeleteRating())
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

        [HttpPost("update")]
        public ResponseData UpdateRating([FromBody] Rating rating)
        {
            try
            {
                if (Request.Headers["Authorization"] != "")
                {
                    CustomMiddleware middleware = new CustomMiddleware(Request.Headers["Authorization"]);
                    if (middleware.ValidateToken(Constants.Instance.USER_ROLE1))
                    {
                        if (rating.UpdateRating())
                        {
                            return new ResponseData(Constants.Instance.SUCCESS_CODE, Constants.Instance.UPDATE_SUCESS1, null);
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
        public ResponseData GetAllRating()
        {
            try
            {
                Rating rating = new Rating();
                DataTable dt = rating.GetAllRating();

                List<Rating> resData = new List<Rating>();
                foreach (DataRow row in dt.Rows)
                {
                    Rating a = new Rating();
                    a.idUser = row["idUser"].ToString();
                    a.idProduct = row["idProduct"].ToString();
                    a.comment = row["comment"].ToString();
                    a.rate = Int32.Parse(row["rate"].ToString());
                    a.rateDate = row["rateDate"].ToString();

                    resData.Add(a);
                }
                return new ResponseData(Constants.Instance.SUCCESS_CODE, Constants.Instance.SUCCESS_MESSAGE1, resData);
            }
            catch (Exception e)
            {
                return new ResponseData(Constants.Instance.FAIL_CODE, Constants.Instance.SOMETHING_WAS_WRONG, null);
            }
        }
        [HttpPost("get-by")]
        public ResponseData GetByID([FromBody] Rating rating)
        {
            try
            {
                DataTable dt = rating.getByID();

                List<Rating> resData = new List<Rating>();
                foreach (DataRow row in dt.Rows)
                {
                    Rating a = new Rating();
                    a.idUser = row["idUser"].ToString();
                    a.idProduct = row["idProduct"].ToString();
                    a.comment = row["comment"].ToString();
                    a.rate = Int32.Parse(row["rate"].ToString());
                    a.rateDate = row["rateDate"].ToString();

                    resData.Add(a);
                }
                return new ResponseData(Constants.Instance.SUCCESS_CODE, Constants.Instance.SUCCESS_MESSAGE1, resData);
            }
            catch (Exception e)
            {
                return new ResponseData(Constants.Instance.FAIL_CODE, Constants.Instance.SOMETHING_WAS_WRONG, null);
            }
        }
    }
}
