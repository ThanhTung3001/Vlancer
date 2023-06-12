using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TSoft.TaskManagement.Domain.Entities.User;

namespace TSoft.TaskManagement.Infrastructure.Persistence
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.HasMany<UserSkill>
            (e => e.GroupUserSkills)
            .WithOne(e => e.Skill)
            .HasForeignKey(e => e.SkillId);
        }
    }
}