using Spotify.Domain.Stream.Agreggate;

namespace Spotify.Repository.Streaming
{
    public class AlbumRepository
    {
        private static List<Album> albums = new List<Album>();

        public void SalvarAlbum(Album album)
        {
            album.Id = Guid.NewGuid();
            AlbumRepository.albums.Add(album);
        }
    }
}