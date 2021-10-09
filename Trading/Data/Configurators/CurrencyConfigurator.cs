using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading.Data.Models;

namespace Trading.Data.Configurators
{
    public class CurrencyConfigurator : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable("Currency");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.CurrencyCode).HasColumnName("currency_code").IsRequired();
            builder.Property(p => p.Type).HasColumnName("type").IsRequired();
        }
    }
}
