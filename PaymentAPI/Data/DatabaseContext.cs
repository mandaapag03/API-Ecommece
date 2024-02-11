using Microsoft.EntityFrameworkCore;
using PaymentAPI.Mapping;
using PaymentAPI.Model;

namespace PaymentAPI.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentStatus> PaymentStatus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.Development.json").Build();
            options.UseNpgsql(config.GetConnectionString("PostgreSQL"));
            options.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PaymentMethodMap());
            builder.ApplyConfiguration(new PaymentMap());
            builder.ApplyConfiguration(new PaymentStatusMap());
        }
    }
}
