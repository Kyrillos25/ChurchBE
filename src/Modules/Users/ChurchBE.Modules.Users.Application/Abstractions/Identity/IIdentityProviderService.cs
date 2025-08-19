using ChurchBE.Common.Domain;

namespace ChurchBE.Modules.Users.Application.Abstractions.Identity;
public interface IIdentityProviderService
{
    Task<Result<string>> RegisterUserAsync(UserModel user, CancellationToken cancellationToken = default);
}
