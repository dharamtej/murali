using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace EntityFramework
{
  public   class context:DbContext
    {
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectingstrig = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
            optionsBuilder.UseSqlServer(connectingstrig);
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<products> Product { get; set; }
        public DbSet<customer> CustomerDetails { get; set; }

    }
}
