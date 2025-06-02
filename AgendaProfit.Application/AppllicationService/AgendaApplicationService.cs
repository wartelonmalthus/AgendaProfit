using AgendaProfit.Application.AppllicationService.Interfaces;
using AgendaProfit.Application.Mapper;
using AgendaProfit.Application.ViewModel.Agenda.Request;
using AgendaProfit.Application.ViewModel.Agenda.Responses;
using AgendaProfit.Infraestructure.Repositories.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace AgendaProfit.Application.AppllicationService;
public class AgendaApplicationService(IAgendaRepository agendaRepository, IMemoryCache memoryCache)  : BaseApplicationService(memoryCache), IAgendaApplicationService
{
    private readonly IAgendaRepository _agendaRepository = agendaRepository;
    public async Task<(bool, string)> AddAgenda(CreateAgendaRequest createRequest)
    {
        try
        {
            await _agendaRepository.AdicionarAsync(createRequest.ToEntidade());
            ClearCache();

            return (true, null); 
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }
    public async Task<AgendaResponse?> ObterAgendaPorId(int id)
    {
        var agenda = await GetOrSetCacheAsync(
                        $"agendaId:{id}",
                        () => _agendaRepository.ObterPorIdAsync(id),
                        TimeSpan.FromMinutes(20));

        return agenda.ToResponse();
    }
    public async Task<IEnumerable<AgendaResponse?>> ObterTodasAgendas(int numeroDaPagina = 1, int tamanhoDaPagina = 10)
    {
        try
        {
            return (await _agendaRepository.ObterAgendaComContatosPaginadaAsync(numeroDaPagina, tamanhoDaPagina)).ToResponse();

        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public async Task<(bool, string)> RemoverAgenda(int id)
    {
        try
        {
            await _agendaRepository.RemoverAsync(id);
            ClearCache();

            return (true, null);    
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }
    public async Task<(bool, string)> AlterarAgenda(UpdateAgendaRequest updateRequest)
    {
        try
        {
            var agenda = await _agendaRepository.ObterPorIdAsync(updateRequest.Id);

            if (agenda is null)
                return (false, "agenda não encontrada");

            if (updateRequest.Nome is not null)
                agenda.AlterarNome(updateRequest.Nome);

            await _agendaRepository.AlterarAsync(agenda);
            ClearCache();

            return (true, null);
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }
      
}
