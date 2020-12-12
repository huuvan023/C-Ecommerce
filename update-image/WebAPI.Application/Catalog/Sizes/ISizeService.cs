using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.ViewModels.Catalog.Sizes;
using WebAPI.ViewModels.Common;

namespace WebAPI.Application.Catalog.Sizes
{
    public interface ISizeService
    {
        Task<List<SizeVm>> GetAll(string languageId);

        Task<PagedResult<SizeVm>> GetSizesPagings(GetSizePagingRequest request);

        Task<string> CreateSize(SizeCreateRequest request);

        Task<SizeVm> GetById(string id, string languageId);

        Task<int> DeleteSize(string id);
    }
}
