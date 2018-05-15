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
        public static IServiceCollection AddCrispyEntityFrameworkInMemory(this IServiceCollection services) =>
            services
                .AddDbContextPool<CrispyDbContext>(builder =>
                    builder.UseInMemoryDatabase(databaseName: "cripsy_memory_database"))
                .AddScoped<ICrispyStore, CrispyDbContext>();

        public static IServiceCollection AddCrispyEntityFrameworkMySQL(
            this IServiceCollection services,
            [NotNull]string connectionString,
            [NotNull]string migrationAssemblyName) =>
            services.AddDbContextPool<CrispyDbContext>(builder =>
                builder.UseMySql(connectionString, options =>
                    options.MigrationsAssembly(migrationAssemblyName)))
           .AddScoped<ICrispyStore, CrispyDbContext>();

        public static IServiceCollection AddCrispyEntityFrameworkSqlServer(
            this IServiceCollection services,
            [NotNull]string connectionString,
            [NotNull]string migrationAssemblyName) =>
            services.AddDbContextPool<CrispyDbContext>(builder =>
                builder.UseSqlServer(connectionString, options =>
                    options.MigrationsAssembly(migrationAssemblyName)))
           .AddScoped<ICrispyStore, CrispyDbContext>();

    }
}
