using System.ComponentModel.DataAnnotations;

namespace AgendaProfit.Application.ViewModel.Usuario.Request;

public class CreateUsuarioRequest
{
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [StringLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo Email é obrigatório.")]
    [EmailAddress(ErrorMessage = "O Email informado não é válido.")]
    [StringLength(150, ErrorMessage = "O Email deve ter no máximo 150 caracteres.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
    [RegularExpression(@"^\d{2}9\d{8}$", ErrorMessage = "O Telefone deve conter DDD + número, ex: 81984422062.")]
    public string Telefone { get; set; }

    [Required(ErrorMessage = "O campo Senha é obrigatório.")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "A Senha deve ter no mínimo 6 caracteres.")]
    [DataType(DataType.Password)]
    public string Senha { get; set; }

    [Required(ErrorMessage = "O campo AgendaId é obrigatório.")]
    public int AgendaId { get; set; }
}
