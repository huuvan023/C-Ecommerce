using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebAPI.ApiIntegration;
using WebAPI.Utilities.Constants;
using WebAPI.ViewModels.Catalog.Colors;

namespace WebAPI.AdminApp.Controllers
{
    public class ColorController : Controller
    {
        private readonly IColorApiClient _colorApiClient;
        private readonly IConfiguration _configuration;
        private readonly IProductApiClient _productApiClient;
        public ColorController(IColorApiClient colorApiClient, IConfiguration configuration, IProductApiClient productApiClient)
        {
            _colorApiClient = colorApiClient;
            _configuration = configuration;
            _productApiClient = productApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var sessions = HttpContext.Session.GetString("Token");
            var request = new GetColorPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
           
            };
            var data = await _colorApiClient.GetColorsPagings(request);
            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }

            return View(data);
        }

        //create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] ColorCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _colorApiClient.CreateColor(request);
            if (result)
            {
                TempData["result"] = "Thêm mới Color thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm Color thất bại");
            return View(request);
        }

        //delete
        [HttpGet]
        public IActionResult Delete(string id)
        {
            return View(new ColorDeleteRequest()
            {
                Id = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ColorDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _colorApiClient.DeleteColor(request.Id);
            if (result)
            {
                TempData["result"] = "Xóa thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Xóa không thành công");
            return View(request);
        }
    }
}

