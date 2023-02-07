public class AgendaDAO
{
    private ConsultorioContext contexto;

    public AgendaDAO()
    {
        contexto = new ConsultorioContext();
    }

    public void CadastrarConsulta(Agendamento consulta)
    {
        contexto.Add(consulta);
        contexto.SaveChanges();
    }

    public void ExcluirConsulta(Agendamento consulta)
    {
        var consultaExcluida = contexto.Agendamentos.First(c => c.Equals(consulta));
        contexto.Agendamentos.Remove(consultaExcluida);
        contexto.SaveChanges();
    }

    public List<Agendamento> RecuperarAgendamentos()
    {
        return contexto.Agendamentos.ToList();
    }
}
