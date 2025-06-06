﻿using AgendaProfit.Domain.Entities;
using AgendaProfit.Infraestructure.Context;
using AgendaProfit.Infraestructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using X.PagedList.EF;

namespace AgendaProfit.Infraestructure.Repositories;

public class ContatoRepository(AgendaDbContext context) : BaseRepository<Contato>(context), IContatoRepository
{
    private readonly AgendaDbContext _context = context;

    public async Task<IPagedList<Contato>> ObterContatosPaginadaAsync(int numeroDaPagina = 1, int tamanhoDaPagina = 10)
    {
        return await _context.Contatos
         .Where(a => !a.DelecaoLogica)
         .Include(a => a.Agenda)
         .OrderBy(a => a.Agenda)
         .ToPagedListAsync(numeroDaPagina, tamanhoDaPagina);
    }

    public async override Task<Contato> ObterPorIdDetalhadoAsync(int id)
    {
        return await _context.Contatos.Where(a => !a.DelecaoLogica).Include(c => c.Agenda).SingleOrDefaultAsync(c => c.Id == id);

    }
}
