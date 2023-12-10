using System.ComponentModel.DataAnnotations;

namespace Spotify.Application.Conta.DTO
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }
        
        [Required]
        public Guid IdPlano { get; set; }

        [Required]
        public String Nome { get; set; }

        [Required]
        public String CPF { get; set; }

        public CartaoDto Cartao { get; set; }

        public List<PlaylistDto> Playlists { get; set; }
    }

    public class CartaoDto
    {
        [Required]
        public String NumeroCartao { get; set; }
        [Required]
        public Decimal LimiteCartao { get; set; }
        [Required]
        public Boolean CartaoAtivo { get; set; }
    }

    public class PlaylistDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Boolean Publica { get; set; }
        public List<MusicaDto> Musicas { get; set; }

    }

    public class MusicaDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Duracao { get; set; }

    }
}