using AgendaProfit.Domain.Abstract;
using AgendaProfit.Infraestructure.Context;
using AgendaProfit.Infraestructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgendaProfit.Infraestructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    private readonly AgendaDbContext _context;
    private readonly DbSet<T> _dbSet;

    public BaseRepository(AgendaDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();

    }
    public async Task<int> AdicionarAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task AlterarAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<T> ObterPorIdAsync(int id) => await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.DelecaoLogica == false);
    public virtual async Task<T> ObterPorIdDetalhadoAsync(int id) => await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
    public async Task<IEnumerable<T>> ObterTudoAsync() => await _dbSet.Where(x => x.DelecaoLogica == false).ToListAsync();

    public async Task RemoverAsync(int id)
    {
        var entity = await ObterPorIdAsync(id);
        if (entity != null)
        {
            entity.DeletarEntidade();
            await AlterarAsync(entity);
        }
    }

    public async Task<bool> VerificarSeExiste(int id) => await _dbSet.AnyAsync(x => x.Id == id);
}

