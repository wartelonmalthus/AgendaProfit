using AgendaProfit.Domain.Entities;
using X.PagedList;

namespace AgendaProfit.Infraestructure.Repositories.Interfaces;

public interface IContatoRepository : IBaseRepository<Contato>
{
    Task<IPagedList<Contato>> ObterContatosPaginadaAsync(int numeroDaPagina = 1, int tamanhoDaPagina = 10);

}
