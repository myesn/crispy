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

    public class CrispyVariableService : ICrispyVariableService
    {
        public CrispyVariableService(ICrispyStore store)
        {
            Store = store;
        }
        protected ICrispyStore Store { get; }

        public async Task<IEnumerable<CrispyVariableResponse>> GetAllAsync(Guid? applicationId) =>
             await Query()
                .Where(x => x.ApplicationId == applicationId)
                .Select(x => new CrispyVariableResponse
                {
                    Id = x.Id,
                    Key = x.Key,
                    Value = x.Value,
                    Enabler = x.Enabler
                }).ToListAsync() ?? new List<CrispyVariableResponse>();

        public async Task<CrispyVariable> AddAsync([NotNull]CrispyVariableAddtionContext context)
        {
            if (await Query().AnyAsync(x => x.ApplicationId == context.ApplicationId && x.Key == context.Key))
                throw new ArgumentException($"{ (context.ApplicationId == null ? "全局配置" : "当前环境")}已存在 Key 为 {context.Key} 的配置项");

            var variable = new CrispyVariable(context.ApplicationId, context.Key, context.Value);
            Store.Variables.Add(variable);

            await SaveChangesAsync();

            return variable;
        }

        public async Task<CrispyVariable> UpdateAsync([NotNull]CrispyVariableUpdateContext context)
        {
            var variable = await FindAndValidAsync(context.Id);

            if (variable.Value == context.Value)
                return variable;

            variable.Value = context.Value;
            Store.Variables.Update(variable);

            await SaveChangesAsync();

            return variable;
        }

        public async Task EnableAsync([NotNull]Guid id, bool enabler)
        {
            var variable = await FindAndValidAsync(id);

            if (variable.Enabler == enabler)
                return;

            variable.Enabler = enabler;
            Store.Variables.Update(variable);

            await SaveChangesAsync();
        }

        public async Task DeleteAsync([NotNull]Guid id)
        {
            var variable = await FindAsync(id);
            if (variable == null || variable.Deleted)
                return;

            variable.Enabler = false;
            variable.Deleted = true;
            Store.Variables.Update(variable);

            await SaveChangesAsync();
        }

        private IQueryable<CrispyVariable> Query() =>
            Store.Variables.Where(x => !x.Deleted);

        private Task<CrispyVariable> FindAsync(Guid id) =>
             Query().FirstOrDefaultAsync(x => x.Id == id);

        private async Task<CrispyVariable> FindAndValidAsync(Guid id)
        {
            var pair = await FindAsync(id);

            return pair ?? throw new KeyNotFoundException($"未找到 Id 为 {id} 的变量");
        }

        private async Task<int> SaveChangesAsync() =>
            await Store.SaveChangesAsync();

    }
}