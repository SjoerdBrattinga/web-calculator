using Microsoft.AspNetCore.Mvc;

namespace WebCalculator;

public static class EndpointConventionBuilderExtensions
{
    public static void ProducesBadRequest(this IEndpointConventionBuilder builder)
    {
        builder.WithMetadata(new ProducesResponseTypeAttribute(typeof(void), 400));
    }
}