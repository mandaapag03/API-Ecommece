using Microsoft.EntityFrameworkCore;
using OhMyDogAPI.Model.dto;

namespace OhMyDogAPI.Repository.Context
{
    public class DatabaseContext : DbContext
    {

        public DbSet<ClienteDto> Clientes{ get; set; }
        public DbSet<UsuarioDto> Usuarios { get; set; }
        public DbSet<TipoPessoaDto> TiposPessoa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.Development.json").Build();
            options.UseNpgsql(config.GetConnectionString("PostgreSQL"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<ClienteDto>()
            //    .Has
            //    .HasKey(c => c.id)
        }
    }
}
