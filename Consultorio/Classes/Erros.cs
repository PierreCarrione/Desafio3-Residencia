using System;


public class Erros
{
    public string campo { get; set; }
    public string valorDigitado { get; set; }

    public Erros(string tipoErro, string mensagem)
    {
        this.campo = tipoErro;
        this.valorDigitado = mensagem;
    }
}
