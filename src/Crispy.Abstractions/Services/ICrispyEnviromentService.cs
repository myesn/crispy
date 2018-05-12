namespace Crispy.Abstractions
{
    using JetBrains.Annotations;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICrispyEnviromentService
    {
        IQueryable<CrispyEnvironment> Query();
        Task<CrispyEnviromentInfoResponse> GetInfoAsync([NotNull]Guid id);
        Task<CrispyEnvironment> AddAsync([NotNull]CrispyEnviromentAddtionContext context);
        Task<CrispyEnvironment> UpdateAsync([NotNull]CrispyEnviromentUpdateContext context);
        Task IncludeGlobalConfigAsync(Guid id, bool include);
        Task EncryptAsync(Guid id, bool encryption);
        Task EnableAsync(Guid id, bool enabler);
        Task DeleteAsync(Guid id);
    }
}
