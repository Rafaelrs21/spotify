using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Spotify.Streaming.Application.Streamimg.DTO
{
    public class PlanoDto
    {
        [JsonPropertyName("Id")]
        public Guid Id { get; set; }
        [JsonPropertyName("Nome")]
        public string Nome { get; set; }
        [JsonPropertyName("Descricao")]
        public string Descricao { get; set; }
        [JsonPropertyName("Valor")]
        public Decimal Valor { get; set; }
    }
}
