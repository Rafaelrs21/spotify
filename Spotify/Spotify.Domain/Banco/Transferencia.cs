﻿using System;
namespace Spotify.Domain;
public class Transferencia
{
	public bool Autorizacao { get; set; }
	public string AvisoConfirmacao { get; set; }
	public string TempoTransacao { get; set; }
	public float Valor { get; set; }

	public Transferencia(bool autorizacao, string avisoConfirmacao, string tempoTransacao, float valor)
	{
		Autorizacao = autorizacao;
		AvisoConfirmacao = avisoConfirmacao;
		TempoTransacao = tempoTransacao;
		Valor = valor;
	}

	public void VerificarLimite()
	{
		Console.WriteLine("Limite:........");
	}
	public void VerificarLimiteCartao()
	{
		Console.WriteLine("Limite do cartão:........");
	}
	public void VerificarTempo()
	{
		Console.WriteLine("Tempo de transação:........");
	}
	public void EnviarNotificacao()
	{
		Console.WriteLine("Notificação:........");
	}
}