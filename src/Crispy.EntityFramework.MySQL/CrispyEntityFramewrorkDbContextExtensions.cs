namespace Crispy.EntityFramework
{
    using Crispy.Abstractions;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ModelRules = Crispy.Abstractions.CrispyConstants.ModelRules;

    public static class CrispyEntityFramewrorkDbContextExtensions
    {
        public static ModelBuilder ConfigureTableName(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CrispyApplication>().ToTable(ModelRules.Application.TableName);
            modelBuilder.Entity<CrispyVariable>().ToTable(ModelRules.Variable.TableName);
            modelBuilder.Entity<CrispyEnvironment>().ToTable(ModelRules.Environment.TableName);
            modelBuilder.Entity<CrispyKeyValuePair>().ToTable(ModelRules.KeyValuePair.TableName);
            modelBuilder.Entity<CrispyKeyValuePairHistory>().ToTable(ModelRules.KeyValuePairHistory.TableName);

            return modelBuilder;
        }
    }
}
