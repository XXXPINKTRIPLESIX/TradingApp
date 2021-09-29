using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trading.Data.Models;

namespace Trading.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Balance> Balances { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
