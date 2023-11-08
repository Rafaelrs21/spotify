using Spotify.Domain.Banco.Agreggate;
using System;

namespace Spotify.Domain.Stream.Agreggate;
public class Playlist
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public Boolean Publica { get; set; }
    public Usuario Conta { get; set; }
    public string Nomeplaylist { get; set; }
    public List<Musica> ListaMusica { get; set; }

    public Playlist()
    {
        this.ListaMusica = new List<Musica>();
    }
}