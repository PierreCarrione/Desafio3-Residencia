using System;

public class AgendamentoDTO
{
    public string Cpf { get; set; }
    public DateOnly Data { get; set; }
    public TimeSpan HoraInicial { get; set; }
    public TimeSpan HoraFinal { get; set; }


    //Conversão dos dados validados para o tipo Agendamento
    public Agendamento ParseToAgendamento()
    {
        Agendamento aux = new Agendamento(Cpf, Data, HoraInicial, HoraFinal);
        return aux;
    }

    public Agendamento ParseToAgendamentoSemFinal()
    {
        Agendamento aux = new Agendamento(Cpf, Data, HoraInicial, TimeSpan.MinValue);
        return aux;
    }
}
