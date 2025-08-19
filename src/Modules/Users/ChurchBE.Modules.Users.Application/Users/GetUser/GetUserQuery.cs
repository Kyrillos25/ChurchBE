using ChurchBE.Common.Application.Messaging;

namespace ChurchBE.Modules.Users.Application.Users.GetUser;
public sealed record GetUserQuery(Guid UserId) : IQuery<UserResponse>;
