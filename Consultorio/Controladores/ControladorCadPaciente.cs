using System;

public class ControladorCadPaciente
{
	public void Run(Consultorio consultorio)
	{
        var cadView = new PacienteCadView();
        var pctDTO = new PacienteDTO(); 
        bool aux = cadView.CadNovoCliente(pctDTO, consultorio);

        if (aux)
        {
            Console.WriteLine("\nPaciente cadastrado com sucesso!");
            consultorio.CadastrarPaciente(pctDTO.ParseToPaciente());
            Thread.Sleep(2000);
        }
        else
        {
            Thread.Sleep(2000);
        }
    }
}
