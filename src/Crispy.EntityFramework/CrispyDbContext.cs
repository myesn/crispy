namespace Crispy.EntityFramework
{
    using Crispy.Abstractions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using JetBrains.Annotations;

    public class CrispyDbContext : DbContext, ICrispyStore
    {
        public CrispyDbContext([NotNull]DbContextOptions options) : base(options)
        { }

        public DbSet<CrispyProject> Projects { get; set; }
        public DbSet<CrispyEnvironment> Enviroments { get; set; }
        public DbSet<CrispyKeyValuePair> KeyValuePairs { get; set; }
        public DbSet<CrispyKeyValuePairHistory> KeyValuePairHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CrispyProject>(project =>
            {
                project.HasKey(x => x.Id);

                project.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
                project.Property(x => x.Name).HasMaxLength(50).IsRequired();

                project.HasMany(x => x.Enviroments).WithOne(x => x.Project).HasForeignKey(x => x.ProjectId).OnDelete(DeleteBehavior.SetNull).IsRequired();
            });

            modelBuilder.Entity<CrispyEnvironment>(enviroment =>
            {
                enviroment.HasKey(x => x.Id);

                enviroment.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
                enviroment.Property(x => x.Name).HasMaxLength(50).IsRequired();

                enviroment.HasMany(x => x.KeyValuePairs).WithOne(x => x.OwnerdEnviroment).HasForeignKey(x => x.OwnerdId).OnDelete(DeleteBehavior.SetNull).IsRequired(false);
            });

            modelBuilder.Entity<CrispyKeyValuePair>(pair =>
            {
                pair.HasKey(x => x.Id);

                pair.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
                pair.Property(x => x.Key).HasMaxLength(50).IsRequired();
                pair.Property(x => x.Description).HasMaxLength(100);
                pair.Property(x => x.Timestamp).IsRowVersion();

                pair.HasMany(x => x.Histories).WithOne(x => x.KeyValuePair).HasForeignKey(x => x.KeyValuePairId).OnDelete(DeleteBehavior.SetNull).IsRequired();
            });

            modelBuilder.Entity<CrispyKeyValuePairHistory>(pairHistory =>
            {
                pairHistory.HasKey(x => x.Id);

                pairHistory.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
            });


        }
    }
}
