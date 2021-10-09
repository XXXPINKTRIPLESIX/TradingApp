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
        public DbSet<Account> Balances { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);

            builder.Entity<User>().HasData(new User(1, "111", "111", "111@gmail.com", "admin", null
               /* new PersonalData("name111", "lastname111", "surname111", "+380", "Desc111")*/, null));
            //builder.Entity<User>().HasData(new User {Id = 1, Login = "111", Password = "111", Email = "111@gmail.com", Balances = null, PersonalData = null });
            builder.Entity<User>().HasData(new User(2, "222", "222", "222@gmail.com", "user", null, null));
            builder.Entity<User>().HasData(new User(3, "333", "333", "333@gmail.com", "user", null, null));
            builder.Entity<User>().HasData(new User(4, "444", "444", "444@gmail.com", "user", null, null));
            builder.Entity<User>().HasData(new User(5, "555", "555", "555@gmail.com", "user", null, null));
            builder.Entity<User>().HasData(new User(6, "666", "666", "666@gmail.com", "user", null, null));

            builder.Entity<Currency>().HasData(new Currency(1, "USD", CurrencyType.Fiat));
            builder.Entity<Currency>().HasData(new Currency(2, "EUR", CurrencyType.Fiat));
            builder.Entity<Currency>().HasData(new Currency(3, "UAH", CurrencyType.Fiat));
            builder.Entity<Currency>().HasData(new Currency(4, "RUB", CurrencyType.Fiat));

            builder.Entity<Currency>().HasData(new Currency(5, "BTC", CurrencyType.Crypto));
            builder.Entity<Currency>().HasData(new Currency(6, "ETH", CurrencyType.Crypto));
            builder.Entity<Currency>().HasData(new Currency(7, "CryproName", CurrencyType.Crypto));
        }
    }
}
