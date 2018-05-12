namespace Crispy.Abstractions
{
    using JetBrains.Annotations;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICrispyProjectService
    {
        Task<CrispyPageResponse<CrispyProjectPageResponse>> PageAsync([NotNull]CryspyPageContext context);
        Task<CrispyProjectInfoResponse> GetInfoAsync([NotNull]Guid id);
        Task<CrispyProject> CreateAsync([NotNull]CrispyProjectCreationContext context);
        Task<CrispyProject> UpdateAsync([NotNull]CrispyProjectUpdateContext context);
        Task IncludeGlobalConfigAsync(Guid id, bool include);
        Task EncryptAsync(Guid id, bool encryption);
        Task EnableAsync(Guid id, bool enabler);
        Task DeleteAsync(Guid id);
    }
}
