using AgendaProfit.Application.ViewModel.Agenda.Responses;
using AgendaProfit.Application.ViewModel.Contato.Request;
using AgendaProfit.Application.ViewModel.Contato.Responses;
using AgendaProfit.Domain.Entities;

namespace AgendaProfit.Application.Mapper;

public static class ContatoMapper
{
    public static Contato ToEntidade(this CreateContatoRequest request) => new Contato(request.Nome, request.Email, request.Telefone);

    public static ContatoResponse ToResponse(this Contato contato) => new()
    {
        Id = contato.Id,
        Telefone = contato.Telefone,
        Email = contato.Email,
        Nome = contato.Nome,
        AgendaId = contato.AgendaId,
        Descricao = contato.Descricao 

    };

    public static IEnumerable<ContatoResponse> ToResponse(this IEnumerable<Contato> contatos) =>
        contatos?.Select(c => ToResponse(c)) ?? Enumerable.Empty<ContatoResponse>();
}
