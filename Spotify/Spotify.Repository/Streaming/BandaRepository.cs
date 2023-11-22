using Spotify.Domain.Banco.Agreggate;
using Spotify.Domain.Stream.Agreggate;
using Spotify.Repository.Conta;

namespace Spotify.Repository.Streaming
{
    public class BandaRepository
    {
        private static List<Banda> bandas = new List<Banda>();

        public void SalvarBanda(Banda banda)
        {
            banda.Id = Guid.NewGuid();
            BandaRepository.bandas.Add(banda);
        }
    }
}