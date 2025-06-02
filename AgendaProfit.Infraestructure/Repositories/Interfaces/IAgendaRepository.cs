using AgendaProfit.Domain.Entities;
using X.PagedList;

namespace AgendaProfit.Infraestructure.Repositories.Interfaces;

public interface IAgendaRepository : IBaseRepository<Agenda>
{
    Task<IPagedList<Agenda>> ObterAgendaComContatosPaginadaAsync(int numeroDaPagina = 1, int tamanhoDaPagina = 10);

}
