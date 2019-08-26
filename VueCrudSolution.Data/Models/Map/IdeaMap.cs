using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace VueCrudSolution.Data.Models.Map
{
    public class IdeaMap : BaseEntityTypeConfiguration<Idea>
    {
        public override void Configure(EntityTypeBuilder<Idea> builder)
        {
            base.Configure(builder);
            builder.Property(t => t.Title).HasMaxLength(150).IsUnicode(false);
            builder.Property(t => t.Description).HasMaxLength(255).IsUnicode(false);
            builder.Property(t => t.FilePath).HasMaxLength(255).IsUnicode(false);
            builder.HasOne(t => t.Login).WithMany().HasForeignKey(t => t.Login_Id)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
