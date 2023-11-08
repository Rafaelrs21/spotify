using Spotify.Domain.Stream.ValueObject;
using System;

namespace Spotify.Domain.Stream.Agreggate;
public class Musica
{
    public string Compositor { get; set; }
    public string NomeMusica { get; set; }
    public Duracao Duracao { get; set; }
    public Album Album { get; set; }
    public List<Playlist> Playlists { get; set; }

    public Musica(string compositor, string nomeMusica)
    {
        Compositor = compositor;
        NomeMusica = nomeMusica;
    }
}