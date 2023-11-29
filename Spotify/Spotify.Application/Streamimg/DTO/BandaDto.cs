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
        public string EstiloMusica { get; set; }
    }
}
