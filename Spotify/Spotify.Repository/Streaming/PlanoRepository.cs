using Spotify.Streaming.Domain.Stream.Agreggate;
using System.Text.Json;

namespace Spotify.Repository.Streaming
{
    public class PlanoRepository
    {
        private HttpClient HttpClient { get; set; }

        public PlanoRepository()
        {
            this.HttpClient = new HttpClient();
        }

        public async Task<Plano> ObterPlano(Guid id)
        {
            var result = await this.HttpClient.GetAsync($"https://localhost:7156/{id}");

            if (result.IsSuccessStatusCode == false)
                return null;

            var content = await result.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<Plano>(content);

        }
    }
}