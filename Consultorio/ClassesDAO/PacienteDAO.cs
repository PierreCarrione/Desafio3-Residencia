public class PacienteDAO
{
    private ConsultorioContext contexto;

    public PacienteDAO()
    {
        contexto = new ConsultorioContext();
    }        

	public void CadastrarPaciente(Paciente pct)
	{
        contexto.Pacientes.Add(pct);
        contexto.SaveChanges();
    }

    public void RemoverPaciente(Paciente pct)
    {
        var pacienteExcluido = contexto.Pacientes.First(p => p.Cpf == pct.Cpf);
        contexto.Pacientes.Remove(pacienteExcluido);
        contexto.SaveChanges();
    }

    public List<Paciente> RecuperarPacientes()
    {
        return contexto.Pacientes.ToList();
    }
}
