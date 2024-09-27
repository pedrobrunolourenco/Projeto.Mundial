using Microsoft.EntityFrameworkCore;
using Projeto.Mundial.Data.Mappings;
using Projeto.Mundial.Domain.Entities;

namespace Projeto.Mundial.Data
{
    public class DataContext : DbContext
    {

        public DataContext()
        {

        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Perfil> Perfil { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            modelBuilder.ApplyConfiguration(new PerfilMapping());
            base.OnModelCreating(modelBuilder);
        }

    }
}
