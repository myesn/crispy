namespace Microsoft.Extensions.DependencyInjection
{
    using Crispy.Abstractions;
    using Crispy.EntityFramework;
    using JetBrains.Annotations;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class CrispyEntityFrameworkServiceCollectionExtensions
    {
        public static IServiceCollection AddCrispyEntityFrameworkMySQL(
            this IServiceCollection services,
            [NotNull]string connectionString,
            [NotNull]string migrationAssemblyName) =>
            services.AddDbContextPool<CrispyMySQLDbContext>(builder =>
                        builder.UseMySql(connectionString, options =>
                            options.MigrationsAssembly(migrationAssemblyName)))
                   .AddScoped<ICrispyStore, CrispyMySQLDbContext>();
    }
}
