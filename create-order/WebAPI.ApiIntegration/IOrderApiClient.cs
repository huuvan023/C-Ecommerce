using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.ViewModels.Common;
using WebAPI.ViewModels.Orders;

namespace WebAPI.ApiIntegration
{
    public interface IOrderApiClient
    {
        Task<List<OrderVm>> GetAll(string languageId);

        Task<PagedResult<OrderVm>> GetOrdersPagings(GetOrderPagingRequest request);

        Task<OrderVm> GetById(string languageId, int id);

        Task<bool> Create(OrderCreateRequest request);

    }
}
