namespace AgendaProfit.Application.ViewModel.Agenda.Request;

public class AgendaFilter
{
    public string? nome { get; set; }
    public int numeroDaPagina { get; set; } = 1;
    public int tamanhoDaPagina { get; set; } = 10;
}
