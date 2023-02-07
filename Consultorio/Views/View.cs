using System;
using System.Text.RegularExpressions;


public class View
{

	public string MenuPrincipal()
	{
        string flag = "0";

        while (!Regex.IsMatch(flag, @"^[123]$"))
        {
            Console.Title = "Consultório";
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            DataOutput.WriteLine("Menu Principal\n1-Cadastro de pacientes\n2-Agenda\n3-Fim");
            DataOutput.Write("Opção: ");
            flag = DataInput.lerString();

            if (!Regex.IsMatch(flag, @"^[123]$"))
            {
                Console.Clear();
                DataOutput.WriteLine("Valor digitado não é uma opção válida");
                Thread.Sleep(2000);
                Console.Clear();
            }
        }
        return flag;
	}

    public string MenuCadPaciente()
    {
        string flag = "0";
        
        while (!Regex.IsMatch(flag, @"^[12345]$"))
        {
            DataOutput.WriteLine("Menu do Cadastro de Pacientes\n1-Cadastrar novo paciente\n2-Excluir paciente\n3-Listar pacientes (ordenado por CPF)" +
                "\n4-Listar pacientes (ordenado por nome)\n5-Voltar p/ menu principal");
            DataOutput.Write("Opção: ");
            flag = DataInput.lerString();

            if (!Regex.IsMatch(flag, @"^[12345]$"))
            {
                Console.Clear();
                DataOutput.WriteLine("Valor digitado não é uma opção válida");
                Thread.Sleep(2000);
                Console.Clear();
            }
        }
        return flag;
    }

    public string MenuAgenda()
    {
        string flag = "0";

        while (!Regex.IsMatch(flag, @"^[1234]$"))
        {
            DataOutput.WriteLine("Agenda\n1-Agendar consulta\n2-Cancelar agendamento\n3-Listar agenda" +
                "\n4-Voltar p/ menu principal");
            DataOutput.Write("Opção: ");
            flag = DataInput.lerString();

            if (!Regex.IsMatch(flag, @"^[12345]$"))
            {
                Console.Clear();
                DataOutput.WriteLine("Valor digitado não é uma opção válida");
                Thread.Sleep(2000);
                Console.Clear();
            }
        }
        return flag;
    }

    public string MenuListAgenda()
    {
        string flag = "0";
        int tentativas = 0;

        DataOutput.Write("Apresentar a agenda T-Toda ou P-Periodo: ");
        DataOutput.Write("Opção: ");
        flag = DataInput.lerString();

        while (!Regex.IsMatch(flag, @"^[TtPp]$") && tentativas < 3)
        {
            if (!Regex.IsMatch(flag, @"^[TtPp]$"))
            {
                Console.Clear();
                DataOutput.WriteLine("Opção digitada inválida, digite novamente T ou P.");
                Thread.Sleep(2000);
                Console.Clear();
                DataOutput.Write("Apresentar a agenda T-Toda ou P-Periodo: ");
                flag = DataInput.lerString();
                tentativas++;
            }
        }
        return flag;
    }
}
