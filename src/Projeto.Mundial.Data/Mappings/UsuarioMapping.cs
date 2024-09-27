using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Mundial.Domain.Entities;

namespace Projeto.Mundial.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(p => new { p.Id });
            builder.Ignore(p => p.ListaErros);
            builder.Ignore(p => p.ValidationResult);
            builder.Property(p => p.Nome).IsRequired().HasColumnType("varchar").HasMaxLength(100);
            builder.Property(p => p.Email).IsRequired().HasColumnType("varchar").HasMaxLength(100);
            builder.Property(p => p.Senha).IsRequired().HasColumnType("varchar").HasMaxLength(100);
            builder.Property(p => p.Criacao).IsRequired().HasColumnType("datetime").HasColumnName("Criacao");

            // Configurando relacionamento muitos-para-um
            builder.HasOne(u => u.Perfil)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(u => u.IdPerfil)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Usuario");

        }
    }
}
