using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trading.Data.Models;

namespace Trading.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options) =>
            Database.EnsureCreated();


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<User>().HasData(DefaultDataProvider.GetUsers());
            builder.Entity<Currency>().HasData(DefaultDataProvider.GetCurrencies());

            base.OnModelCreating(builder);
        }
    }
}
