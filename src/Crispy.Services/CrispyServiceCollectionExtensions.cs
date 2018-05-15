namespace Microsoft.Extensions.DependencyInjection
{
    using Crispy.Abstractions;
    using Crispy.Services;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class CrispyServiceCollectionExtensions
    {
        public static IServiceCollection AddCrispyServices(this IServiceCollection services) =>
            services
            .AddScoped<ICrispyApplicationService, CrispyApplicationService>()
            .AddScoped<ICrispyVariableService, CrispyVariableService>()
            .AddScoped<ICrispyEnviromentService, CrispyEnviromentService>()
            .AddScoped<ICrispyKeyValuePairService, CrispyKeyValuePairService>();
    }
}
