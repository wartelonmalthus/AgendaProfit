namespace AgendaProfit.Application.ViewModel.Contato.Request;

public class ContatoFilter
{
    public string? nome { get; set; }    
    public string? email { get; set; }
    public int numeroDaPagina { get; set; } = 1;
    public int tamanhoDaPagina { get; set; } = 10;
}

