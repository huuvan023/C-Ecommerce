using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data.EF;
using WebAPI.ViewModels.Catalog.Sizes;
using WebAPI.ViewModels.Common;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data.Entities;
using WebAPI.Utilities.Exceptions;

namespace WebAPI.Application.Catalog.Sizes
{
    public class SizeService : ISizeService
    {
        private readonly WebApiDbContext _context;

        public SizeService(WebApiDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreateSize(SizeCreateRequest request)
        {
            var size = new productSize()
            {
                idSize=request.IdSize,
                sizeName=request.Name,
                LanguageId=request.LanguageId

            };

       

            _context.ProductSizes.Add(size);
            await _context.SaveChangesAsync();
            return size.idSize;
        }

        public async Task<int> DeleteSize(string id)
        {
            var size = await _context.ProductSizes.FindAsync(id);
            if (size == null) throw new WebAPIException($"Cannot find a size: {id}");

            _context.ProductSizes.Remove(size);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<SizeVm>> GetAll(string languageId)
        {
            var query = from c in _context.ProductSizes
                        select new { c };
            return await query.Select(x => new SizeVm()
            {
                IdSize = x.c.idSize,
                Name = x.c.sizeName
            }).ToListAsync();
        }

        public async Task<SizeVm> GetById(string id, string languageId)
        {
            var size = await _context.ProductSizes.FindAsync(id);
            var sizeViewModel = new SizeVm()
            {
                IdSize = size.idSize,
                Name = size.sizeName,
                LanguageId = size.LanguageId
            };
            return sizeViewModel;
        }

        public async Task<PagedResult<SizeVm>> GetSizesPagings(GetSizePagingRequest request)
        {
            //1. Select join
            var query = from p in _context.ProductSizes
                        where p.LanguageId == request.LanguageId
                        select new { p };
            //2. filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.p.sizeName.Contains(request.Keyword));
            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new SizeVm()
                {
                    IdSize = x.p.idSize,
                    Name = x.p.sizeName,
                    LanguageId = request.LanguageId
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<SizeVm>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }
    }
}
