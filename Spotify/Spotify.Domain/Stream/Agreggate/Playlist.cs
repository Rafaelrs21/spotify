using Spotify.Domain.Banco.Agreggate;
using System;

namespace Spotify.Domain.Stream.Agreggate;
public class Playlist
{
    public Guid Id { get; set; }
    public string Nomeplaylist { get; set; }
    public Boolean Publica { get; set; }
    public Usuario Conta { get; set; }
    public List<Musica> ListaMusica { get; set; }

    public Playlist()
    {
        this.ListaMusica = new List<Musica>();
    }

    public void AdicionarMusica(string compositor = "Teste", string nomeMusica = "testando")
    {
        this.ListaMusica.Add(new Musica()
        {
            Id = Guid.NewGuid(),
            Compositor = compositor,
            NomeMusica = nomeMusica,
        });
    }
}