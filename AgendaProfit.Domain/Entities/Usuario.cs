using AgendaProfit.Domain.Abstract;

namespace AgendaProfit.Domain.Entities;

public class Usuario : ContatoBase
{
    public string Senha { get; private set; }
    public int AgendaId { get; private set; }
    public Agenda? Agenda { get; private set; }

    public Usuario(string nome, string email, string telefone, string senha, int agendaId)
    {

        Senha = senha;
        AgendaId = agendaId;
        AlterarDados(nome, email, telefone);
    }

    public void VincularAgenda(int agendaId)
    {
        AgendaId = agendaId;
    }
}
