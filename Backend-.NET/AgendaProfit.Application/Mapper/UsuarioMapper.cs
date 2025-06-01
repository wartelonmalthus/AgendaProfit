using AgendaProfit.Application.ViewModel.Usuario.Request;
using AgendaProfit.Application.ViewModel.Usuario.Responses;
using AgendaProfit.Domain.Entities;

namespace AgendaProfit.Application.Mapper;

public static  class UsuarioMapper
{
    public static Usuario ToEntidade(this CreateUsuarioRequest request) => new Usuario(request.Nome, request.Email, request.Telefone, request.Senha, request.AgendaId);

    public static UsuarioResponse? ToResponse(this Usuario? usuario)
    {
        if (usuario == null)
            return null;

        return new UsuarioResponse
        {
            Id = usuario.Id != 0 ? usuario.Id : null, 
            Email = string.IsNullOrWhiteSpace(usuario.Email) ? null : usuario.Email,
            Telefone = string.IsNullOrWhiteSpace(usuario.Telefone) ? null : usuario.Telefone,
            Nome = string.IsNullOrWhiteSpace(usuario.Nome) ? null : usuario.Nome,
            Agenda = usuario.Agenda?.ToResponse()
        };
    }
    public static IEnumerable<UsuarioResponse> ToResponse(this IEnumerable<Usuario> usuarios) =>
      usuarios?.Select(u => ToResponse(u)) ?? Enumerable.Empty<UsuarioResponse>();
}
