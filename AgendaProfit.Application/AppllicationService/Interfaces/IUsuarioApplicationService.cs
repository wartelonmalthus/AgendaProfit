using AgendaProfit.Application.ViewModel.Usuario.Request;
using AgendaProfit.Application.ViewModel.Usuario.Responses;

namespace AgendaProfit.Application.AppllicationService.Interfaces;

public interface IUsuarioApplicationService
{
    public Task<IEnumerable<UsuarioResponse>> ObterTodosOsUusarios(int numeroDaPagina = 1, int tamanhoDaPagina = 10);
    public Task<(bool, string)> AddUsuario(CreateUsuarioRequest createRequest);
    public Task<UsuarioResponse> ObterUsuarioPorId(int id);
    public Task<(bool, string)> AlterarUsuario(UpdateUsuarioRequest updateRequest);
    public Task<(bool, string)> RemoverUsuario(int id);
}

