using AgendaProfit.Application.AppllicationService.Interfaces;
using AgendaProfit.Application.Mapper;
using AgendaProfit.Application.ViewModel.Contato.Request;
using AgendaProfit.Application.ViewModel.Contato.Responses;
using AgendaProfit.Infraestructure.Repositories.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace AgendaProfit.Application.AppllicationService;

public class ContatoApplicationService(IContatoRepository contatoRepository, IMemoryCache memoryCache) : BaseApplicationService(memoryCache), IContatoApplicationService
{
    private readonly IContatoRepository _contatoRepository = contatoRepository;

    public async Task<(bool, string)> AddContato(CreateContatoRequest createRequest)
    {
        try
        {
            await _contatoRepository.AdicionarAsync(createRequest.ToEntidade());
            ClearCache();

            return (true, null);
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }

    public async Task<ContatoResponse> ObterContatoPorId(int id)
    {
        var contato = await GetOrSetCacheAsync(
                     $"contatoId:{id}",
                     () =>  _contatoRepository.ObterPorIdAsync(id),
                     TimeSpan.FromMinutes(20));

        return contato.ToResponse();
    }

    public async Task<IEnumerable<ContatoResponse>> ObterTodosOsContatos(int numeroDaPagina = 1, int tamanhoDaPagina = 10)
    {
        return (await _contatoRepository.ObterContatosPaginadaAsync(numeroDaPagina, tamanhoDaPagina)).ToResponse();
    }

    public async Task<(bool, string)> RemoverContato(int id)
    {
        try
        {
            await _contatoRepository.RemoverAsync(id);
            ClearCache();

            return (true, null);
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }
    public async Task<(bool, string)> AlterarContato(UpdateContatoRequest updateRequest)
    {
        try
        {
            var contato = await _contatoRepository.ObterPorIdAsync(updateRequest.Id);

            if (contato is null)
                return (false, "contato não encontrada");

            contato.AlterarDados(updateRequest.Nome, updateRequest.Email, updateRequest.Telefone);

            if(updateRequest.Descricao is not null)
                contato.AdicionarDescricao(updateRequest.Descricao);

            if (updateRequest.AgendaId is not null)
                contato.VincularAgenda((int)updateRequest.AgendaId);

            await _contatoRepository.AlterarAsync(contato);
            ClearCache();

            return (true, null);
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }
}
