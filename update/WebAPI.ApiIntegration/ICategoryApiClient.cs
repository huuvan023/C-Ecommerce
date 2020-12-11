using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.ViewModels.Catalog.Categories;
using WebAPI.ViewModels.Common;

namespace WebAPI.ApiIntegration
{
    public interface ICategoryApiClient
    {
        Task<List<CategoryVm>> GetAll(string languageId);

        Task<PagedResult<CategoryVm>> GetCategoriesPagings(GetCategoryPagingRequest request);

        Task<bool> CreateProduct(CategoryCreateRequest request);

        Task<CategoryVm> GetById(string languageId, int id);

        Task<bool> UpdateCategory(CategoryUpdateRequest request);

        Task<bool> DeleteCategory(int id);
    }
}
