using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Utilities.Constants;
using WebAPI.ViewModels.Catalog.Colors;
using WebAPI.ViewModels.Catalog.Sizes;
using WebAPI.ViewModels.Common;

namespace WebAPI.ApiIntegration
{
    public class ColorApiClient : BaseApiClient,IColorApiClient
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ColorApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;

        }
        public async Task<bool> CreateColor(ColorCreateRequest request)
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

            requestContent.Add(new StringContent(request.IdColor.ToString()), "IdColor");
            requestContent.Add(new StringContent(request.Name.ToString()), "Name");

            var response = await client.PostAsync($"/api/colors/", requestContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteColor(string id)
        {
            return await Delete($"/api/colors/" + id);
        }

        public async Task<List<ColorVm>> GetAll()
        {
            return await GetListAsync<ColorVm>("/api/colors");
        }

        public async Task<ColorVm> GetById(string id)
        {
            var data = await GetAsync<ColorVm>($"/api/colors/{id}");

            return data;
        }

        public async Task<PagedResult<ColorVm>> GetColorsPagings(GetColorPagingRequest request)
        {
            var data = await GetAsync<PagedResult<ColorVm>>(
               $"/api/colors/paging?pageIndex={request.PageIndex}" +
               $"&pageSize={request.PageSize}" +
               $"&keyword={request.Keyword}&categoryId={request.ColorId}");

            return data;
        }
    }
}
