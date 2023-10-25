﻿using System;
namespace Spotify.Domain;
public class PessoaFisica
{
	public string Nome { get; set; }
	public string Sobrenome { get; set; }
	public string CPF { get; set; }
	public string RG { get; set; }
	public string Telefone { get; set; }
	public string CEP { get; set; }
	public DateTime DataNascimento { get; set; }
	public List<Conta> ListaConta { get; set; }

	public PessoaFisica(string nome, string sobrenome, string cpf, string rg, 
	string telefone, string cep, DateTime dataNascimento, List<Conta> listaConta)
	{
		Nome = nome;
		Sobrenome = sobrenome;
		CPF = cpf;
		RG = rg;
		Telefone = telefone;
		CEP = cep;
		DataNascimento = dataNascimento;
		ListaConta = listaConta;
	}
}