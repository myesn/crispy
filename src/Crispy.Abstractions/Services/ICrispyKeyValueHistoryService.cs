namespace Crispy.Abstractions
{
    using JetBrains.Annotations;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICrispyKeyValueHistoryService
    {
        IQueryable<CrispyKeyValuePairHistory> Query();
        Task<CrispyKeyValuePairHistory> AddtionAsync([NotNull]CrispyKeyValuePairHistoryAddtionContext context);
    }
}
