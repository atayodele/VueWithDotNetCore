using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace VueCrudSolution.Data.Models.Map
{
    public class ApplicationIdentityUserTokenMap : IEntityTypeConfiguration<ApplicationIdentityUserToken>
    {
        public void Configure(EntityTypeBuilder<ApplicationIdentityUserToken> builder)
        {
            builder.HasKey(p => p.UserId);
        }
    }
}
