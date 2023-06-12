using System.Reflection;
using TSoft.TaskManagement.Application.Common.Interfaces;
using TSoft.TaskManagement.Domain.Entities;
using TSoft.TaskManagement.Infrastructure.Identity;
using TSoft.TaskManagement.Infrastructure.Persistence.Interceptors;
using Duende.IdentityServer.EntityFramework.Options;
using MediatR;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TSoft.TaskManagement.Domain.Entities.Attachments;
using TSoft.TaskManagement.Domain.Entities.Jobs;
using TSoft.TaskManagement.Domain.Entities.User;

namespace TSoft.TaskManagement.Infrastructure.Persistence;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
{
    private readonly IMediator _mediator;
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IOptions<OperationalStoreOptions> operationalStoreOptions,
        IMediator mediator,
        AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
        : base(options, operationalStoreOptions)
    {
        _mediator = mediator;
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }

    public DbSet<TodoList> TodoLists => Set<TodoList>();
    public DbSet<TodoItem> TodoItems => Set<TodoItem>();

    public DbSet<Job> Jobs => Set<Job>();

    public DbSet<JobGroup> JobGroups => Set<JobGroup>();

    public DbSet<UserSkill> UserSkills => Set<UserSkill>();

    public DbSet<JobItemGroup> JobItemGroups => Set<JobItemGroup>();

    public DbSet<Attachment> Attachments => Set<Attachment>();

    public DbSet<Skill> Skills => Set<Skill>();

    public DbSet<UserInfo> UserInfos => Set<UserInfo>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEvents(this);

        return await base.SaveChangesAsync(cancellationToken);
    }
}