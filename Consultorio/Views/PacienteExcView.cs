using System;

public class PacienteExcView
{

    public bool ExcluirPaciente(PacienteDTO pacienteDTO, Consultorio consultorio)
    {
        bool flag;
        int tentativas = 0;
        DataOutput.Write("CPF: ");
        pacienteDTO.Cpf = DataInput.lerString();
        flag = true;

        while (flag)
        {
            if (tentativas >= 3)
            {
                return false;
            }
            if (pacienteDTO.Cpf == null) 
            {
                DataOutput.Write("\nErro: CPF não é valido. Insira novamente um CPF válido.\n\nCPF: ");
                pacienteDTO.Cpf = DataInput.lerString();
                tentativas++;
            }
            else if (!ValidaDados.VerificaCpf(pacienteDTO.Cpf))
            {
                DataOutput.Write("\nErro: CPF não é valido. Insira novamente um CPF válido.\n\nCPF: ");
                pacienteDTO.Cpf = DataInput.lerString();
                tentativas++;
            }
            else if (!consultorio.VerificaPacienteExiste(pacienteDTO.Cpf))
            {
                DataOutput.WriteLine("\nErro: Paciente não cadastrado.");
                return false;
            }
            else if (consultorio.ObterPaciente(pacienteDTO.Cpf).VerificaConsultaFutura())
            {
                DataOutput.WriteLine("\nErro: Paciente possui uma consulta agendada.");
                return false;
            }
            else
            {
                flag = false;
            }
        }

        return true;
    }
}
