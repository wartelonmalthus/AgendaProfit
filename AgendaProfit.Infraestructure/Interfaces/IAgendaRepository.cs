using AgendaProfit.Domain.Entities;

namespace AgendaProfit.Infraestructure.Interfaces;

public interface IAgendaRepository : IBaseRepository<Agenda>
{
    Task<IEnumerable<Agenda>> ObterAgendaComContatosAsync();

}
