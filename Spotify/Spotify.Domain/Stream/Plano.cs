using System;
namespace Spotify.Domain;
public class Plano
{
	public string NomePlano { get; set; }
	public string NivelPlano { get; set; }
	public List<string> PlanoBeneficios { get; set; }
	public string TempoPlano { get; set; }
	public int ValorPlano { get; set; }

	public Plano(string nomePlano, string nivelPlano, List<string> planoBeneficios,
		string tempoPlano, int valorPlano)
	{
		NomePlano = nomePlano;
		NivelPlano = nivelPlano;
		PlanoBeneficios = planoBeneficios;
		TempoPlano = tempoPlano;
		ValorPlano = valorPlano;
	}
}