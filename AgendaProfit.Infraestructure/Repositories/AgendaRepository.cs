using AgendaProfit.Domain.Entities;
using AgendaProfit.Infraestructure.Context;
using AgendaProfit.Infraestructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgendaProfit.Infraestructure.Repositories;

public class AgendaRepository(AgendaDbContext context) : BaseRepository<Agenda>(context), IAgendaRepository
{
    private readonly AgendaDbContext _context = context;

    public async Task<IEnumerable<Agenda>> ObterAgendaComContatosAsync()
    {
        return await _context.Agendas.Include(a => a.Contatos).ToListAsync();

    }
    public async override Task<Agenda> ObterPorIdDetalhadoAsync(int id)
    {
        return await _context.Agendas.Include(a => a.Contatos).SingleOrDefaultAsync(c => c.Id == id);

    }

}
