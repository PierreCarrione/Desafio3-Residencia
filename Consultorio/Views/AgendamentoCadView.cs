using System;


public class AgendamentoCadView
{

    public bool CadNovoAgendamento(AgendamentoDTO agendamentoDTO, Consultorio consultorio)
    {
        bool flag = true;
        int tentativas = 0;

        //------------------------------------- Input CPF --------------------------------------\\
        DataOutput.Write("CPF: ");
        agendamentoDTO.Cpf = DataInput.lerString();

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
                tentativas++;
            }
            else if (!ValidaDados.VerificaCpf(agendamentoDTO.Cpf))
            {
                DataOutput.Write("\nErro: CPF não é valido. Insira novamente um CPF válido.\n\nCPF: ");
                agendamentoDTO.Cpf = DataInput.lerString();
                tentativas++;
            }
            else if (!consultorio.VerificaPacienteExiste(agendamentoDTO.Cpf))
            {
                DataOutput.WriteLine("\nErro: Paciente não cadastrado.");
                return false;
            }
            else if (consultorio.ObterPaciente(agendamentoDTO.Cpf).VerificaConsultaFutura())
            {
                Console.WriteLine("\nErro: Já existe uma consulta futura agendada para esse paciente.");
                return false;
            }
            else
            {
                flag = false;
            }

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
                DataOutput.Write("Erro: Data da consulta deve ser no formato DD/MM/AAAA.\n\nData da consulta DD/MM/AAAA: ");
                agendamentoDTO.Data = DataInput.lerData();
            }
            else if (!ValidaDados.VerificaData(agendamentoDTO.Data))
            {
                DataOutput.Write("Erro: Data da consulta deve ser maior ou igual a data atual.\n\nData da consulta DD/MM/AAAA: ");
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
                DataOutput.Write("Erro: Hora deve estar no formato HHMM e os minutos aceitos são: 00, 15, 30, 45.\n\nHora inicial HHMM: ");
                agendamentoDTO.HoraInicial = DataInput.lerHora();
            }
            else if (!ValidaDados.ValidaHoraIni(agendamentoDTO.HoraInicial))
            {
                DataOutput.Write("Erro: Hora deve estar entre 08 e 19 e os minutos aceitos são: 00, 15, 30, 45.\n\nHora inicial HHMM: ");
                agendamentoDTO.HoraInicial = DataInput.lerHora();
            }
            else if (consultorio.VerificaHoraIniDisp(agendamentoDTO.ParseToAgendamento()))
            {
                DataOutput.Write("Erro: Hora inicial em conflito com um agendamento existente.\n\nHora inicial HHMM: ");
                agendamentoDTO.HoraInicial = DataInput.lerHora();
            }
            else
            {
                flag = false;
            }
            tentativas++;
        }
        //------------------------------- Fim Input Hora Inicial -------------------------------\\


        //---------------------------------- Input Hora Final ----------------------------------\\
        DataOutput.Write("Hora final HHMM: ");
        agendamentoDTO.HoraFinal = DataInput.lerHora();
        flag = true;
        tentativas = 0;

        while (flag)
        {
            if (tentativas >= 3)
            {
                return false;
            }
            if (agendamentoDTO.HoraFinal == TimeSpan.MinValue)
            {
                DataOutput.Write("Erro: Hora deve estar no formato HHMM e os minutos aceitos são: 00, 15, 30, 45.\n\nHora final HHMM: ");
                agendamentoDTO.HoraFinal = DataInput.lerHora();
            }
            else if (!ValidaDados.ValidaHoraFim(agendamentoDTO.HoraInicial, agendamentoDTO.HoraFinal))
            {
                DataOutput.Write("Erro: Hora deve estar entre 08 e 19 e os minutos aceitos são: 00, 15, 30, 45.\n\nHora final HHMM: ");
                agendamentoDTO.HoraFinal = DataInput.lerHora();
            }
            else if (consultorio.VerificaHoraFimDisp(agendamentoDTO.ParseToAgendamento()))
            {
                DataOutput.Write("Erro: Hora final em conflito com um agendamento existente.\n\nHora final HHMM: ");
                agendamentoDTO.HoraFinal = DataInput.lerHora();
            }
            else
            {
                flag = false;
            }
            tentativas++;
        }
        //-------------------------------- Fim Input Hora Final --------------------------------\\

        return true;
    }
}
