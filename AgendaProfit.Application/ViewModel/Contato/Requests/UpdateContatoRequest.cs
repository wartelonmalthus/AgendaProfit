using System.ComponentModel.DataAnnotations;

namespace AgendaProfit.Application.ViewModel.Contato.Request;

public class UpdateContatoRequest
{
    [Required(ErrorMessage = "O Id é obrigatório.")]
    public int Id { get; set; }
    public string? Descricao { get; set; }
    public int? AgendaId { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }
}
