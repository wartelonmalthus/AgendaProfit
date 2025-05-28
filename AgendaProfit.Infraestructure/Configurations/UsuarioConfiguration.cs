using AgendaProfit.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaProfit.Infraestructure.Configurations;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Nome)
               .IsRequired()
               .HasMaxLength(250);

        builder.Property(c => c.Email)
               .IsRequired()
               .HasMaxLength(250);

        builder.Property(u => u.Senha)
               .IsRequired()
               .HasMaxLength(100);

        builder.HasOne(u => u.Agenda)
               .WithOne() 
               .HasForeignKey<Usuario>(u => u.AgendaId)
               .OnDelete(DeleteBehavior.Cascade);


    }
}
