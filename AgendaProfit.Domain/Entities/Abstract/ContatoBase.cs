namespace AgendaProfit.Domain.Entities.Abstract;

public abstract class ContatoBase : BaseEntity
{
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Telefone { get; private set; }


    public void AlterarDados(string? nome,  string? email, string? telefone)
    {
       if(nome is not null) 
            Nome = nome;

       if(email is not null) 
            Email = email;

       if(telefone is not null) 
            Telefone = telefone;
    }
}
