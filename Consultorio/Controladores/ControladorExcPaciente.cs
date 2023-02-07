using System;

public class ControladorExcPaciente
{
	public void Run(Consultorio consultorio)
	{
        var cadView = new PacienteExcView();
        var pctDTO = new PacienteDTO();
        bool aux = cadView.ExcluirPaciente(pctDTO, consultorio);

        if (aux)
        {
            Console.WriteLine("\nPaciente excluído com sucesso!");
            consultorio.RemoverPaciente(pctDTO.ParseToPaciente());
            Thread.Sleep(2000);
        }
        else
        {
            Thread.Sleep(2000);
        }
    }
}
