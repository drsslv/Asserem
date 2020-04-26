using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class SaleContext: DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public  DbSet<Person> Persons { get; set; }
        public DbSet<Sale> Sales { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<SaleContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}