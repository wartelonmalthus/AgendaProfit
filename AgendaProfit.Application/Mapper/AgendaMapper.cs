using AgendaProfit.Application.ViewModel.Agenda.Request;
using AgendaProfit.Application.ViewModel.Agenda.Responses;
using AgendaProfit.Domain.Entities;

namespace AgendaProfit.Application.Mapper;

public static class AgendaMapper
{

    public static Agenda ToEntidade(this CreateAgendaRequest request) => new Agenda(request.Nome);

    public static AgendaResponse? ToResponse(this Agenda? agenda)
    {
        if (agenda == null)
            return null;

        return new AgendaResponse
        {
            Nome = string.IsNullOrWhiteSpace(agenda.Nome) ? null : agenda.Nome,
            Id = agenda.Id != 0 ? agenda.Id : null,
            TotalDeContatos = agenda.TotalDeContatos > 0 ? agenda.TotalDeContatos : null,
            Contatos = agenda.Contatos?
              .Where(c => !c.DelecaoLogica)
              .Select(c => c.ToResponse())
              .ToList()
        };
    }
    public static IEnumerable<AgendaResponse?> ToResponse(this IEnumerable<Agenda> agendas) =>
        agendas?.Select(a => ToResponse(a)) ?? Enumerable.Empty<AgendaResponse>();
}
