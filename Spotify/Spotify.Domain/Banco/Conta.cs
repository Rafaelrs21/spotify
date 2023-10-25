﻿using System;
namespace Spotify.Domain;
public class Conta
{
	public int HashID { get; set; }
	public int Agencia { get; set; }
	public int ContaNumero { get; set; }
	public int Saldo { get; set; }
	public string Senha { get; set; }
	public string TipoConta { get; set; }
	public List<Cartao> ListaCartao { get; set; }

	public Conta(int hashID, int agencia, int contaNumero, int saldo, string senha,
	string tipoConta, List<Cartao> listaCartao)
	{
		HashID = hashID;
		Agencia = agencia;
		ContaNumero = contaNumero;
		Saldo = saldo;
		Senha = senha;
		TipoConta = tipoConta;
		ListaCartao = listaCartao;
	}
}