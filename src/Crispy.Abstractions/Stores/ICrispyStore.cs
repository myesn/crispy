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
        DbSet<CrispyApplication> Applications { get; set; }
        DbSet<CrispyEnvironment> Environments { get; set; }
        DbSet<CrispyKeyValuePair> KeyValuePairs { get; set; }
        DbSet<CrispyKeyValuePairHistory> KeyValuePairHistories { get; set; }

        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken));
        
    }
}
