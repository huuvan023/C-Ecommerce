using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Data.Entities;

namespace WebAPI.Data.Configuration
{
    class ProductBrandConfiguration : IEntityTypeConfiguration<productBrand>
    {
        public void Configure(EntityTypeBuilder<productBrand> builder)
        {
            builder.ToTable("ProductBrands");

            builder.HasKey(x => x.idBrand);

            builder.HasOne(x => x.Language).WithMany(x => x.productBrands).HasForeignKey(x => x.LanguageId);
        }
    }
}
