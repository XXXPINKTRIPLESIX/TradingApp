using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Data.Models;

namespace Trading.Data.Configurators
{
    public class AccountConfigurator : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.CurrencyId).HasColumnName("currency_id").IsRequired();
            builder.Property(p => p.Amount).HasColumnName("amount").HasColumnType("decimal").HasDefaultValue(0);
            builder.Property(p => p.StudentId).HasColumnName("student_id").IsRequired();
        }
    }
}
