using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebAPI.Data.Entities
{
    [Table("Languages")]
    public class Language
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public bool IsDefault { get; set; }

        public List<productDetail> productDetails { get; set; }

        public List<Category> Categories { get; set; }

        public List<CategoryTranslation> CategoryTranslations { get; set; }

        public List<productSize> ProductSizes { get; set; }
        public List<productBrand> productBrands { get; set; }
        public List<productColor> productColors { get; set; }
        public List<productTypes> productTypes { get; set; }

    }
}
