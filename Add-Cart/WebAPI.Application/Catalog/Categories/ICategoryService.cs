using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.ViewModels.Catalog.Categories;
using WebAPI.ViewModels.Common;

namespace WebAPI.Application.Catalog.Categories
{
    public interface ICategoryService
    {
        Task<List<CategoryVm>> GetAll(string languageId);

        Task<PagedResult<CategoryVm>> GetCategoriesPagings(GetCategoryPagingRequest request);

        Task<int> Create(CategoryCreateRequest request);

        Task<CategoryVm> GetById( string languageId, int categoryId);

        Task<int> Update(CategoryUpdateRequest request);

        Task<int> Delete(int idCategory);


    }
}
