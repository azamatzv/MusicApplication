using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Shared.Services.Impl;
using Core.Common;

namespace Infrastructure.Persistence;

public class DatabaseContext : IdentityDbContext<ApplicationUser>
{
    private readonly IClaimService _claimService;

    public DatabaseContext(DbContextOptions options, IClaimService claimService) : base(options)
    {
        _claimService = claimService;
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }

    //DbSets

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        foreach (var entry in ChangeTracker.Entries<IAuditedEntity>())
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = _claimService.GetUserId();
                    entry.Entity.CreatedOn = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedBy = _claimService.GetUserId();
                    entry.Entity.UpdatedOn = DateTime.Now;
                    break;
            }

        return await base.SaveChangesAsync(cancellationToken);
    }
}