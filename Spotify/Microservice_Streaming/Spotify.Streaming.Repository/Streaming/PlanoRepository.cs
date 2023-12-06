using Spotify.Streaming.Domain.Stream.Agreggate;

namespace Spotify.Streaming.Repository.Streaming
{
    public class PlanoRepository
    {
        private static List<Plano> plano;
        public PlanoRepository()
        {
            if (PlanoRepository.plano == null)
            {
                PlanoRepository.plano = new List<Plano>();
                PlanoRepository.plano.Add(new Plano()
                {
                    Id = new Guid("8D044595-D4A6-4E1A-9F09-DAB92205C71C"),
                    Descricao = "Plano Basico",
                    NomePlano = "Plano Basico Musica",
                    NivelPlano = "Basico",
                    PlanoBeneficios = "Basico",
                    ValorPlano = 20M,
                });
            }
        }

        public Plano ObterPlanoPorId(Guid idPlano)
        {
            return PlanoRepository.plano.FirstOrDefault(x => x.Id == idPlano);
        }
    }
}
