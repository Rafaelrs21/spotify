using Spotify.Domain.Stream.Agreggate;

namespace Spotify.Repository.Streaming
{
    public class MusicaRepository
    {
        private static List<Musica> musicas = new List<Musica>();

        public void SalvarMusica(Musica musica)
        {
            musica.Id = Guid.NewGuid();
            MusicaRepository.musicas.Add(musica);
        }
    }
}