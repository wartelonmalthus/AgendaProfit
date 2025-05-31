using AgendaProfit.Application.ViewModel.Contato.Request;
using AgendaProfit.Application.ViewModel.Contato.Responses;

namespace AgendaProfit.Application.AppllicationService.Interfaces;

public interface IContatoApplicationService
{
    public Task<IEnumerable<ContatoResponse>> ObterTodosOsContatos(int numeroDaPagina = 1, int tamanhoDaPagina = 10);
    public Task<(bool,string)> AddContato(CreateContatoRequest createRequest);
    public Task<ContatoResponse> ObterContatoPorId(int id);
    public Task<(bool,string)> AlterarContato(UpdateContatoRequest updateRequest);
    public Task<(bool,string)> RemoverContato(int id);
}
