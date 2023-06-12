

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TSoft.TaskManagement.Domain.Entities.User;

namespace TSoft.TaskManagement.Infrastructure.Persistence
{
    public class UserSkillConfiguration : IEntityTypeConfiguration<UserSkill>
    {
        public void Configure(EntityTypeBuilder<UserSkill> builder)
        {
            builder.HasKey(e => new { e.UserId, e.SkillId });
        }
    }
}