using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Data.Entities;

namespace WebAPI.Data.Configuration
{
    class productColorConfiguration : IEntityTypeConfiguration<productColor>
    {
        public void Configure(EntityTypeBuilder<productColor> builder)
        {
            builder.ToTable("ProductColors");

            builder.HasKey(x => x.idColor);

            builder.HasOne(x => x.Language).WithMany(x => x.productColors).HasForeignKey(x => x.LanguageId);
        }
    }
}
