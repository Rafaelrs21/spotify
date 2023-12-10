using Spotify.Domain.Banco.Agreggate;
using Spotify.Streaming.Domain.Stream.Agreggate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Conta.Agreggate
{
    public class Playlist
    {
        public Guid Id { get; set; }
        public string NomePlaylist { get; set; }
        public string QtdMusicas { get; set; }
        public bool Publica { get; set; }
        public Usuario Usuario { get; set; }
        public List<Musica> Musicas { get; set; }

        public Playlist()
        {
            Musicas = new List<Musica>();
        }

    }
}
