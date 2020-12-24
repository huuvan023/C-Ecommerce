using EmmerceAPIHCMUE.Models;
using EmmerceAPIHCMUE.Provider;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EmmerceAPIHCMUE.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("/product-photo/")]
    public class ProductPhotoController : ControllerBase
    {
        [HttpPost("add")]
        public ResponseData AddProductPhoto([FromBody] ProductPhoto p)
        {
            try
            {
                if (Request.Headers["Authorization"] != "")
                {
                    CustomMiddleware middleware = new CustomMiddleware(Request.Headers["Authorization"]);
                    if (middleware.ValidateToken(Constants.Instance.ADMIN_ROLE1))
                    {
                        if (p.AddProductPhoto())
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
        [HttpPost("delete")]
        public ResponseData DeleteProductPhoto([FromBody] ProductPhoto p)
        {
            try
            {
                if (Request.Headers["Authorization"] != "")
                {
                    CustomMiddleware middleware = new CustomMiddleware(Request.Headers["Authorization"]);
                    if (middleware.ValidateToken(Constants.Instance.ADMIN_ROLE1))
                    {
                        if (p.DeleteProductPhoto())
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
        [HttpPost("update")]
        public ResponseData UpdateProductPhoto([FromBody] ProductPhoto p)
        {
            try
            {
                if (Request.Headers["Authorization"] != "")
                {
                    CustomMiddleware middleware = new CustomMiddleware(Request.Headers["Authorization"]);
                    if (middleware.ValidateToken(Constants.Instance.ADMIN_ROLE1))
                    {
                        if (p.UpdateProductPhoto())
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
        [HttpGet("all")]
        public ResponseData GetAllPhoto()
        {
            try
            {

                ProductPhoto p = new ProductPhoto();
                DataTable dt = p.GetAllPhoto();

                List<ProductPhoto> resData = new List<ProductPhoto>();
                foreach (DataRow row in dt.Rows)
                {
                    ProductPhoto a = new ProductPhoto();
                    a.idPhoto = row["idPhoto"].ToString();
                    a.idProduct = row["idProduct"].ToString();
                    a.link = row["link"].ToString();
                    a.uploadedTime = row["uploadedTime"].ToString();
                    resData.Add(a);
                }
                return new ResponseData(Constants.Instance.SUCCESS_CODE, Constants.Instance.SUCCESS_MESSAGE1, resData);
            }
            catch (Exception e)
            {
                return new ResponseData(Constants.Instance.FAIL_CODE, e.Message.ToString(), null);
            }
        }
        [HttpPost("find-by-id")]
        public ResponseData FindByID([FromBody] Product b)
        {
            try
            {
                ProductPhoto rs = new ProductPhoto();
                return new ResponseData(Constants.Instance.SUCCESS_CODE, Constants.Instance.SUCCESS_MESSAGE1, rs.FindByProductID(b.IdProduct));
            }
            catch (Exception e)
            {
                return new ResponseData(Constants.Instance.FAIL_CODE, e.Message.ToString(), null);
            }
        }
    }
}
