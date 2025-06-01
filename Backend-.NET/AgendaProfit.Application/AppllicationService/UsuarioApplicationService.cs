using AgendaProfit.Application.AppllicationService.Interfaces;
using AgendaProfit.Application.Mapper;
using AgendaProfit.Application.ViewModel.Usuario.Request;
using AgendaProfit.Application.ViewModel.Usuario.Responses;
using AgendaProfit.Infraestructure.Repositories.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace AgendaProfit.Application.AppllicationService;

public class UsuarioApplicationService(IUsuarioRepository usuarioRepository, IMemoryCache memoryCache) : BaseApplicationService(memoryCache), IUsuarioApplicationService
{
    private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;

    public async Task<(bool, string)> AddUsuario(CreateUsuarioRequest createRequest)
    {
        try
        {
            await _usuarioRepository.AdicionarAsync(createRequest.ToEntidade());
            ClearCache();

            return (true, null);
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }

    public async Task<IEnumerable<UsuarioResponse>> ObterTodosOsUusarios(int numeroDaPagina = 1, int tamanhoDaPagina = 10)
    {
        return (await _usuarioRepository.ObterUsuariosPaginadaAsync(numeroDaPagina, tamanhoDaPagina)).ToResponse();
    }

    public async Task<UsuarioResponse> ObterUsuarioPorId(int id)
    {
        var usuario = await GetOrSetCacheAsync(
              $"usuarioId:{id}",
              () => _usuarioRepository.ObterPorIdAsync(id),
              TimeSpan.FromMinutes(20));

        return usuario.ToResponse();
    }

    public async Task<(bool, string)> RemoverUsuario(int id)
    {
        try
        {
            await _usuarioRepository.RemoverAsync(id);
            ClearCache();

            return (true, null);
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }
    public async Task<(bool, string)> AlterarUsuario(UpdateUsuarioRequest updateRequest)
    {
        try
        {
            var usuario = await _usuarioRepository.ObterPorIdAsync(updateRequest.Id);

            if (usuario is null)
                return (false, "usuário não encontrada");

            usuario.AlterarDados(updateRequest.Nome, updateRequest.Email, updateRequest.Telefone);

            if (updateRequest.AgendaId is not null)
                usuario.VincularAgenda((int)updateRequest.AgendaId);

            await _usuarioRepository.AlterarAsync(usuario);
            ClearCache();

            return (true, null);
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }
}
