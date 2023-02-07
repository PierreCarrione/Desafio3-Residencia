using System;

public class Consultorio
{
	private Agenda agenda;
	private List<Paciente> pacientes;
    private PacienteDAO pacienteDAO;
    private AgendaDAO agendaDAO;

	public Consultorio()
	{
        this.pacienteDAO = new PacienteDAO();
        this.agendaDAO = new AgendaDAO();
        InicializarPacientes();
        InicializarAgenda();
    }


    //--------------------------------- Métodos Agendamento ---------------------------------\\

    public void AdicionarAgendamento(Agendamento agendamento)
    {
        agenda.AdicionarAgendamento(agendamento);
        var pac = ObterPaciente(agendamento.PacienteCpf);
        pac.CadastrarAgendamento(agendamento);
        agendaDAO.CadastrarConsulta(agendamento);
    }

    public void RemoverAgendamento(Agendamento agendamento)
    {
        agenda.RemoverAgendamento(agendamento);
        var pac = ObterPaciente(agendamento.PacienteCpf);
        pac.ExcluirAgendamento(agendamento);
        agendaDAO.ExcluirConsulta(agendamento);
    }

    public bool VerificaHoraIniDisp(Agendamento agendamento)
    {
        return agenda.VerificaHoraIniDisp(agendamento);
    }

    public bool VerificaHoraFimDisp(Agendamento agendamento)
    {
        return agenda.VerificaHoraFimDisp(agendamento);
    }

    public bool VerificaAgendamentoExiste(Agendamento agendamento)
    {
        return agenda.VerificaAgendamentoExiste(agendamento);
        //Retorna true se tiver algum agendamento que tenha mesma data e hora inicio
    }

    public List<Agendamento> ObterAgenda()
    {
        return agenda.ObterAgendamentos();
    }

    public Agendamento ObterConsulta(Agendamento agendamento)
    {
        return agenda.ObterAgendamento(agendamento);
    }

    public void InicializarAgenda()
    {
        if (agendaDAO.RecuperarAgendamentos().Count != 0)
        {
            agenda = new Agenda(agendaDAO.RecuperarAgendamentos());
        }
        else
        {
            agenda = new Agenda();
        }
    }

    //------------------------------- Fim Métodos Agendamento -------------------------------\\



    //----------------------------------- Métodos Paciente ----------------------------------\\

    public void CadastrarPaciente(Paciente paciente)
    {
        pacientes.Add(paciente);
        pacienteDAO.CadastrarPaciente(paciente);
    }

    public void RemoverPaciente(Paciente paciente)
    {
        pacientes.Remove(paciente);
        pacienteDAO.RemoverPaciente(paciente);
    }

    public void RemoverPaciente(string cpf)
    {
        var paciente = pacientes.Find(x => x.Cpf == cpf );
        RemoverPaciente(paciente);
    }

    public bool VerificaPacienteExiste(string cpf)
    {
        return pacientes.Any(p => p.Cpf == cpf);
    }

    public bool VerificaPacienteExiste(Paciente paciente)
    {
        return pacientes.Any(p => p == paciente);
    }

    public Paciente ObterPaciente(string cpf)
    {
        return pacientes.Find(x => x.Cpf == cpf);
    }

    public List<Paciente> ObterPacientes()
    {
        return pacientes.ToList();
    }

    public void InicializarPacientes()
    {
        pacientes = pacienteDAO.RecuperarPacientes();

        if (pacientes.Count == 0)
        {
            pacientes = new List<Paciente>();
        }
    }
    //-------------------------------- Fim Métodos Paciente ---------------------------------\\

}