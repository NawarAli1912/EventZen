using Microsoft.AspNetCore.Routing;

namespace EventZen.Shared.Presentation;
public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}
