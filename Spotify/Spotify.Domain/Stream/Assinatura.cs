﻿using System;

public class Assinatura
{
	public string NomeAssinatura { get; set; }
	public string NivelAssinatura { get; set; }
	public string TempoAssinatura { get; set; }

	public Assinatura(string nomeAssinatura, string nivelAssinatura, string tempoAssinatura)
	{
		NomeAssinatura = nomeAssinatura;
		NivelAssinatura = nivelAssinatura;
		TempoAssinatura = tempoAssinatura;
	}
}