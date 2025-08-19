using Microsoft.AspNetCore.Routing;

namespace ChurchBE.Common.Presentation.Endpoints;
public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}
