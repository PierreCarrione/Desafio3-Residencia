using System;

public class ControladorExcAgendamento
{
	public void Run(Consultorio consultorio)
	{
        var excView = new AgendamentoExcView();
        var agdDTO = new AgendamentoDTO();
        bool aux = excView.ExcluirAgendamento(agdDTO, consultorio);

        if (aux)
        {
            Console.WriteLine("\nAgendamento excluído com sucesso!");
            var agd = consultorio.ObterConsulta(agdDTO.ParseToAgendamentoSemFinal());
            consultorio.RemoverAgendamento(agd);
            Thread.Sleep(2000);
        }
        else
        {
            Thread.Sleep(2000);
        }
    }
}
