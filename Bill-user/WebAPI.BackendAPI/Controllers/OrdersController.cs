using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.Catalog.Orders;
using WebAPI.ViewModels.Orders;
using WebAPI.ViewModels.Sales;

namespace WebAPI.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string languageId)
        {
            var products = await _orderService.GetAll(languageId);
            return Ok(products);
            
        }


        [HttpGet("paging")]
        public async Task<IActionResult> GetOrdersPaging([FromQuery] GetOrderPagingRequest request)
        {
            var order = await _orderService.GetOrdersPagings(request);
            return Ok(order);
        }

        //http://localhost:port/category/1
        [HttpGet("{id}/{languageId}")]
        public async Task<IActionResult> GetById(string languageId, int id)
        {
            var category = await _orderService.GetById(id, languageId);
            if (category == null)
                return BadRequest("Cannot find product");
            return Ok(category);
        }

        //Create
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] CheckoutRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var idOrder = await _orderService.Create(request);
            if (idOrder == 0)
                return BadRequest();

            var product = await _orderService.GetById(idOrder, request.LanguageId);

            return CreatedAtAction(nameof(GetById), new { id = idOrder }, product);
        }



    }
}
