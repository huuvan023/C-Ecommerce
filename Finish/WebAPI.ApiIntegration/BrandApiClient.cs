using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebAPI.Utilities.Constants;
using WebAPI.ViewModels.Catalog.Brands;
using WebAPI.ViewModels.Common;

namespace WebAPI.ApiIntegration
{
    public class BrandApiClient : BaseApiClient, IBrandApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BrandApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;

        }

        public async Task<bool> CreateBrand(BrandCreateRequest request)
        {
            var sessions = _httpContextAccessor
               .HttpContext
               .Session
               .GetString(SystemConstants.AppSettings.Token);

            var languageId = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

            requestContent.Add(new StringContent(request.IdBrand.ToString()), "IdBrand");
            requestContent.Add(new StringContent(request.Name.ToString()), "Name");
            requestContent.Add(new StringContent(request.Details.ToString()), "Details");
            requestContent.Add(new StringContent(languageId), "languageId");

            var response = await client.PostAsync($"/api/brands/", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteBrand(string id)
        {
            return await Delete($"/api/brands/" + id);
        }

        public async Task<List<BrandVm>> GetAll(string languageId)
        {
            return await GetListAsync<BrandVm>("/api/brands?languageId=" + languageId);
        }

        public async Task<BrandVm> GetById(string id, string languageId)
        {
            var data = await GetAsync<BrandVm>($"/api/brands/{id}/{languageId}");

            return data;
        }

        public async Task<PagedResult<BrandVm>> GetBrandsPagings(GetBrandPagingRequest request)
        {
            var data = await GetAsync<PagedResult<BrandVm>>(
                $"/api/brands/paging?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyword={request.Keyword}&languageId={request.LanguageId}&categoryId={request.BrandId}");

            return data;
        }
    }
}
