using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.ViewModels.Common;

namespace WebAPI.ViewModels.Catalog.Colors
{
    public class GetColorPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }

        public int ColorId { get; set; }

    }
}
