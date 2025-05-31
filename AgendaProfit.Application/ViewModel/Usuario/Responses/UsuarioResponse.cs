using AgendaProfit.Application.ViewModel.Agenda.Responses;

namespace AgendaProfit.Application.ViewModel.Usuario.Responses;

public class UsuarioResponse
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public AgendaResponse? Agenda { get; set; }

}
