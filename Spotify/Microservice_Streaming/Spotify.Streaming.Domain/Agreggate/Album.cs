using System;
namespace Spotify.Streaming.Domain.Stream.Agreggate;
public class Album
{
    public Guid Id { get; set; }
    public string NomeAlbum { get; set; }
    public List<Musica> ListaMusicas { get; set; }
    public Banda Banda { get; set; }

    public Album()
    {
        this.ListaMusicas = new List<Musica>();
    }

    public void AdicionarMusicas(List<Musica> musicas)
    {
        this.ListaMusicas.AddRange(musicas);
    }

    public void AdicionarMusicas(Musica musicas)
    {
        this.ListaMusicas.Add(musicas);
    }
}