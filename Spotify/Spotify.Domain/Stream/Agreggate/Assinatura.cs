using Spotify.Domain.Stream.Agreggate;
using System;

public class Assinatura
{
	public Guid Id { get; set; }
	public string NomeAssinatura { get; set; }
	public string NivelAssinatura { get; set; }
	public DateTime TempoAssinatura { get; set; }
    public Boolean AssinaturaAtiva { get; set; }
	public Plano Plano { get; set; }

}