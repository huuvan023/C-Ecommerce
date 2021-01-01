using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.ViewModels.Catalog.Colors;
using WebAPI.ViewModels.Catalog.Sizes;
using WebAPI.ViewModels.Common;

namespace WebAPI.ApiIntegration
{
    public interface IColorApiClient
    {
        Task<List<ColorVm>> GetAll();

        Task<PagedResult<ColorVm>> GetColorsPagings(GetColorPagingRequest request);

        Task<bool> CreateColor(ColorCreateRequest request);

        Task<ColorVm> GetById(string id);

        Task<bool> DeleteColor(string id);
    }
}
