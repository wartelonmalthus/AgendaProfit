using AgendaProfit.Application.ViewModel.Agenda.Request;
using AgendaProfit.Application.ViewModel.Agenda.Responses;
using AgendaProfit.Domain.Entities;

namespace AgendaProfit.Application.Mapper;

public static class AgendaMapper
{

    public static Agenda ToEntidade(this CreateAgendaRequest request) => new Agenda(request.Nome);

    public static AgendaResponse? ToResponse(this Agenda agenda) => new()
    {
        Nome = agenda.Nome,
        Contatos = agenda.Contatos.ToResponse(),
        Id = agenda.Id,
        TotalDeContatos = agenda.TotalDeContatos    
    };

    public static IEnumerable<AgendaResponse?> ToResponse(this IEnumerable<Agenda> agendas) =>
        agendas?.Select(a => ToResponse(a)) ?? Enumerable.Empty<AgendaResponse>();
}
