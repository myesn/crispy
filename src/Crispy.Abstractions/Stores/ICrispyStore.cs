namespace Crispy.Abstractions
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ICrispyStore
    {
        DbSet<CrispyProject> Projects { get; set; }
        DbSet<CrispyEnvironment> Enviroments { get; set; }
        DbSet<CrispyKeyValuePair> KeyValuePairs { get; set; }
        DbSet<CrispyKeyValuePairHistory> KeyValuePairHistories { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
