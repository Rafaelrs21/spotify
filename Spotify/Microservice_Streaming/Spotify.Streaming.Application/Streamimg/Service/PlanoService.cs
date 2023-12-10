using Spotify.Streaming.Application.Streamimg.DTO;
using Spotify.Streaming.Repository.Streaming;

namespace Spotify.Streaming.Application.Streamimg.Service
{
    public class PlanoService
    {
        private PlanoRepository PlanoRepository { get; set; }
        public PlanoService()
        {
            this.PlanoRepository = new PlanoRepository();
        }

        public PlanoDto ObterPlano(Guid id)
        {
            var plano = this.PlanoRepository.ObterPlanoPorId(id);

            if (plano == null)
                return null;

            return new PlanoDto()
            {
                
                Id = plano.Id,
                Nome = plano.NomePlano,
                Descricao = plano.NivelPlano,
                Valor = plano.ValorPlano,
            };

        }
    }
}
