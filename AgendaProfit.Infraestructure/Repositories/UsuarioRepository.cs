using AgendaProfit.Domain.Entities;
using AgendaProfit.Infraestructure.Context;
using AgendaProfit.Infraestructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgendaProfit.Infraestructure.Repositories;

public class UsuarioRepository(AgendaDbContext context) : BaseRepository<Usuario>(context), IUsuarioRepository
{
    private readonly AgendaDbContext _context = context;

    public async override Task<Usuario> ObterPorIdDetalhadoAsync(int id)
    {
        return await _context.Usuarios.Include(u => u.Agenda).SingleOrDefaultAsync(c => c.Id == id);

    }

}
