using ChurchBE.Modules.Users.Domain.Invitations;
using ChurchBE.Modules.Users.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace ChurchBE.Modules.Users.Infrastructure.Invitations;
internal sealed class InvitationRepository(UsersDbContext context) : IInvitationRepository
{
    public async Task<Invitation?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Invitations.SingleOrDefaultAsync(u => u.Id == id, cancellationToken);
    }

    public void Insert(Invitation invitation)
    {
        context.Invitations.Add(invitation);
    }
}

