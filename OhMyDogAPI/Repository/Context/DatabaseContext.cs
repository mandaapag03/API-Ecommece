using Microsoft.EntityFrameworkCore;
using OhMyDogAPI.Model;
using OhMyDogAPI.Model.dto;

namespace OhMyDogAPI.Repository.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<UsuarioDto> Usuarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.Development.json").Build();
            options.UseNpgsql(config.GetConnectionString("PostgreSQL"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}
