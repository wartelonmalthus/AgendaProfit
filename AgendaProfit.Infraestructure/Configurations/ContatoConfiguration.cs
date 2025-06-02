using AgendaProfit.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaProfit.Infraestructure.Configurations;

public class ContatoConfiguration : IEntityTypeConfiguration<Contato>
{
    public void Configure(EntityTypeBuilder<Contato> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Nome)
               .IsRequired()
               .HasMaxLength(250);

        builder.Property(c => c.Email)
               .IsRequired()
               .HasMaxLength(250);

        builder.Property(c => c.Telefone)
               .IsRequired()
               .HasMaxLength(11);

        builder.Property(c => c.Descricao)
               .HasMaxLength(350);

        builder.HasOne(c => c.Agenda)
               .WithMany(a => a.Contatos)
               .HasForeignKey(c => c.AgendaId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
