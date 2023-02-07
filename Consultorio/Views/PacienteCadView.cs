using System;

public class PacienteCadView
{
    public bool CadNovoCliente(PacienteDTO pacienteDTO, Consultorio consultorio)
    {
        bool flag = true;
        int tentativas = 0;

        //------------------------------------- Input Nome -------------------------------------\\
        DataOutput.Write("Nome: ");
        pacienteDTO.Nome = DataInput.lerString();

        while (flag)
        {
            if (tentativas >= 3)
            {
                return false;
            }
            if (pacienteDTO.Nome == null)
            {
                DataOutput.Write("\nErro: Nome inválido.\n\nNome: ");
                pacienteDTO.Nome = DataInput.lerString();
            }
            else if (!ValidaDados.VerificaNome(pacienteDTO.Nome))
            {
                DataOutput.Write("\nErro: Nome deve ter apenas letras e pelo menos 5 caracteres.\n\nNome: ");
                pacienteDTO.Nome = DataInput.lerString();
            }
            else
            {
                flag = false;
            } 
            tentativas++;
        }
        //----------------------------------- Fim Input Nome -----------------------------------\\


        //------------------------------------- Input CPF --------------------------------------\\
        DataOutput.Write("CPF: ");
        pacienteDTO.Cpf = DataInput.lerString();
        flag = true;
        tentativas = 0;

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
                Console.Write("\nErro: CPF não é valido. Insira novamente um CPF válido.\n\nCPF: ");
                pacienteDTO.Cpf = DataInput.lerString();
                tentativas++;
            }
            else if (consultorio.VerificaPacienteExiste(pacienteDTO.Cpf))
            {
                DataOutput.WriteLine("\nErro: CPF já cadastrado.");
                return false;
            } 
            else
            {
                flag = false;
            }
        }
        //------------------------------------ Fim Input CPF -----------------------------------\\


        //------------------------------------- Input Nasc -------------------------------------\\
        DataOutput.Write("Data de nascimento DD/MM/AAAA: ");
        pacienteDTO.Nasc = DataInput.lerData();
        flag = true;
        tentativas = 0;

        while (flag)
        {
            if (tentativas >= 3)
            {
                return false;
            }
            if (pacienteDTO.Nasc == DateOnly.MinValue)
            {
                DataOutput.Write("\nErro: Data de nascimento deve ser no formato DD/MM/AAAA.\n\nData de nascimento DD/MM/AAAA: ");
                pacienteDTO.Nasc = DataInput.lerData();
                tentativas++;
            }
            else if (ValidaDados.VerificaIdade(pacienteDTO.Nasc))
            {
                DataOutput.WriteLine("\nErro: Paciente deve ter pelo menos 13 anos.");
                return false;
            }
            else
            {
                flag = false;
            }
        }
        //----------------------------------- Fim Input Nasc -----------------------------------\\

        return true;
    }
}
