using TSoft.TaskManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using TSoft.TaskManagement.Domain.Entities.Attachments;
using TSoft.TaskManagement.Domain.Entities.Jobs;
using TSoft.TaskManagement.Domain.Entities.User;

namespace TSoft.TaskManagement.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<Job> Jobs { get; }

    DbSet<JobGroup> JobGroups { get; }

    DbSet<UserSkill> UserSkills { get; }

    DbSet<Skill> Skills { get; }

    DbSet<JobItemGroup> JobItemGroups { get; }

    DbSet<Job> Attachments { get; }

    DbSet<UserInfo> UserInfos { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}