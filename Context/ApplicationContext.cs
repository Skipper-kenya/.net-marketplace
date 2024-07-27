using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using marketplace1.Models;

namespace marketplace1.Context
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext():base("DefaultConnection") { }

        public DbSet<Items> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}