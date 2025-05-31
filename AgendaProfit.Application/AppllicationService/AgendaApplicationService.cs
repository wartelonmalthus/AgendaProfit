using AgendaProfit.Application.AppllicationService.Interfaces;
using AgendaProfit.Application.ViewModel.Agenda.Request;
using AgendaProfit.Application.ViewModel.Agenda.Responses;
using AgendaProfit.Infraestructure.Repositories;
using Microsoft.Extensions.Caching.Memory;

namespace AgendaProfit.Application.AppllicationService;
public class AgendaApplicationService(AgendaRepository agendaRepository, IMemoryCache memoryCache)  : BaseApplicationService(memoryCache), IAgendaApplicationService
{
    public Task<(bool, string)> AddAgenda(CreateAgendaRequest createRequest)
    {
        throw new NotImplementedException();
    }

    public Task<(bool, string)> AlterarAgenda(UpdateAgendaRequest updateRequest)
    {
        throw new NotImplementedException();
    }

    public Task<AgendaResponse> ObterAgendaPorId(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AgendaResponse>> ObterTodasAgendas(int numeroDaPagina = 1, int tamanhoDaPagina = 10)
    {
        throw new NotImplementedException();
    }

    public Task<(bool, string)> RemoverAgenda(int id)
    {
        throw new NotImplementedException();
    }
}
