using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Data.Entities;

namespace WebAPI.Data.Configuration
{
    public class ProductSizeConfiguration : IEntityTypeConfiguration<productSize>
    {
        public void Configure(EntityTypeBuilder<productSize> builder)
        {
            builder.ToTable("ProductSizes");

            builder.HasKey(x => x.idSize);

            builder.HasOne(x => x.Language).WithMany(x => x.ProductSizes).HasForeignKey(x => x.LanguageId);
        }
    }
}
