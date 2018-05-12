namespace Crispy.Abstractions
{
    using JetBrains.Annotations;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICrispyKeyValuePairService
    {
        IQueryable<CrispyKeyValuePair> Query();
        Task<IEnumerable<CrispyKeyValuePairResponse>> GetAllAsync([NotNull]Guid enviromentId);
        Task<CrispyKeyValuePair> AddAsync([NotNull]CrispyKeyValuePairAddtionContext context);
        Task<CrispyKeyValuePair> UpdateAsync([NotNull]CrispyKeyValuePairUpdateContext context);
        Task EnableAsync([NotNull]Guid id, [NotNull] bool enabler);
        Task DeleteAsync([NotNull]Guid id);
        Task<IEnumerable<CrispyKeyValuePairResponse>> GetHistoiesAsync([NotNull]Guid id);
    }
}
