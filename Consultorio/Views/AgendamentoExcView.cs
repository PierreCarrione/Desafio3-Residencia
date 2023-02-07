using System;


public class AgendamentoExcView
{
    public bool ExcluirAgendamento(AgendamentoDTO agendamentoDTO, Consultorio consultorio)
    {
        bool flag;
        int tentativas = 0;

        //------------------------------------- Input CPF --------------------------------------\\
        DataOutput.Write("CPF: ");
        agendamentoDTO.Cpf = DataInput.lerString();
        flag = true;

        while (flag)
        {
            if (tentativas >= 3)
            {
                return false;
            }
            if (agendamentoDTO.Cpf == null)
            {
                DataOutput.Write("\nErro: CPF não é valido. Insira novamente um CPF válido.\n\nCPF: ");
                agendamentoDTO.Cpf = DataInput.lerString();
            }
            else if (!ValidaDados.VerificaCpf(agendamentoDTO.Cpf))
            {
                DataOutput.Write("\nErro: CPF não é valido. Insira novamente um CPF válido.\n\nCPF: ");
                agendamentoDTO.Cpf = DataInput.lerString();
            }
            else if (!consultorio.VerificaPacienteExiste(agendamentoDTO.Cpf))
            {
                DataOutput.WriteLine("\nErro: Paciente não cadastrado.");
                return false;
            }
            else if (!consultorio.ObterPaciente(agendamentoDTO.Cpf).VerificaConsultaFutura())
            {
                DataOutput.WriteLine("\nErro: Esse paciente não possui consulta futura agendada para cancelar.");
                return false;
            }
            else
            {
                flag = false;
            }
            tentativas++;
        }
        
        //------------------------------------ Fim Input CPF -----------------------------------\\


        //------------------------------------- Input Data -------------------------------------\\
        DataOutput.Write("Data da consulta DD/MM/AAAA: ");
        agendamentoDTO.Data = DataInput.lerData();
        flag = true;
        tentativas = 0;

        while (flag)
        {
            if (tentativas >= 3)
            {
                return false;
            }
            if (agendamentoDTO.Data == DateOnly.MinValue)
            {
                DataOutput.Write("\nErro: Data da consulta deve ser no formato DD/MM/AAAA.\n\nData da consulta DD/MM/AAAA: ");
                agendamentoDTO.Data = DataInput.lerData();
            }
            else if (!consultorio.ObterPaciente(agendamentoDTO.Cpf).VerificaConsultaData(agendamentoDTO.Data))
            {
                DataOutput.Write("\nErro: Esse paciente não possui agendamento nessa data.\n\nData da consulta DD/MM/AAAA: ");
                agendamentoDTO.Data = DataInput.lerData();
            }
            else
            {
                flag = false;
            }
            tentativas++;
        }
        //----------------------------------- Fim Input Data -----------------------------------\\


        //--------------------------------- Input Hora Inicial ---------------------------------\\
        DataOutput.Write("Hora inicial HHMM: ");
        agendamentoDTO.HoraInicial = DataInput.lerHora();
        flag = true;
        tentativas = 0;

        while (flag)
        {
            if (tentativas >= 3)
            {
                return false;
            }
            if (agendamentoDTO.HoraInicial == TimeSpan.MinValue)
            {
                DataOutput.Write("\nErro: Hora deve estar no formato HHMM e os minutos aceitos são: 00, 15, 30, 45.\n\nHora inicial HHMM: ");
                agendamentoDTO.HoraInicial = DataInput.lerHora();
            }
            else if (!ValidaDados.ValidaHoraIni(agendamentoDTO.HoraInicial))
            {
                DataOutput.Write("\nErro: Hora deve estar entre 08 e 19 e os minutos aceitos são: 00, 15, 30, 45.\n\nHora inicial HHMM: ");
                agendamentoDTO.HoraInicial = DataInput.lerHora();
            }
            else if (consultorio.ObterPaciente(agendamentoDTO.Cpf).ObterAgendamento(agendamentoDTO.Data).HoraInicial != agendamentoDTO.HoraInicial)
            {
                DataOutput.Write("\nErro: Paciente não possui consulta nessa hora, entre novamente com a hora correta.\n\nHora inicial HHMM: ");
                agendamentoDTO.HoraInicial = DataInput.lerHora();
            }
            else
            {
                flag = false;
            }
            tentativas++;
        }
        //------------------------------- Fim Input Hora Inicial -------------------------------\\
        return true;
    }
}
