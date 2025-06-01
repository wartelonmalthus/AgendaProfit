using AgendaProfit.Application.ViewModel.Usuario.Request;
using AgendaProfit.Application.ViewModel.Usuario.Responses;
using AgendaProfit.Domain.Entities;

namespace AgendaProfit.Application.Mapper;

public static  class UsuarioMapper
{
    public static Usuario ToEntidade(this CreateUsuarioRequest request) => new Usuario(request.Nome, request.Email, request.Telefone, request.Senha);

    public static UsuarioResponse ToResponse(this Usuario usuario) => new()
    {
       Id = usuario.Id,
       Email = usuario.Email,
       Telefone = usuario.Telefone,
       Nome = usuario.Nome,
       Agenda = usuario.Agenda?.ToResponse()

    };
    public static IEnumerable<UsuarioResponse> ToResponse(this IEnumerable<Usuario> usuarios) =>
      usuarios?.Select(u => ToResponse(u)) ?? Enumerable.Empty<UsuarioResponse>();
}
