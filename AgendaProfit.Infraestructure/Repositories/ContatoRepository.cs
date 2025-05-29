using AgendaProfit.Domain.Entities;
using AgendaProfit.Infraestructure.Context;
using AgendaProfit.Infraestructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgendaProfit.Infraestructure.Repositories;

public class ContatoRepository(AgendaDbContext context) : BaseRepository<Contato>(context), IContatoRepository
{
    private readonly AgendaDbContext _context = context;

    public async override Task<Contato> ObterPorIdDetalhadoAsync(int id)
    {
        return await _context.Contatos.Include(c => c.Agenda).SingleOrDefaultAsync(c => c.Id == id);

    }
}
