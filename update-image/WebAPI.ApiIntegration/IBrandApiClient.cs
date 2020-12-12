using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.ViewModels.Catalog.Brands;
using WebAPI.ViewModels.Common;

namespace WebAPI.ApiIntegration
{
    public interface IBrandApiClient
    {
        Task<List<BrandVm>> GetAll(string languageId);

        Task<PagedResult<BrandVm>> GetBrandsPagings(GetBrandPagingRequest request);

        Task<bool> CreateBrand(BrandCreateRequest request);

        Task<BrandVm> GetById(string id, string languageId);

        Task<bool> DeleteBrand(string id);
    }
}
