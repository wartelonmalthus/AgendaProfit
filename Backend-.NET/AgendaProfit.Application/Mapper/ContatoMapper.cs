using AgendaProfit.Application.ViewModel.Contato.Request;
using AgendaProfit.Application.ViewModel.Contato.Responses;
using AgendaProfit.Domain.Entities;

namespace AgendaProfit.Application.Mapper;

public static class ContatoMapper
{
    public static Contato ToEntidade(this CreateContatoRequest request) => new Contato(request.Nome, request.Email, request.Telefone, request.AgendaId);

    public static ContatoResponse? ToResponse(this Contato? contato)
    {
        if (contato == null)
            return null;

        return new ContatoResponse
        {
            Id = contato.Id != 0 ? contato.Id : null, 
            Telefone = string.IsNullOrWhiteSpace(contato.Telefone) ? null : contato.Telefone,
            Email = string.IsNullOrWhiteSpace(contato.Email) ? null : contato.Email,
            Nome = string.IsNullOrWhiteSpace(contato.Nome) ? null : contato.Nome,
            AgendaId = contato.AgendaId != 0 ? contato.AgendaId : null,
            Descricao = string.IsNullOrWhiteSpace(contato.Descricao) ? null : contato.Descricao
        };
    }

    public static IEnumerable<ContatoResponse> ToResponse(this IEnumerable<Contato> contatos) =>
        contatos?.Select(c => ToResponse(c)) ?? Enumerable.Empty<ContatoResponse>();
}
