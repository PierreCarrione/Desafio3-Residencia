using System;

public class PacienteDTO
{
    public string Cpf { get; set; }
    public string Nome { get; set; }
    public DateOnly Nasc { get; set; }


    //Conversão dos dados validados para o tipo Paciente
    public Paciente ParseToPaciente()
    {
        Paciente aux = new Paciente(Cpf, Nome, Nasc);
        return aux;
    }
}
