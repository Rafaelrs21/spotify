using System;

namespace Spotify.Domain.Stream.Agreggate;
public class Plano
{
    public Guid Id { get; set; }
    public string NomePlano { get; set; }
    public string NivelPlano { get; set; }
    public string PlanoBeneficios { get; set; }
    public string TempoPlano { get; set; }
    public string Descricao { get; set; }
    public Decimal ValorPlano { get; set; }
}