using System;
using System.Text.Json.Serialization;

namespace Spotify.Streaming.Domain.Stream.Agreggate;
public class Plano
{
    public Guid Id { get; set; }
   
    public string NomePlano { get; set; }
   
    public string NivelPlano { get; set; }
    
    public Decimal ValorPlano { get; set; }
}