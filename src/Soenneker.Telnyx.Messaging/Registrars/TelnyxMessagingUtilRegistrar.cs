using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Telnyx.ClientUtil.Registrars;
using Soenneker.Telnyx.Messaging.Abstract;

namespace Soenneker.Telnyx.Messaging.Registrars;

/// <summary>
/// A resilient .NET utility for Telnyx Messaging.
/// </summary>
public static class TelnyxMessagingUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="ITelnyxMessagingUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddTelnyxMessagingUtilAsSingleton(this IServiceCollection services)
    {
        services.AddTelnyxClientUtilAsSingleton().TryAddSingleton<ITelnyxMessagingUtil, TelnyxMessagingUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="ITelnyxMessagingUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddTelnyxMessagingUtilAsScoped(this IServiceCollection services)
    {
        services.AddTelnyxClientUtilAsSingleton().TryAddScoped<ITelnyxMessagingUtil, TelnyxMessagingUtil>();

        return services;
    }
}
