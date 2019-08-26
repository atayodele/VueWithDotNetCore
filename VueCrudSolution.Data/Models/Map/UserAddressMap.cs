using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VueCrudSolution.Data.Models.Map
{
    public class UserAddressMap : BaseEntityTypeConfiguration<UserAddress>
    {
        public override void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            base.Configure(builder);
            builder.HasOne(t => t.Login).WithMany().HasForeignKey(t => t.Login_Id)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
