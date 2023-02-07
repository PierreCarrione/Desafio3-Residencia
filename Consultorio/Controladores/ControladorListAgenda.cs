using System;
using System.Text.RegularExpressions;

public class ControladorListAgenda
{
	public bool Run(Consultorio consultorio)
	{
        var view = new View();
        var agdView = new ListagemAgendaView();
        var agdDAO = new AgendaDAO();
        var pctDAO = new PacienteDAO();
        var answer = view.MenuListAgenda();

        if (Regex.IsMatch(answer, @"^[Tt]$"))
        {
            Console.Clear();
            agdView.ListarAgenda(consultorio.ObterAgenda(),consultorio.ObterPacientes());
            return true;
        }
        else if (Regex.IsMatch(answer, @"^[pP]$"))
        {
            bool flag = true;
            int tentativas = 0;
            DateOnly dataIni;
            DateOnly dataFim;

            DataOutput.Write("Data inicial DD/MM/AAAA: ");
            dataIni = DataInput.lerData();

            while (flag)
            {
                if (tentativas >= 3)
                {
                    return false;
                }
                if (dataIni == DateOnly.MinValue)
                {
                    DataOutput.Write("Erro: Data deve ser no formato DD/MM/AAAA.\n\nData inicial DD/MM/AAAA: ");
                    dataIni = DataInput.lerData();
                    tentativas++;
                }
                else
                {
                    flag = false;
                }
            }

            flag = true;
            tentativas = 0;
            DataOutput.Write("Data final DD/MM/AAAA: ");
            dataFim = DataInput.lerData();

            while (flag)
            {
                if (tentativas >= 3)
                {
                    return false;
                }
                if (dataFim == DateOnly.MinValue)
                {
                    DataOutput.Write("Erro: Data deve ser no formato DD/MM/AAAA.\n\nData final DD/MM/AAAA: ");
                    dataFim = DataInput.lerData();
                }
                else if (dataIni > dataFim)
                {
                    DataOutput.Write("Data final tem que ser maior que data inicial.\nData final: ");
                    dataFim = DataInput.lerData();
                }
                else
                {
                    flag = false;
                }
                tentativas++;
            }

            var dataEspecifica = consultorio.ObterAgenda().Where(x => x.DataConsulta >= dataIni && x.DataConsulta <= dataFim);
            Console.Clear();

            if (dataEspecifica.ToList().Count == 0)
            {
                Console.WriteLine("Não foram encontrados agendamentos nesse período.");
                Thread.Sleep(2000);
            }
            else
            {
                Console.Clear();
                agdView.ListarAgenda(dataEspecifica.ToList(), consultorio.ObterPacientes());
                return true;
            }
        }
        return false;
    }
}
