using Spotify.Domain.Stream.Agreggate;


namespace Spotify.Repository.Streaming
{
    public class PlaylistRepository
    {
        private static List<Playlist> playlists = new List<Playlist>();

        public void SalvarPlaylist(Playlist playlist)
        {
            playlist.Id = Guid.NewGuid();
            PlaylistRepository.playlists.Add(playlist);
        }
    }
}
