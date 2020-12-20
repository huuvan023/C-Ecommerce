using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.ViewModels.Common;
using WebAPI.ViewModels.Orders;
using WebAPI.ViewModels.Sales;

namespace WebAPI.ApiIntegration
{
    public interface IOrderApiClient
    {
        Task<List<OrderVm>> GetAll(string languageId);

        Task<List<OrderVm>> GetAllByUser(string User,string languageId);

        Task<PagedResult<OrderVm>> GetOrdersPagings(GetOrderPagingRequest request);

        Task<OrderVm> GetById(string languageId, int id);

        Task<bool> Create(CheckoutRequest request);

    }
}
