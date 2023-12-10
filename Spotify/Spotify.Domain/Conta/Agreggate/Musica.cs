using System.Text.Json.Serialization;

namespace Spotify.Streaming.Domain.Stream.Agreggate
{
public class Musica
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("NomeMusica")]
    public string NomeMusica { get; set; }
    [JsonPropertyName("Compositor")]
    public string Compositor { get; set; }
    [JsonPropertyName("duracao")]
    public int Duracao { get; set; }
    }
}