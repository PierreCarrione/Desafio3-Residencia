using System;
using System.ComponentModel.DataAnnotations;

public abstract class Pessoa
{
	[Key] public string Cpf { get; private set; }
	public string Nome { get; private set; }
	public DateOnly DataNasc { get; private set; }

	public Pessoa(){}	

	public Pessoa(string cpf, string nome, DateOnly dataNasc)
	{
		Cpf = cpf;
		Nome = nome;
		DataNasc = dataNasc;	
	}
}
