using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aircall.Model;
using Microsoft.EntityFrameworkCore;

namespace Aircall.Data
{
    class ApplicationDbContext : DbContext
    {
        public DbSet<Peoples> People { get; set; }
        public DbSet<Password> passes { get; set; }
        public DbSet<SaveProperties> saveProp { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Peopless.db");
            optionsBuilder.UseSqlite("Data Source = Password.db");
            optionsBuilder.UseSqlite("Data Source = SaveProp.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
