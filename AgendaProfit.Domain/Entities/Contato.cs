﻿using AgendaProfit.Domain.Abstract;

namespace AgendaProfit.Domain.Entities;

public class Contato :  ContatoBase
{
    public string? Descricao { get; private set; }
    public int AgendaId { get; private set; }
    public Agenda? Agenda { get; private set; }

    public Contato(string nome, string email, string telefone, int agendaId)
    {
        AlterarDados(nome, email, telefone);
        AgendaId = agendaId;
    }

    public void AdicionarDescricao(string descricao)
    {
        Descricao = descricao;
    }

    public void VincularAgenda(int agendaId)
    {
        AgendaId = agendaId;
    }

}
