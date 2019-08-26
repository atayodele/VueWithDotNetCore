using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VueCrudSolution.Data.Models.Map
{
    public abstract class BaseEntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasOne(m => m.CreatedBy).WithMany().HasForeignKey(m => m.CreatedBy_Id)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(m => m.ModifiedBy).WithMany().HasForeignKey(m => m.ModifiedBy_Id)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(m => m.IsDeleted == false);
        }
    }
}
