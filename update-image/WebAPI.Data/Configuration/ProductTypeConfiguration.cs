using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Data.Entities;

namespace WebAPI.Data.Configuration
{
    class ProductTypeConfiguration : IEntityTypeConfiguration<productTypes>
    {
        public void Configure(EntityTypeBuilder<productTypes> builder)
        {
            builder.ToTable("ProductTypes");

            builder.HasKey(x => x.idType);

            builder.HasOne(x => x.Language).WithMany(x => x.productTypes).HasForeignKey(x => x.LanguageId);
        }
    }
}
