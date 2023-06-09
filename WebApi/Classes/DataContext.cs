﻿using Microsoft.EntityFrameworkCore;

namespace WebApi.Classes
{
    public class DataContext : DbContext
    {
        private string _conString = @"Data Source=LAPTOP-14OU6DIV\SQLEXPRESS;Initial Catalog=Olima;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";

        //private string _prodConString = @"Server=tcp:olimaserver.database.windows.net,1433;Initial Catalog=olima;Persist Security Info=False;User ID=newadmin;Password=;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //_conString = _prodConString;

            if (!optionsBuilder.IsConfigured)
            {                
                optionsBuilder.UseSqlServer(_conString);
            }
        }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<MaterialType> MaterialType { get; set; }
        public virtual DbSet<Insert> Insert { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Order_Product> Order_Product { get; set; }
        public virtual DbSet<Photo> Photo { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<StoneType> StoneType { get; set; }
        public virtual DbSet<Supply> Supply { get; set; }
        public virtual DbSet<Supply_Product> Supply_Product { get; set; }
    }
}
