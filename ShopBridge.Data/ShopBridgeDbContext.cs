using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShopBridge.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopBridge.Data
{
    public class ShopBridgeDbContext : DbContext
    {
        private IConfiguration configuration;
        public ShopBridgeDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public ShopBridgeDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=MURUGAVELS\\MURUGAVELSQL;Initial Catalog=ShopBridge;Integrated Security=SSPI;";
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        //Added entities to create tables
        public DbSet<ItemDetails> ItemDetails { get; set; }

    }
}
