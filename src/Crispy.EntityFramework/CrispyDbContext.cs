namespace Crispy.EntityFramework
{
    using Crispy.Abstractions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using JetBrains.Annotations;
    using ModelRules = Crispy.Abstractions.CrispyConstants.ModelRules;
    using Microsoft.EntityFrameworkCore.Metadata;
    using System.Threading.Tasks;
    using EntityFrameworkCore.Triggers;
    using System.Threading;

    public class CrispyDbContext : DbContext, ICrispyStore
    {
        public CrispyDbContext([NotNull]DbContextOptions options) : base(options)
        { }

        public DbSet<CrispyApplication> Applications { get; set; }
        public DbSet<CrispyVariable> Variables { get; set; }
        public DbSet<CrispyEnvironment> Environments { get; set; }
        public DbSet<CrispyKeyValuePair> KeyValuePairs { get; set; }
        public DbSet<CrispyKeyValuePairHistory> KeyValuePairHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CrispyApplication>(application =>
            {
                application.HasKey(x => x.Id);

                application.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
                application.Property(x => x.Name).HasMaxLength(ModelRules.Application.NameMaxLength).IsRequired();

                application.HasMany(x => x.Enviroments).WithOne(x => x.Application).HasForeignKey(x => x.ApplicatoinId).OnDelete(DeleteBehavior.SetNull).IsRequired();
                application.HasMany(x => x.Variables).WithOne(x => x.Application).HasForeignKey(x => x.ApplicationId).OnDelete(DeleteBehavior.SetNull).IsRequired(false);
            });

            modelBuilder.Entity<CrispyVariable>(variable =>
            {
                variable.HasKey(x => x.Id);

                variable.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
                variable.Property(x => x.Key).HasMaxLength(ModelRules.Variable.KeyMaxLength).IsRequired();
                variable.Property(x => x.Value).HasMaxLength(ModelRules.Variable.ValueMaxLength).IsRequired();
            });            

            modelBuilder.Entity<CrispyEnvironment>(environment =>
            {
                environment.HasKey(x => x.Id);

                environment.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
                environment.Property(x => x.Name).HasMaxLength(ModelRules.Environment.NameMaxLength).IsRequired();
                //environment.Property(x => x.Type).HasConversion<string>();
            });

            modelBuilder.Entity<CrispyKeyValuePair>(pair =>
            {
                pair.HasKey(x => x.Id);

                pair.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
                pair.Property(x => x.Key).HasMaxLength(ModelRules.KeyValuePair.KeyMaxLength).IsRequired();
                pair.Property(x => x.Value).HasMaxLength(ModelRules.KeyValuePair.ValueMaxLength);
                pair.Property(x => x.Description).HasMaxLength(ModelRules.KeyValuePair.DescriptionMaxLength);
                pair.Property(x => x.Timestamp).IsRowVersion();
                //pair.Property(x => x.ApplyType).HasConversion<string>();
                //pair.Property(x => x.ValueType).HasConversion<string>();

                pair.HasOne(x => x.Environment).WithMany(x => x.KeyValuePairs).HasForeignKey(x => x.EnvironmentId).OnDelete(DeleteBehavior.SetNull).IsRequired(false);
                pair.HasMany(x => x.Histories).WithOne(x => x.KeyValuePair).HasForeignKey(x => x.KeyValuePairId).OnDelete(DeleteBehavior.SetNull).IsRequired();
            });

            modelBuilder.Entity<CrispyKeyValuePairHistory>(pairHistory =>
            {
                pairHistory.HasKey(x => x.Id);

                pairHistory.Property(x => x.Value).HasMaxLength(ModelRules.KeyValuePairHistory.ValueMaxLength);
                //pairHistory.Property(x => x.ValueType).HasConversion<string>();

                pairHistory.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
            });


        }

        public override int SaveChanges()
        {
            return this.SaveChangesWithTriggers(base.SaveChanges, acceptAllChangesOnSuccess: true);
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return this.SaveChangesWithTriggers(base.SaveChanges, acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.SaveChangesWithTriggersAsync(base.SaveChangesAsync, acceptAllChangesOnSuccess: true, cancellationToken: cancellationToken);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.SaveChangesWithTriggersAsync(base.SaveChangesAsync, acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
