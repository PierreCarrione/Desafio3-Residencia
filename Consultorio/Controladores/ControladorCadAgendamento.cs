using System;

public class ControladorCadAgendamento
{
	public void Run(Consultorio consultorio)
	{
        var cadView = new AgendamentoCadView();
        var agdDTO = new AgendamentoDTO();
        bool aux = cadView.CadNovoAgendamento(agdDTO, consultorio);

        if (aux)
        {
            Console.WriteLine("\nAgendamento realizado com sucesso!");
            consultorio.AdicionarAgendamento(agdDTO.ParseToAgendamento());
            Thread.Sleep(2000);
        }
        else
        {
            Thread.Sleep(1000);
        }

    }
}
