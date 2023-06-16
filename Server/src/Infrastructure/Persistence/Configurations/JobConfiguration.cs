using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TSoft.TaskManagement.Domain.Entities.Attachments;
using TSoft.TaskManagement.Domain.Entities.Jobs;

namespace TSoft.TaskManagement.Infrastructure.Persistence.Configurations;

public class JobConfiguration : IEntityTypeConfiguration<Job>
{
    public void Configure(EntityTypeBuilder<Job> builder)
    {
        builder.HasMany<FileUpload>(atm => atm.Attachments)
            .WithOne(e => e.Job)
            .HasForeignKey(e => e.JobId);
        builder.HasMany<JobItemGroup>(e => e.JobItemGroups)
            .WithOne(e => e.JobItem)
            .HasForeignKey(e => e.JobItemId);
        builder.HasOne<JobCategory>(e => e.JobCategory)
            .WithMany(e => e.Jobs)
            .HasForeignKey(e => e.CategoryId);   
        builder.Property(e => e.Title).IsRequired();
        builder.Property(e => e.Budget)
            .HasColumnType("decimal(18, 2)")
            .IsRequired();


    }
}