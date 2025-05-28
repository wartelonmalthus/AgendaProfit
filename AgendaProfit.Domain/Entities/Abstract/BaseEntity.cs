namespace AgendaProfit.Domain.Entities;

public abstract class BaseEntity
{
    public int Id { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public DateTime? DataAlteracao { get; private set; }
    public bool DelecaoLogica { get; private set; }

    protected BaseEntity()
    {
        DataCriacao = DateTime.Now;
        DelecaoLogica = false;
    }

    public void AdicionarDataDeAtualizacao(DateTime updateDate)
    {
        DataAlteracao = updateDate;
    }

    public void DeletarEntidade()
    {
        DelecaoLogica = true;
    }
}
