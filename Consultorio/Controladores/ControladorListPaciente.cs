using System;

public class ControladorListPaciente
{
	public void Run(string resp, Consultorio consultorio)
	{
		var listPacView = new ListagemPacienteView();
		var pacDAO = new PacienteDAO();

		if (resp.Equals("3"))
		{
            listPacView.ListarOrdenado(consultorio.ObterPacientes().OrderBy(x => x.Cpf).ToList());
        }
		else
		{
            listPacView.ListarOrdenado(consultorio.ObterPacientes().OrderBy(x => x.Nome).ToList());
        }
	}
}
