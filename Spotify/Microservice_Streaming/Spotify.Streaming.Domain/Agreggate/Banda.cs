

namespace Spotify.Streaming.Domain.Stream.Agreggate;
public class Banda
{
    public Guid Id { get; set; }
    public string NomeBanda { get; set; }
    public string EstiloMusica { get; set; }
    public List<Album> Albums { get; set; }

    public Banda()
    {
        this.Albums = new List<Album>();
    }

    public void AdicionarAlbum(Album album)
    {
        this.Albums.Add(album);
    }
}