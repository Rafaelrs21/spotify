using Spotify.Application.Streamimg.DTO;
using Spotify.Repository.Streaming;

namespace Spotify.Application.Streamimg.Service
{
    public class BandaService
    {
        private BandaRepository Repository = new BandaRepository();

        public BandaDto CriarBanda(BandaDto banda){

            banda.NomeBanda = banda.NomeBanda;
            banda.EstiloMusica = banda.EstiloMusica;

            return banda;
        }
    }
}