using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VueCrudSolution.Data.Models.Map
{
    public class ApplicationIdentityUserLoginMap : IEntityTypeConfiguration<ApplicationIdentityUserLogin>
    {
        public void Configure(EntityTypeBuilder<ApplicationIdentityUserLogin> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.HasKey(u => new { u.LoginProvider, u.ProviderKey });

        }
    }
}
