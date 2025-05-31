using System.ComponentModel.DataAnnotations;

namespace AgendaProfit.Application.ViewModel.Agenda.Request;

public class UpdateAgendaRequest
{
    [Required(ErrorMessage = "O Id é obrigatório.")]
    public int Id { get; set; }
    public string? Nome { get; set; }
}
