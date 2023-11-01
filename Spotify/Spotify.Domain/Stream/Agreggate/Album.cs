using System;
namespace Spotify.Domain.Stream.Agreggate;
public class Album
{
    public string NomeAlbum { get; set; }
    public List<Musica> ListaMusica { get; set; }
    public Banda Banda { get; set; }

    public Album(string nomeAlbum, List<Musica> listaMusica)
    {
        NomeAlbum = nomeAlbum;
        ListaMusica = listaMusica;
    }
}