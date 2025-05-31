using AgendaProfit.Application.ViewModel.Agenda.Request;
using AgendaProfit.Application.ViewModel.Agenda.Responses;

namespace AgendaProfit.Application.AppllicationService.Interfaces;

public interface IAgendaApplicationService
{
    public Task<IEnumerable<AgendaResponse>> ObterTodasAgendas(int numeroDaPagina = 1, int tamanhoDaPagina = 10);
    public Task<(bool, string)> AddAgenda(CreateAgendaRequest createRequest);
    public Task<AgendaResponse> ObterAgendaPorId(int id);
    public Task<(bool, string)> AlterarAgenda(UpdateAgendaRequest updateRequest);
    public Task<(bool, string)> RemoverAgenda(int id);
}
