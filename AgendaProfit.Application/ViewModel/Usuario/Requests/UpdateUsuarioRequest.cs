using System.ComponentModel.DataAnnotations;

namespace AgendaProfit.Application.ViewModel.Usuario.Request;

public class UpdateUsuarioRequest
{
    [Required(ErrorMessage = "O Id é obrigatório.")]
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }
    public int? AgendaId { get; set; }
}
