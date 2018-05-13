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
        Task<IEnumerable<CrispyKeyValuePairResponse>> GetAllAsync([NotNull]Guid? environmentId);
        Task<IEnumerable<CrispyKeyValuePairHistoryResponse>> GetHistoiesAsync([NotNull]Guid id);
        Task<CrispyKeyValuePair> AddAsync([NotNull]CrispyKeyValuePairAddtionContext context);
        Task<CrispyKeyValuePair> UpdateAsync([NotNull]CrispyKeyValuePairUpdateContext context);
        Task EnableAsync([NotNull]Guid id, bool enabler);
        Task DeleteAsync([NotNull]Guid id);
    }
}
