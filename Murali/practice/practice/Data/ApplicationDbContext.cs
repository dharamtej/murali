using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using practice.Models;

namespace practice.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<practice.Models.customer> customer { get; set; }
        public DbSet<practice.Models.Products> Products { get; set; }
        public DbSet<practice.Models.TableMvc1> TableMvc1 { get; set; }
        public DbSet<practice.Models.TableMvc2> TableMvc2 { get; set; }
       
    }
}
