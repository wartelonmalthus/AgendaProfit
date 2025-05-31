using AgendaProfit.Domain.Entities;
using X.PagedList;

namespace AgendaProfit.Infraestructure.Repositories.Interfaces;

public interface IUsuarioRepository : IBaseRepository<Usuario>
{
    Task<IPagedList<Usuario>> ObterContatosPaginadaAsync(int numeroDaPagina = 1, int tamanhoDaPagina = 10);

}
