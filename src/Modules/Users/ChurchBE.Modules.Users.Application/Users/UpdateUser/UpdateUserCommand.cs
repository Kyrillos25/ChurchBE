using ChurchBE.Common.Application.Messaging;

namespace ChurchBE.Modules.Users.Application.Users.UpdateUser;
public sealed record UpdateUserCommand(Guid UserId, string FirstName, string LastName) : ICommand;
