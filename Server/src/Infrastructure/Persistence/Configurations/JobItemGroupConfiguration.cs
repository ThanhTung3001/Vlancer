using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TSoft.TaskManagement.Domain.Entities.Jobs;

namespace TSoft.TaskManagement.Infrastructure.Persistence.Configurations;

public class JobItemGroupConfiguration : IEntityTypeConfiguration<JobItemGroup>
{
    public void Configure(EntityTypeBuilder<JobItemGroup> builder)
    {
        builder.HasKey(e => new { e.JobGroupId, e.JobItemId });
    }
}