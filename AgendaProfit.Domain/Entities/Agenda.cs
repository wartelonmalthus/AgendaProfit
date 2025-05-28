namespace AgendaProfit.Domain.Entities;

public class Agenda : BaseEntity
{
    public string Nome { get; private set; }
    public int? TotalDeContatos { get; private set; }

    public ICollection<Contato> Contatos { get; private set; } = new List<Contato>();

    public Agenda(string nome)
    {
        Nome = nome;
    }
}
