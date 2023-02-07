using System;

public class ListagemPacienteView
{

    public void ListarOrdenado(List<Paciente> pcts)
	{

        if (pcts.Count == 0)
        {
            Console.WriteLine("Consultório ainda não possui pacientes cadastrados."); 
            Thread.Sleep(1000);
        }
        else
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("{0,-12}{1,-30}{2,-11}{3}", "CPF", "Nome", "Dt.Nasc", "Idade");
            Console.WriteLine("----------------------------------------------------------");
            foreach (var paciente in pcts)
            {
                if (paciente.Agendamentos.Count > 0)
                {
                    foreach (var agenda in paciente.Agendamentos)
                    {
                        if (agenda.DataConsulta >= DateOnly.FromDateTime(DateTime.Now))
                        {
                            Console.WriteLine("{0,-12}{1,-30}{2,-14}{3}", paciente.Cpf, paciente.Nome, paciente.DataNasc.ToString("dd/MM/yyyy"), (DateTime.Now.Year - paciente.DataNasc.Year));
                            Console.WriteLine("{0,27}{1}", "Agendado para: ", agenda.DataConsulta.ToString("dd/MM/yyyy"));
                            Console.WriteLine("{0,17} às {1}", agenda.HoraInicial.ToString("hh\\:mm"), agenda.HoraFinal.ToString("hh\\:mm"));

                        }
                        else
                        {
                            Console.WriteLine("{0,-12}{1,-30}{2,-14}{3}", paciente.Cpf, paciente.Nome, paciente.DataNasc.ToString("dd/MM/yyyy"), (DateTime.Now.Year - paciente.DataNasc.Year));
                        }
                    }
                }
                else
                {
                    Console.WriteLine("{0,-12}{1,-30}{2,-14}{3}", paciente.Cpf, paciente.Nome, paciente.DataNasc.ToString("dd/MM/yyyy"), (DateTime.Now.Year - paciente.DataNasc.Year));
                }

        }
         Console.WriteLine("----------------------------------------------------------");
         Console.WriteLine();
         Console.WriteLine("Pressione qualquer tecla para continuar.");
         Console.ReadKey();
        }
    }
}
