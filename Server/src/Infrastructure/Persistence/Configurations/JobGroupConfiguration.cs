using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TSoft.TaskManagement.Domain.Entities.Jobs;

namespace TSoft.TaskManagement.Infrastructure.Persistence.Configurations;

public class JobGroupConfiguration : IEntityTypeConfiguration<JobGroup>
{
    public void Configure(EntityTypeBuilder<JobGroup> builder)
    {
        builder.HasMany<JobItemGroup>(e => e.JobItems)
            .WithOne(e => e.JobGroup)
            .HasForeignKey(e => e.JobGroupId);

        // builder
        //     .HasMany(jg => jg.JobItems)
        //     .WithOne(jig => jig.JobGroup)
        //     .HasForeignKey(jig => jig.JobGroupId);
        // .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(jg => jg.JobParent)
            .WithMany(jg => jg.GroupChildren)
            .HasForeignKey(jg => jg.JobParentId);
        // .OnDelete(DeleteBehavior.Restrict);
    }
}