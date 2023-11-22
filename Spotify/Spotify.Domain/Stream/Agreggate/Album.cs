using System;
namespace Spotify.Domain.Stream.Agreggate;
public class Album
{
    public Guid Id { get; set; }
    public string NomeAlbum { get; set; }
    public List<Musica> ListaMusica { get; set; }
    public Banda Banda { get; set; }

    public Album(){}

    public void CriarAlbum(string nomeAlbum)
    {
        this.NomeAlbum = nomeAlbum;
    }
}