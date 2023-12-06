using Spotify.Streaming.Domain.Stream.ValueObject;


namespace Spotify.Streaming.Domain.Stream.Agreggate;
public class Musica
{
    public Guid Id { get; set; }
    public string Compositor { get; set; }
    public string NomeMusica { get; set; }
    public Duracao Duracao { get; set; }
    public Album Album { get; set; }
   

    public Musica() { }


    public Musica(string compositor, string nomeMusica)
    {
        Compositor = compositor;
        NomeMusica = nomeMusica;
    }


   public void CriarMusica(string compositor, string nomeMusica)
    {
        this.Compositor = compositor;
        this.NomeMusica = nomeMusica;
    }
}