using System;
namespace Spotify.Domain;
public class Playlist
{
	public string Nomeplaylist { get; set; }
	public List<Musica> ListaMusica { get; set; }

	public Playlist(string nomeplaylist, List<Musica> listaMusica)
	{
		Nomeplaylist = nomeplaylist;
		ListaMusica = listaMusica;
	}
}