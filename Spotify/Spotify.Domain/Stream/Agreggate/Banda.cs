

namespace Spotify.Domain.Stream.Agreggate;
public class Banda
{
    public Guid Id { get; set; }
    public string NomeBanda { get; set; }
    public string EstiloMusica { get; set; }
    public List<Album> ListaAlbum { get; set; }

    public Banda()
    {
        this.ListaAlbum = new List<Album>();
    }

    public void AdicionarAlbum(Album album)
    {
        this.ListaAlbum.Add(album);
    }
}