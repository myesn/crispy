namespace Crispy.Abstractions
{
    using JetBrains.Annotations;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICrispyApplicationService
    {
        Task<CrispyPageResponse<CrispyApplicationPageResponse>> PageAsync([NotNull]CryspyPageContext context);
        Task<CrispyApplicationInfoResponse> GetInfoAsync([NotNull]Guid id);
        Task<CrispyApplication> CreateAsync([NotNull]CrispyApplicationCreationContext context);
        Task<CrispyApplication> UpdateAsync([NotNull]CrispyApplicationUpdateContext context);
        Task IncludeGlobalConfigAsync([NotNull]Guid id, bool include);
        Task EncryptAsync([NotNull]Guid id, bool encryption);
        Task EnableAsync([NotNull]Guid id, bool enabler);
        Task DeleteAsync([NotNull]Guid id);
    }
}
