﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ECommerce.Models
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext() : base("DefaultConnection")
        {

        }

        //DESABILITAR CASCATAS

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public System.Data.Entity.DbSet<ECommerce.Models.Departaments> Departaments { get; set; }

        public System.Data.Entity.DbSet<ECommerce.Models.City> Cities { get; set; }

        public System.Data.Entity.DbSet<ECommerce.Models.Company> Companies { get; set; }

        public System.Data.Entity.DbSet<ECommerce.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<ECommerce.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<ECommerce.Models.Tax> Taxes { get; set; }

        public System.Data.Entity.DbSet<ECommerce.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<ECommerce.Models.WareHouse> WareHouses { get; set; }

        public System.Data.Entity.DbSet<ECommerce.Models.Inventory> Inventories { get; set; }

        public System.Data.Entity.DbSet<ECommerce.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<ECommerce.Models.State> States { get; set; }

        public System.Data.Entity.DbSet<ECommerce.Models.Orders> Orders { get; set; }

        public System.Data.Entity.DbSet<ECommerce.Models.OrderDetails> OrderDetails { get; set; }

        public System.Data.Entity.DbSet<ECommerce.Models.OrderDetailTmp> OrderDetailTmp { get; set; }
    }
}