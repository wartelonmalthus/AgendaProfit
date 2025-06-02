using AgendaProfit.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaProfit.Infraestructure.Configurations;

public class AgendaConfiguration : IEntityTypeConfiguration<Agenda>
{
    public void Configure(EntityTypeBuilder<Agenda> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(c => c.Nome)
               .HasMaxLength(250);

        builder.HasMany(a => a.Contatos)
               .WithOne(c => c.Agenda)
               .HasForeignKey(c => c.AgendaId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
