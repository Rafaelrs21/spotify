using System.ComponentModel.DataAnnotations;

namespace Spotify.Application.Streamimg.DTO
{
    public class CriarPlaylistDto
    {
        public Guid Id { get; set; }
        
        [Required]
        public Guid IdPlaylist { get; set; }

        [Required]
        public String Nomeplaylist { get; set; }

        public MusicaDto Musica { get; set; }
    }
}

    public class MusicaDto
    {
        [Required]  
        public String NomeMusica { get; set; }
        [Required]
        public Decimal NomeCompositor { get; set; }
    }