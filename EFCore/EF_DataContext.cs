using Microsoft.EntityFrameworkCore;

namespace ShopingApi.EFCore
{
    public class EF_DataContext : DbContext
    {
        public EF_DataContext(DbContextOptions<EF_DataContext> options) : base(options) { }

        public DbSet<Product> Products { get; set;}
        public DbSet<Order> Orders { get; set;}
    }
}
