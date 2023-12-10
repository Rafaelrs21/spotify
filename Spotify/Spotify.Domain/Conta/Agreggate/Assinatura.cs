using Spotify.Streaming.Domain.Stream.Agreggate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Conta.Agreggate
{
    public class Assinatura
    {
        public Guid Id { get; set; }
        public string nivelAssinatura { get; set; }
        public string nomeAssinatura { get; set; }
        public Plano Plano { get; set; }
        public Boolean Ativo { get; set; }
        public DateTime DtAssinatura { get; set; }
    }
}
