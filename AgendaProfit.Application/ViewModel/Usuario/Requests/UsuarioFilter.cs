namespace AgendaProfit.Application.ViewModel.Usuario.Request;

public class UsuarioFilter
{
    public string? nome { get; set; }
    public int numeroDaPagina { get; set; } = 1;
    public int tamanhoDaPagina { get; set; } = 10;
}
