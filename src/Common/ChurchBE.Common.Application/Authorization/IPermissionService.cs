using ChurchBE.Common.Domain;

namespace ChurchBE.Common.Application.Authorization;
public interface IPermissionService
{
    Task<Result<PermissionsResponse>> GetUserPermissionsAsync(string identityId);
}

