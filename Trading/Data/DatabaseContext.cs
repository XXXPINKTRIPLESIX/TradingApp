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
        public DbSet<MoneyAccount> Balances { get; set; }
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

            builder.Entity<User>().HasData(new User(1, "111", "111", "3343333@gmail.com", null
               /* new PersonalData("name111", "lastname111", "surname111", "+380", "Desc111")*/, null));
            //builder.Entity<User>().HasData(new User {Id = 1, Login = "111", Password = "111", Email = "111@gmail.com", Balances = null, PersonalData = null });
        }
    }
}
