using System.ComponentModel.DataAnnotations;

namespace AgendaProfit.Application.ViewModel.Agenda.Request;

public class CreateAgendaRequest
{
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [StringLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres.")]
    public string Nome { get; set; }
}
