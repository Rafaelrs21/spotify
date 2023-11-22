namespace Spotify.Repository.Streaming
{
    public class AssinaturaRepository
    {
        private static List<Assinatura> assinaturas = new List<Assinatura>();

        public void SalvarAssinatura(Assinatura assinatura)
        {
            assinatura.Id = Guid.NewGuid();
            AssinaturaRepository.assinaturas.Add(assinatura);
        }
    }
}
