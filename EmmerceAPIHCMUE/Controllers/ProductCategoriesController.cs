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
    [Route("/product-category/")]
    public class ProductCategoriesController : ControllerBase
    {
        [HttpPost("add")]
        public ResponseData AddProductCategories([FromBody] ProductCategories p)
        {
            try
            {
                if (Request.Headers["Authorization"] != "")
                {
                    CustomMiddleware middleware = new CustomMiddleware(Request.Headers["Authorization"]);
                    if (middleware.ValidateToken(Constants.Instance.ADMIN_ROLE1))
                    {
                        if (p.AddProductCategory())
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
        public ResponseData DeleteProductCategories([FromBody] ProductCategories p)
        {
            try
            {
                if (Request.Headers["Authorization"] != "")
                {
                    CustomMiddleware middleware = new CustomMiddleware(Request.Headers["Authorization"]);
                    if (middleware.ValidateToken(Constants.Instance.ADMIN_ROLE1))
                    {
                        if (p.DeleteProductCategory())
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
        public ResponseData UpdateProductCategories([FromBody] ProductCategories p)
        {
            try
            {
                if (Request.Headers["Authorization"] != "")
                {
                    CustomMiddleware middleware = new CustomMiddleware(Request.Headers["Authorization"]);
                    if (middleware.ValidateToken(Constants.Instance.ADMIN_ROLE1))
                    {
                        if (p.UpdateProductCategory())
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
        public ResponseData GetAllCategory()
        {
            try
            {
                
                ProductCategories p = new ProductCategories();
                DataTable dt = p.GetAllCaregory();

                List<ProductCategories> resData = new List<ProductCategories>();
                foreach (DataRow row in dt.Rows)
                {
                    ProductCategories a = new ProductCategories();
                    a.idCategory = row["idCategory"].ToString();
                    a.categoryName = row["categoryName"].ToString();
                    resData.Add(a);
                }
                return new ResponseData(Constants.Instance.SUCCESS_CODE, Constants.Instance.SUCCESS_MESSAGE1, resData);
            }
            catch (Exception e)
            {
                return new ResponseData(Constants.Instance.FAIL_CODE, e.Message.ToString(), null);
            }
        }
    }
}
