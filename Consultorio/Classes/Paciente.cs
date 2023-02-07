using System;


public class Paciente : Pessoa
{
    private List<Agendamento> agendamentos;

    public Paciente(){ agendamentos = new List<Agendamento>(); }

    public Paciente(string cpf, string nome, DateOnly dataNasc) 
        :base(cpf, nome,dataNasc)
    {
        agendamentos = new List<Agendamento>();
    }

    public List<Agendamento> Agendamentos
    {
        get { return agendamentos.ToList(); }
        private set { agendamentos = value; }
    }

    public override bool Equals(object? obj)
    {
        Paciente pac = obj as Paciente;
        return this.Cpf.Equals(pac.Cpf);
    }


    public bool VerificaConsultaFutura()
    {
        /*DataOutput.WriteLine(agendamentos.Count.ToString());

        for (int i = 0; i < agendamentos.Count; i++)
        {
            DataOutput.WriteLine(agendamentos[i].DataConsulta.ToString());
        }*/
        return agendamentos.Any(x => x.DataConsulta > DateOnly.FromDateTime(DateTime.Now));
    }

    public bool VerificaConsultaData(DateOnly data)
    {
        return agendamentos.Any(x => x.DataConsulta == data);
    }

    public Agendamento ObterAgendamento(DateOnly data)
    {
        return agendamentos.Find(x => x.DataConsulta == data);
    }

    public void CadastrarAgendamento(Agendamento agendamento)
    {
        this.agendamentos.Add(agendamento);
    }

    public void ExcluirAgendamento(Agendamento agendamento)
    {
        agendamentos.Remove(agendamento);
    }
}
