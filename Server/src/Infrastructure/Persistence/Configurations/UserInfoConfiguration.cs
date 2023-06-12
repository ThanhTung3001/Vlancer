using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TSoft.TaskManagement.Domain.Entities.User;

namespace TSoft.TaskManagement.Infrastructure.Persistence
{
    public class UserInfoConfiguration : IEntityTypeConfiguration<UserInfo>
    {
        public void Configure(EntityTypeBuilder<UserInfo> builder)
        {
            builder.HasMany<UserSkill>(e => e.UserSkills)
            .WithOne(e => e.UserInfo).HasForeignKey(e => e.UserId);
        }
    }
}