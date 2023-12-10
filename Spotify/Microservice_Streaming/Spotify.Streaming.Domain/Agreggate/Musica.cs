using Spotify.Streaming.Domain.Stream.ValueObject;


namespace Spotify.Streaming.Domain.Stream.Agreggate;
public class Musica
{
    public Guid Id { get; set; }
    public string Compositor { get; set; }
    public string NomeMusica { get; set; }
    public Duracao Duracao { get; set; }
    public Album Album { get; set; }
}