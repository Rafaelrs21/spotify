using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Streamimg.DTO
{
    public class BandaDto
    {
        public Guid Id { get; set; }

        [Required]
        public string NomeBanda { get; set; }

        [Required]
        public string EstiloBanda { get; set; }

        public List<AlbumDto> Albums { get; set; }
    }

    public class AlbumDto
    {
        public Guid Id { get; set; }
        public string NomeAlbum { get; set; }

        public List<MusicaDto> Musicas { get; set; }
    }

    public class MusicaDto
    {
        public Guid Id { get; set; }
        public string NomeMusica { get; set; }
        public int Duracao { get; set; }
    }
}