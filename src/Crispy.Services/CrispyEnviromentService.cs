namespace Crispy.Services
{
    using Crispy.Abstractions;
    using JetBrains.Annotations;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CrispyEnviromentService : ICrispyEnviromentService
    {
        public CrispyEnviromentService(ICrispyStore store)
        {
            Store = store;
        }
        protected ICrispyStore Store { get; }

        public async Task<CrispyEnvironment> AddAsync([NotNull] CrispyEnvironmentAddtionContext context)
        {
            if (await Query().AnyAsync(x => x.ApplicatoinId == context.ApplicationId && x.Name == context.Name))
                throw new ArgumentException($"应用环境名称 {context.Name} 已存在");

            var environment = new CrispyEnvironment(context.ApplicationId, context.Name, CrispyEnviromentType.Extension);
            Store.Environments.Add(environment);

            await SaveChangesAsync();

            return environment;
        }

        public async Task DeleteAsync([NotNull] Guid id)
        {
            var environment = await FindAsync(id);
            if (environment == null)
                return;

            environment.Enabler = false;
            environment.Deleted = true;
            Store.Environments.Update(environment);

            await SaveChangesAsync();
        }

        public async Task EnableAsync([NotNull] Guid id, bool enabler)
        {
            var environment = await FindAndValidAsync(id);

            if (environment.Enabler == enabler)
                return;

            environment.Enabler = enabler;
            Store.Environments.Update(environment);

            await SaveChangesAsync();
        }

        public async Task EncryptAsync([NotNull] Guid id, bool encryption)
        {
            var environment = await FindAndValidAsync(id);

            if (environment.Encryption == encryption)
                return;

            environment.Encryption = encryption;
            Store.Environments.Update(environment);

            await SaveChangesAsync();
        }

        public async Task<CrispyEnvironmentInfoResponse> GetInfoAsync([NotNull] Guid id)
        {
            var environment = await FindAndValidAsync(id);

            var response = new CrispyEnvironmentInfoResponse(environment);

            return response;
        }

        public async Task IncludeGlobalConfigAsync([NotNull] Guid id, bool include)
        {
            var environment = await FindAndValidAsync(id);

            if (environment.IncludeGlobalConfig == include)
                return;

            environment.IncludeGlobalConfig = include;
            Store.Environments.Update(environment);

            await SaveChangesAsync();
        }

        public async Task<CrispyEnvironment> UpdateAsync([NotNull] CrispyEnvironmentUpdateContext context)
        {
            var environment = await FindAndValidAsync(context.Id);

            if (environment.Name == context.Name)
                return environment; ;

            environment.Name = context.Name;
            Store.Environments.Update(environment);

            await SaveChangesAsync();

            return environment;
        }

        private IQueryable<CrispyEnvironment> Query() =>
            Store.Environments.Where(x => !x.Deleted);

        private Task<CrispyEnvironment> FindAsync(Guid id) =>
             Query().FirstOrDefaultAsync(x => x.Id == id);

        private async Task<CrispyEnvironment> FindAndValidAsync(Guid id)
        {
            var environment = await FindAsync(id);

            return environment ?? throw new KeyNotFoundException($"未找到 Id 为 {id} 的应用环境");
        }

        private async Task<int> SaveChangesAsync() =>
            await Store.SaveChangesAsync();

    }
}
