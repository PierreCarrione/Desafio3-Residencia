using System;

public class Agenda
{
	private List<Agendamento> agendamentos;

	public Agenda()
	{
		agendamentos = new List<Agendamento>();
	}

    public Agenda(List<Agendamento> agendamentos)
    {
        this.agendamentos = agendamentos;
    }

	public void AdicionarAgendamento(Agendamento agendamento)
	{
		agendamentos.Add(agendamento);	
	}

	public void RemoverAgendamento(Agendamento agendamento)
	{
        RemoverAgendamento(agendamento.PacienteCpf, agendamento.DataConsulta, agendamento.HoraInicial);
    }

    public void RemoverAgendamento(string cpf, DateOnly data, TimeSpan horaInicial)
    {
		var agendamento = agendamentos.Find(x => x.PacienteCpf == cpf && x.DataConsulta == data && x.HoraInicial == horaInicial);
		agendamentos.Remove(agendamento);
    }

	public bool VerificaAgendamentoExiste(Agendamento agendamento)
	{
        return agendamentos.Any(x => x.DataConsulta == agendamento.DataConsulta && x.HoraInicial == agendamento.HoraInicial);
        //Retorna true se tiver algum agendamento que tenha mesma data e hora inicio
    }

	public bool VerificaConsultaData(Agendamento agendamento)
	{
		return agendamentos.Any(x => x.PacienteCpf == agendamento.PacienteCpf && x.DataConsulta == agendamento.DataConsulta);
	}

    public bool VerificaHoraIniDisp(Agendamento agendamento)
    {
		return agendamentos.Any(x => x.DataConsulta == agendamento.DataConsulta && x.HoraInicial == agendamento.HoraInicial);
		//Retorna true se tiver algum agendamento que tenha mesma data e hora inicio
    }

	public bool VerificaHoraFimDisp(Agendamento agendamento)
	{
		return VerificaAgendamentoExiste(agendamento);
	}

    public Agendamento ObterAgendamento(Agendamento agendamento)
	{
		return agendamentos.Find(x => x.Equals(agendamento));
	}

    public List<Agendamento> ObterAgendamentos()
    {
		return agendamentos.ToList();
    }
}
