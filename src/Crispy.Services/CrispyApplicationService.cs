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

    public class CrispyApplicationService : ICrispyApplicationService
    {
        public CrispyApplicationService(ICrispyStore store)
        {
            Store = store;
        }
        protected ICrispyStore Store { get; }

        public async Task<CrispyApplication> CreateAsync([NotNull] CrispyApplicationCreationContext context)
        {
            if (await Query().AnyAsync(x => x.Name == context.Name))
                throw new ArgumentException($"应用名 {context.Name} 已存在");

            var application = new CrispyApplication(context.Name);
            Store.Applications.Add(application);
            Store.Environments.Add(new CrispyEnvironment(application.Id, "基础环境"));

            await SaveChangesAsync();

            return application;
        }

        public async Task DeleteAsync([NotNull] Guid id)
        {
            var application = await FindAsync(id);
            if (application == null || application.Deleted)
                return;

            application.Enabler = false;
            application.Deleted = true;
            Store.Applications.Update(application);

            await SaveChangesAsync();
        }

        public async Task EnableAsync([NotNull] Guid id, bool enabler)
        {
            var application = await FindAndValidAsync(id);

            if (application.Enabler == enabler)
                return;

            application.Enabler = enabler;
            Store.Applications.Update(application);

            await SaveChangesAsync();
        }

        public async Task EncryptAsync([NotNull] Guid id, bool encryption)
        {
            var application = await FindAndValidAsync(id);

            if (application.Encryption == encryption)
                return;

            application.Encryption = encryption;
            Store.Applications.Update(application);

            await SaveChangesAsync();
        }

        public async Task<CrispyApplicationInfoResponse> GetInfoAsync([NotNull] Guid id)
        {
            var application = await FindAndValidAsync(id);
            var response = new CrispyApplicationInfoResponse(application);
            var environments = await Store.Environments.Where(x => x.ApplicatoinId == id).Select(x => new { x.Id, x.Name }).ToListAsync();
            if (environments == null || !environments.Any())
                return response;

            response.Environments = environments.Select(x => new Tuple<Guid, string>(x.Id, x.Name));

            return response;
        }

        public async Task IncludeGlobalConfigAsync([NotNull] Guid id, bool include)
        {
            var application = await FindAndValidAsync(id);

            if (application.IncludeGlobalConfig == include)
                return;

            application.IncludeGlobalConfig = include;
            Store.Applications.Update(application);

            await SaveChangesAsync();
        }

        public async Task<CrispyPageResponse<CrispyApplicationPageResponse>> PageAsync([NotNull] CryspyPageContext context)
        {
            var response = new CrispyPageResponse<CrispyApplicationPageResponse>()
            { PageIndex = context.PageIndex, PageSize = context.PageSize };

            var total = await Query().CountAsync();
            response.Total = total;

            if (total == 0)
                return response;

            response.Data = await Query().Page(context)
                 .OrderBy(x => x.DateTimeCreated)
                 .Select(x => new CrispyApplicationPageResponse(x.Id, x.Name))
                 .ToListAsync() ?? new List<CrispyApplicationPageResponse>();

            return response;
        }

        public async Task<CrispyApplication> UpdateAsync([NotNull] CrispyApplicationUpdateContext context)
        {
            var application = await FindAndValidAsync(context.Id);

            if (application.Name == context.Name)
                return application;

            application.Name = context.Name;
            Store.Applications.Update(application);

            await SaveChangesAsync();

            return application;
        }

        private IQueryable<CrispyApplication> Query() =>
            Store.Applications.Where(x => !x.Deleted);

        private Task<CrispyApplication> FindAsync(Guid id) =>
             Query().FirstOrDefaultAsync(x => x.Id == id);

        private async Task<CrispyApplication> FindAndValidAsync(Guid id)
        {
            var application = await FindAsync(id);

            return application ?? throw new KeyNotFoundException($"未找到 Id 为 {id} 的应用");
        }

        private async Task<int> SaveChangesAsync() =>
            await Store.SaveChangesAsync();
    }
}
