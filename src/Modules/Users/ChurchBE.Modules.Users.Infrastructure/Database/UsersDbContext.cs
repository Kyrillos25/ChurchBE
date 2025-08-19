using ChurchBE.Common.Infrastructure.Inbox;
using ChurchBE.Common.Infrastructure.Outbox;
using ChurchBE.Modules.Users.Application.Abstractions.Data;
using ChurchBE.Modules.Users.Domain.Invitations;
using ChurchBE.Modules.Users.Domain.Users;
using ChurchBE.Modules.Users.Infrastructure.Invitations;
using ChurchBE.Modules.Users.Infrastructure.Users;
using Microsoft.EntityFrameworkCore;

namespace ChurchBE.Modules.Users.Infrastructure.Database;
public sealed class UsersDbContext(DbContextOptions<UsersDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<User> Users { get; set; }
    internal DbSet<Invitation> Invitations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Users);

        modelBuilder.ApplyConfiguration(new OutboxMessageConfiguration());
        modelBuilder.ApplyConfiguration(new OutboxMessageConsumerConfiguration());
        modelBuilder.ApplyConfiguration(new InboxMessageConfiguration());
        modelBuilder.ApplyConfiguration(new InboxMessageConsumerConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new InvitationConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new PermissionConfiguration());
    }
}
