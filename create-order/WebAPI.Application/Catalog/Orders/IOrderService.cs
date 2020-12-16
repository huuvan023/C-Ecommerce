using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data.Entities;
using WebAPI.ViewModels.Catalog.Products;
using WebAPI.ViewModels.Common;
using WebAPI.ViewModels.Orders;

namespace WebAPI.Application.Catalog.Orders
{
    public interface IOrderService
    {
        Task<List<OrderVm>> GetAll(string languageId);

        Task<PagedResult<OrderVm>> GetOrdersPagings(GetOrderPagingRequest request);

        Task<int> Create(OrderCreateRequest request);

        Task<OrderVm> GetById(int id, string languageId);

        Task<int> Delete(int id);

      
    }
}
