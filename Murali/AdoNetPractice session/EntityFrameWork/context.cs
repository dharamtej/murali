using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace EntityFrameWork
{
  public  class context:DbContext
    {
        static string connectstring = string.Empty;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            connectstring = ConfigurationManager.ConnectionStrings["ConnectingString"].ConnectionString;
            optionsBuilder.UseSqlServer(connectstring);

        }
        public DbSet<orders> Orders1 { get; set; }
        public DbSet<customer> customers { get; set; }
    }
}
