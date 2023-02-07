using System;
using System.Text.RegularExpressions;

public class DataInput
{

    public static string lerString()
	{
        var data = Console.ReadLine();

        if (data.Length != 0)
        {
            return data;
        }
        return null; 
    }

	public static long lerInteiro()
	{
        var data = Console.ReadLine().Trim();

        try
        {
            return long.Parse(data);
        }
        catch (Exception)
        {
            //DataOutput.WriteLine(errorMsg);
        }

        return -1;
    }

    public static DateOnly lerData()
    {
        var data = Console.ReadLine().Trim();

        try
        {
            return DateOnly.ParseExact(data, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
        }
        catch (Exception)
        {
            //DataOutput.WriteLine("Erro: Data deve ser no formato DD/MM/AAAA");
        }
        return DateOnly.MinValue;
    }

    public static TimeSpan lerHora()
    {
        var data = Console.ReadLine().Trim();

        if (Regex.IsMatch(data, @"^\d{4}$"))
        {
            var aux = int.Parse(data);
            return new TimeSpan(aux / 100, aux % 100, 00); ;
        }

        return TimeSpan.MinValue;
    }
}
