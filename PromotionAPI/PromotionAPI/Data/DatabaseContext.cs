using Microsoft.EntityFrameworkCore;
using PromotionAPI.Mapping;
using PromotionAPI.Model;

namespace PromotionAPI.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<CurrentPromotion> CurrentPromotions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.Development.json").Build();
            options.UseNpgsql(config.GetConnectionString("PostgreSQL"));
            options.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PromotionMap());
            builder.ApplyConfiguration(new CurrentPromotionMap());
        }
    }
}
