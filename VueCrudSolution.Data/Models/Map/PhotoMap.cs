using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace VueCrudSolution.Data.Models.Map
{
    public class PhotoMap : BaseEntityTypeConfiguration<Photo>
    {
        public override void Configure(EntityTypeBuilder<Photo> builder)
        {
            base.Configure(builder);
            builder.Property(t => t.Url).HasMaxLength(255).IsUnicode(false);
            builder.HasOne(t => t.Login).WithMany().HasForeignKey(t => t.Login_Id)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
