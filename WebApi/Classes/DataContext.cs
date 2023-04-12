using Microsoft.EntityFrameworkCore;

namespace WebApi.Classes
{
    public class DataContext : DbContext
    {
        private string _conString = @"Data Source=LAPTOP-14OU6DIV\SQLEXPRESS;Initial Catalog=Olima;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {                
                optionsBuilder.UseSqlServer(_conString);
            }
        }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<MaterialType> MaterialType { get; set; }

    }
}
