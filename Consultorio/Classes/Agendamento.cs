using System;

public class Agendamento
{
    public int Id { get; private set; }
    public string PacienteCpf { get; private set; }
    public DateOnly DataConsulta { get; private set; }	
    public TimeSpan HoraInicial { get; private set; }
    public TimeSpan HoraFinal { get; private set; }

    public Agendamento(){}

    public Agendamento(string cpf, DateOnly dataConsulta, TimeSpan horaInicial, TimeSpan horaFinal)
    {
        PacienteCpf = cpf;
        DataConsulta = dataConsulta;
        HoraInicial = horaInicial;  
        HoraFinal = horaFinal;
    }

    public override bool Equals(object? obj)
    {
        Agendamento aux = obj as Agendamento;
        if (this.PacienteCpf == aux.PacienteCpf && 
            this.DataConsulta == aux.DataConsulta && 
            this.HoraInicial == aux.HoraInicial)
        {
            return true;
        }
        return false;
    }
}
