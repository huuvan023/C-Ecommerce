using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.ViewModels.Catalog.Categories
{
    public class CategoryVm
    {
        public int Id { get; set; }
        public string Name { set; get; }

        public int? ParentId { get; set; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public string LanguageId { set; get; }
        public string SeoAlias { set; get; }

    }
}
