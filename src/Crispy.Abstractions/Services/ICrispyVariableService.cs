namespace Crispy.Abstractions
{
    using JetBrains.Annotations;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICrispyVariableService
    {
        Task<IEnumerable<CrispyVariableResponse>> GetAllAsync(Guid? applicationId);
        Task<CrispyVariable> AddAsync([NotNull]CrispyVariableAddtionContext context);
        Task<CrispyVariable> UpdateAsync([NotNull]CrispyVariableUpdateContext context);
        Task EnableAsync([NotNull]Guid id, bool enabler);
        Task DeleteAsync([NotNull]Guid id);
    }
}