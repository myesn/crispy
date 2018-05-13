namespace Crispy.EntityFramework
{
    using Crispy.Abstractions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using JetBrains.Annotations;


    public class CrispyMySQLDbContext : CrispyDbContext
    {
        public CrispyMySQLDbContext([NotNull]DbContextOptions<CrispyMySQLDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ConfigureTableName();
    }
}
