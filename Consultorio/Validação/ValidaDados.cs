using System;
using System.Text.RegularExpressions;

public class ValidaDados
{
    private static TimeSpan horaAbertura = new TimeSpan(08, 00, 00);
    private static TimeSpan horaFechamento = new TimeSpan(19, 00, 00);


    public static bool VerificaCpf(string cpf)
    {

        if (!Regex.IsMatch(cpf, @"^\d{11}$"))
        {
            return false;
        }

        int freq = cpf.Count(f => (f == cpf[0]));
        int dvJ = int.Parse(cpf[0].ToString()) * 10 + int.Parse(cpf[1].ToString()) * 9 +
            int.Parse(cpf[2].ToString()) * 8 + int.Parse(cpf[3].ToString()) * 7 +
            int.Parse(cpf[4].ToString()) * 6 + int.Parse(cpf[5].ToString()) * 5 +
            int.Parse(cpf[6].ToString()) * 4 + int.Parse(cpf[7].ToString()) * 3 + int.Parse(cpf[8].ToString()) * 2;
        int dvK = int.Parse(cpf[0].ToString()) * 11 + int.Parse(cpf[1].ToString()) * 10 +
            int.Parse(cpf[2].ToString()) * 9 + int.Parse(cpf[3].ToString()) * 8 +
            int.Parse(cpf[4].ToString()) * 7 + int.Parse(cpf[5].ToString()) * 6 +
            int.Parse(cpf[6].ToString()) * 5 + int.Parse(cpf[7].ToString()) * 4 +
            int.Parse(cpf[8].ToString()) * 3 + int.Parse(cpf[9].ToString()) * 2;

        //Se cpf for com todos os numeros iguais ou de tamanho diferente de 11
        if (cpf.ToString().Length != 11 || freq == 11)
        {
            return false;
        }
        //Verifica se o digito J ou K para o resto da divisão entre 0 e 1 é diferente de 0.
        if (((dvJ % 11 == 0 || dvJ % 11 == 1) && int.Parse(cpf[9].ToString()) != 0) || ((dvK % 11 == 0 || dvK % 11 == 1) && int.Parse(cpf[10].ToString()) != 0))
        {
            return false;
        }
        //Verifica se o resto da divisão está entre 2 a 10 e se o valor J ou K é igual a 11-resto
        if ((dvJ % 11 > 10 || dvJ % 11 < 0) || (dvK % 11 > 10 || dvK % 11 < 0) || (11 - dvJ % 11 != int.Parse(cpf[9].ToString())) || (11 - dvK % 11 != int.Parse(cpf[10].ToString())))
        {
            return false;
        }

        return true;
    }

    public static bool VerificaNome(string nome)
    {
        return Regex.IsMatch(nome, @"^([A-Z]|[a-z]){5,}(\s?([A-Z]|[a-z]))*$");
    }

    public static bool VerificaIdade(DateOnly data)
    {
        return ((DateOnly.FromDateTime(DateTime.Now).DayNumber - data.DayNumber) / 365 < 13);
    }

    public static bool ValidaHoraIni(TimeSpan horaIni)
    {
        if (horaIni.Hours >= horaAbertura.Hours && horaIni.Hours < horaFechamento.Hours)
        {
            if (horaIni.Minutes == 00 || horaIni.Minutes == 30 || horaIni.Minutes == 15 || horaIni.Minutes == 45)
            {
                return true;
            }
        }

        return false;
    }

    public static bool ValidaHoraFim(TimeSpan horaIni, TimeSpan horaFim)
    {
        if (horaFim.Hours >= horaAbertura.Hours && horaFim.Hours <= horaFechamento.Hours)
        {
            if (horaFim.Hours == 19)
            {
                if (horaFim.Minutes == 0)
                {
                    return true;
                }
            }
            else if (horaFim > horaIni)
            {
                return true;
            }
        }

        return false;
    }

    public static bool VerificaData(DateOnly data)
    {
        return data >= DateOnly.FromDateTime(DateTime.Now);
    }
}
