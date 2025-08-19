using ChurchBE.Common.Application.Authorization;
using ChurchBE.Common.Application.Messaging;

namespace ChurchBE.Modules.Users.Application.Users.GetUserPermissions;
public sealed record GetUserPermissionsQuery(string IdentityId) : IQuery<PermissionsResponse>;
