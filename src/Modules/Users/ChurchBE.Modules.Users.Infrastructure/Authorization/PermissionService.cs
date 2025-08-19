using ChurchBE.Common.Application.Authorization;
using ChurchBE.Common.Domain;
using ChurchBE.Modules.Users.Application.Users.GetUserPermissions;
using MediatR;

namespace ChurchBE.Modules.Users.Infrastructure.Authorization;
internal sealed class PermissionService(ISender sender) : IPermissionService
{
    public async Task<Result<PermissionsResponse>> GetUserPermissionsAsync(string identityId)
    {
        return await sender.Send(new GetUserPermissionsQuery(identityId));
    }
}