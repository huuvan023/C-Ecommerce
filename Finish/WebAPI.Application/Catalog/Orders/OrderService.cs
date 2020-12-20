using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Data.EF;
using WebAPI.ViewModels.Common;
using WebAPI.ViewModels.Orders;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data.Entities;
using WebAPI.ViewModels.Sales;
using WebAPI.Models;
using Microsoft.AspNetCore.Http;
using WebAPI.Utilities.Constants;
using Newtonsoft.Json;



namespace WebAPI.Application.Catalog.Orders
{
    public class OrderService : IOrderService
    {

        private readonly WebApiDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderService(WebApiDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<int> Create(CheckoutRequest request)
        {

            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
            if (request.OrderDetails != null)
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(request.OrderDetails);
            var orderdetail = new List<OrderDetail>();
            
            var user = _context.users.FirstOrDefault(x => x.UserName == request.UserName);
            var userid = user.Id;
            
            foreach (var item in currentCart)
            {
                orderdetail.Add(new OrderDetail()
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = item.Price,
                });
            }

            var order = new Order()
            {
                UserName = request.UserName,
                ShipAddress = request.Address,
                ShipEmail = request.Email,
                ShipName = request.Name,
                ShipPhoneNumber = request.PhoneNumber,
                OrderDate = DateTime.Now,
                OrderDetails = orderdetail,
                LanguageId=request.LanguageId,
                UserId=userid               
            };            
            //Save image

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order.Id; 
        }

        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderVm>> GetAll(string languageId)
        {
            
            var query = from p in _context.Orders
                        join pt in _context.OrderDetails on p.Id equals pt.OrderId
                        join ptt in _context.users on p.UserName equals ptt.UserName
                        join c in _context.products on pt.ProductId equals c.ProductId
                        select new { p, pt,ptt,c };
            return await query.Select(x => new OrderVm()
            {
                Id = x.p.Id,
                ProductId = x.c.ProductId,
                ShipName = x.p.ShipName,
                ShipAddress = x.p.ShipAddress,
                ShipEmail = x.p.ShipEmail,
                ShipPhoneNumber = x.p.ShipPhoneNumber,
                Quantity = x.pt.Quantity,
                Price = x.pt.Price,
                OrderDate = x.p.OrderDate,
                Status = x.p.Status,               
            }).ToListAsync();
        }

        public async Task<List<OrderVm>> GetAllByUser(string User, string languageId)
        {
            var query = from p in _context.Orders
                        join pt in _context.OrderDetails on p.Id equals pt.OrderId
                        join ptt in _context.users on p.UserName equals ptt.UserName
                        join c in _context.products on pt.ProductId equals c.ProductId
                        where p.UserName==User
                        select new { p, pt, ptt, c };
            return await query.Select(x => new OrderVm()
            {
                Id = x.p.Id,
                ProductId = x.c.ProductId,
                ShipName = x.p.ShipName,
                ShipAddress = x.p.ShipAddress,
                ShipEmail = x.p.ShipEmail,
                ShipPhoneNumber = x.p.ShipPhoneNumber,
                Quantity = x.pt.Quantity,
                Price = x.pt.Price,
                OrderDate = x.p.OrderDate,
                Status = x.p.Status,
            }).ToListAsync();
        }

        public async Task<OrderVm> GetById(int id, string languageId)
        {
            var query = from p in _context.Orders
                        join pt in _context.OrderDetails on p.Id equals pt.OrderId
                        join ptt in _context.users on p.UserName equals ptt.UserName
                        join c in _context.products on pt.ProductId equals c.ProductId
                        where p.LanguageId == languageId && p.Id==id
                        select new { p, pt, ptt, c };
            return await query.Select(x => new OrderVm()
            {
                Id = x.p.Id,
                UserName=x.p.UserName,
                UserId=x.ptt.Id,
                ProductId = x.c.ProductId,
                ShipName = x.p.ShipName,
                ShipAddress = x.p.ShipAddress,
                ShipEmail = x.p.ShipEmail,
                ShipPhoneNumber = x.p.ShipPhoneNumber,
                Quantity = x.pt.Quantity,
                Price = x.pt.Price,
                OrderDate = x.p.OrderDate,
            }).FirstOrDefaultAsync();
        }

        

        public async Task<PagedResult<OrderVm>> GetOrdersPagings(GetOrderPagingRequest request)
        {
            //1. Select join
            var query = from p in _context.Orders
                        join pt in _context.OrderDetails on p.Id equals pt.OrderId
                        join ptt in _context.users on p.UserName equals ptt.UserName
                        join c in _context.products on pt.ProductId equals c.ProductId
                        where p.LanguageId==request.LanguageId && ptt.UserName==request.UserName                   
                        select new { p, pt,ptt,c };
            //2. filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.p.ShipName.Contains(request.Keyword));


            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new OrderVm()
                {
                    Id=x.p.Id,
                    ProductId=x.c.ProductId,
                    ShipName=x.p.ShipName,
                    ShipAddress=x.p.ShipAddress,
                    ShipEmail=x.p.ShipEmail,
                    ShipPhoneNumber=x.p.ShipPhoneNumber,
                    Quantity=x.pt.Quantity,
                    Price=x.pt.Price,
                    OrderDate=x.p.OrderDate,
                    Status=x.p.Status,
                    LanguageId=request.LanguageId

                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<OrderVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }
    }
}
