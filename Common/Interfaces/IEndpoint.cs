using Microsoft.AspNetCore.Routing;

namespace Common.Interfaces;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}