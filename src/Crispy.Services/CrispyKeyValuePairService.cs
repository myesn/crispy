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

    public class CrispyKeyValuePairService : ICrispyKeyValuePairService
    {
        public CrispyKeyValuePairService(ICrispyStore store)
        {
            Store = store;
        }
        protected ICrispyStore Store { get; }

        public async Task<CrispyKeyValuePair> AddAsync([NotNull] CrispyKeyValuePairAddtionContext context)
        {
            if (await Query().AnyAsync(x => x.EnvironmentId == context.EnvironmentId && x.Key == context.Key))
                throw new ArgumentException($"{ (context.EnvironmentId == null ? "全局配置" : "当前环境")}已存在 Key 为 {context.Key} 的配置项");

            var pair = new CrispyKeyValuePair
            {
                EnvironmentId = context.EnvironmentId,
                Key = context.Key,
                Value = context.Value,
                ValueType = context.ValueType,
                Description = context.Description
            };
            Store.KeyValuePairs.Add(pair);
            Store.KeyValuePairHistories.Add(new CrispyKeyValuePairHistory(pair.Id, pair.Value, pair.ValueType));

            await SaveChangesAsync();

            return pair;
        }

        public async Task DeleteAsync([NotNull] Guid id)
        {
            var pair = await FindAsync(id);
            if (pair == null)
                return;

            pair.Enabler = false;
            pair.Deleted = true;
            Store.KeyValuePairs.Update(pair);

            await SaveChangesAsync();
        }

        public async Task EnableAsync([NotNull] Guid id, bool enabler)
        {
            var pair = await FindAndValidAsync(id);

            if (pair.Enabler == enabler)
                return;

            pair.Enabler = enabler;
            Store.KeyValuePairs.Update(pair);

            await SaveChangesAsync();
        }

        public async Task<IEnumerable<CrispyKeyValuePairResponse>> GetAllAsync(Guid? environmentId) =>
             await Query()
                .Where(x => x.EnvironmentId == environmentId)
                .Select(x => new CrispyKeyValuePairResponse
                {
                    Id = x.Id,
                    Key = x.Key,
                    Value = x.Value,
                    ValueType = x.ValueType,
                    Description = x.Description,
                    Enabler = x.Enabler,
                    Timestamp = x.Timestamp
                }).ToListAsync() ?? new List<CrispyKeyValuePairResponse>();


        public async Task<IEnumerable<CrispyKeyValuePairHistoryResponse>> GetHistoiesAsync([NotNull] Guid id) =>
             await Store.KeyValuePairHistories
                .Where(x => x.KeyValuePairId == id)
                .OrderByDescending(x => x.DateTimeCreated)
                .Select(x => new CrispyKeyValuePairHistoryResponse(x.Value, x.ValueType, x.DateTimeCreated))
                .ToListAsync() ?? new List<CrispyKeyValuePairHistoryResponse>();

        public async Task<CrispyKeyValuePair> UpdateAsync([NotNull] CrispyKeyValuePairUpdateContext context)
        {
            var pair = await FindAndValidAsync(context.Id);

            if (pair.Value != context.Value || pair.ValueType != context.ValueType)
                Store.KeyValuePairHistories.Add(new CrispyKeyValuePairHistory(pair.Id, context.Value, context.ValueType));

            if (pair.Value != context.Value)
                pair.Value = context.Value;

            if (pair.ValueType == context.ValueType)
                pair.ValueType = context.ValueType;

            if (pair.Description != context.Description)
                pair.Description = context.Description;

            Store.KeyValuePairs.Update(pair);

            await SaveChangesAsync();

            return pair;
        }

        private IQueryable<CrispyKeyValuePair> Query() =>
            Store.KeyValuePairs.Where(x => !x.Deleted);

        private Task<CrispyKeyValuePair> FindAsync(Guid id) =>
             Query().FirstOrDefaultAsync(x => x.Id == id);

        private async Task<CrispyKeyValuePair> FindAndValidAsync(Guid id)
        {
            var pair = await FindAsync(id);

            return pair ?? throw new KeyNotFoundException($"未找到 Id 为 {id} 的应用环境");
        }

        private async Task<int> SaveChangesAsync() =>
            await Store.SaveChangesAsync();

    }
}
