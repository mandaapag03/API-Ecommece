using AdministratorAPI.Mapping;
using AdministratorAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AdministratorAPI.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.Development.json").Build();
            options.UseNpgsql(config.GetConnectionString("PostgreSQL"));
            options.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new FeedbackMap());
        }
    }
}
