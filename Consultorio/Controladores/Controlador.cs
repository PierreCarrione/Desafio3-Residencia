using System;
using System.Text.RegularExpressions;

public class Controlador
{

    public void Run()
    {
        var view = new View();
        var answer = view.MenuPrincipal();
        var ctrlCadAgend = new ControladorCadAgendamento();
        var ctrlCadPac = new ControladorCadPaciente();
        var ctrlExcAgend = new ControladorExcAgendamento();
        var ctrlExcPac = new ControladorExcPaciente();
        var ctrlListAgend = new ControladorListAgenda();
        var ctrlListPac = new ControladorListPaciente();
        var consultorio = new Consultorio();

        while (true)
        {
            if (answer.Equals("1"))
            {
                Console.Clear();
                var answer_1 = view.MenuCadPaciente();

                if (Regex.IsMatch(answer_1, @"^1$"))
                {
                    Console.Clear();
                    ctrlCadPac.Run(consultorio);
                    answer = "1";
                }
                else if (Regex.IsMatch(answer_1, @"^2$"))
                {
                    Console.Clear();
                    ctrlExcPac.Run(consultorio);
                    answer = "1";
                }
                else if (Regex.IsMatch(answer_1, @"^3$"))
                {
                    Console.Clear();
                    ctrlListPac.Run(answer_1, consultorio);
                    answer = "1";
                }
                else if (Regex.IsMatch(answer_1, @"^4$"))
                {
                    Console.Clear();
                    ctrlListPac.Run(answer_1, consultorio);
                    answer = "1";
                }
                else if (Regex.IsMatch(answer_1, @"^5$"))
                {
                    Console.Clear();
                    answer = view.MenuPrincipal();
                }
            }
            else if (answer.Equals("2"))
            {
                Console.Clear();
                var answer_1 = view.MenuAgenda();

                if (Regex.IsMatch(answer_1, @"^1$"))
                {
                    Console.Clear();
                    ctrlCadAgend.Run(consultorio);
                    answer = "2";
                }
                else if (Regex.IsMatch(answer_1, @"^2$"))
                {
                    Console.Clear();
                    ctrlExcAgend.Run(consultorio);
                    answer = "2";
                }
                else if (Regex.IsMatch(answer_1, @"^3$"))
                {
                    Console.Clear();
                    ctrlListAgend.Run(consultorio);
                    answer = "2";
                }
                else if (Regex.IsMatch(answer_1, @"^4$"))
                {
                    Console.Clear();
                    answer = view.MenuPrincipal();
                }
            }
            else
            {
                Console.Clear();
                DataOutput.Write("Fechando aplicação");
                Thread.Sleep(1000);
                DataOutput.Write(" .");
                Thread.Sleep(1000);
                DataOutput.Write(" .");
                Thread.Sleep(1000);
                DataOutput.Write(" .");
                Thread.Sleep(1000);
                Environment.Exit(0);
            }
        }
    }
}