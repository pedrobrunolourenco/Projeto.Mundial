using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Mundial.Domain.Entities;

namespace Projeto.Mundial.Data.Mappings
{
    public class PerfilMapping : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.HasKey(p => new { p.IdPerfil });
            builder.Property(p => p.Nome).HasColumnType("varchar").IsRequired().HasMaxLength(50);
            builder.Property(p => p.Criacao).IsRequired().HasColumnType("datetime").HasColumnName("Criacao");
            builder.Ignore(t => t.ListaErros);
            builder.Ignore(t => t.ValidationResult);

            builder.HasMany(p => p.Usuarios)
                       .WithOne(u => u.Perfil)
                       .HasForeignKey(u => u.IdPerfil)
                       .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Perfil");
        }
    }
}
