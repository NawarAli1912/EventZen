﻿using EventZen.Modules.Events.Api;
using EventZen.Modules.Events.Application.Categories.ArchiveCategory;
using EventZen.Modules.Events.Presentation.ApiResults;
using EventZen.Shared.Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace EventZen.Modules.Events.Presentation.Categories;
internal static class ArchiveCategory
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("categories/{id}/archive", async (Guid id, ISender sender) =>
        {
            Result result = await sender.Send(new ArchiveCategoryCommand(id));

            return result.Match(() => Results.Ok(), ApiResults.ApiResults.Problem);
        })
            .WithTags(Tags.Categories);
    }
}
