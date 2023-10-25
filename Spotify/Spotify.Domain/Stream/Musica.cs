using System;
namespace Spotify.Domain;
public class Musica
{
	public string Compositor { get; set; }
	public string NomeMusica { get; set; }

	public Musica(string compositor, string nomeMusica)
	{
		Compositor = compositor;
		NomeMusica = nomeMusica;
	}
}