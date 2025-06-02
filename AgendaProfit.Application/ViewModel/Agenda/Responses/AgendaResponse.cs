using AgendaProfit.Application.ViewModel.Contato.Responses;

namespace AgendaProfit.Application.ViewModel.Agenda.Responses;

public class AgendaResponse
{
    public int? Id { get; set; }
    public string? Nome { get; set; }
    public int? TotalDeContatos { get; set; }
    public IEnumerable<ContatoResponse?> Contatos { get; set; }
}
