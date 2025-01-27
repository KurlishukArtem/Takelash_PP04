using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Takelash_app.Classes
{
    public class CompContext : DbContext
    {
        public DbSet<CompanyType> Company { get; set; }

        public CompContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseMySql("server=127.0.0.1;port=3307;uid=root;pwd=;database=Takelash", new MySqlServerVersion(new Version(8, 0, 11)));
        }

    }
}
