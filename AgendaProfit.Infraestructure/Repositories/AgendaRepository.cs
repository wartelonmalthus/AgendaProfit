using AgendaProfit.Domain.Entities;
using AgendaProfit.Infraestructure.Context;
using AgendaProfit.Infraestructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using X.PagedList.EF;

namespace AgendaProfit.Infraestructure.Repositories;

public class AgendaRepository(AgendaDbContext context) : BaseRepository<Agenda>(context), IAgendaRepository
{
    private readonly AgendaDbContext _context = context;

    public async Task<IPagedList<Agenda>> ObterAgendaComContatosPaginadaAsync(int numeroDaPagina = 1, int tamanhoDaPagina = 10)
    {
        return await _context.Agendas
          .Where(a => !a.DelecaoLogica)
          .Include(a => a.Contatos)
          .OrderBy(a => a.Nome) 
          .ToPagedListAsync(numeroDaPagina, tamanhoDaPagina);
    }
    public async override Task<Agenda> ObterPorIdDetalhadoAsync(int id)
    {
        return await _context.Agendas.Where(a => !a.DelecaoLogica).Include(a => a.Contatos).SingleOrDefaultAsync(c => c.Id == id);

    }

}
