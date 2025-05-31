using AgendaProfit.Domain.Entities;
using AgendaProfit.Infraestructure.Context;
using AgendaProfit.Infraestructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using X.PagedList.EntityFramework;

namespace AgendaProfit.Infraestructure.Repositories;

public class UsuarioRepository(AgendaDbContext context) : BaseRepository<Usuario>(context), IUsuarioRepository
{
    private readonly AgendaDbContext _context = context;

    public async Task<IPagedList<Usuario>> ObterContatosPaginadaAsync(int numeroDaPagina = 1, int tamanhoDaPagina = 10)
    {
        return await _context.Usuarios
        .Include(a => a.Agenda)
        .ThenInclude(a => a.Contatos)
        .OrderBy(a => a.Nome)
        .ToPagedListAsync(numeroDaPagina, tamanhoDaPagina);
    }

    public async override Task<Usuario> ObterPorIdDetalhadoAsync(int id)
    {
        return await _context.Usuarios.Include(u => u.Agenda).SingleOrDefaultAsync(c => c.Id == id);

    }

}
