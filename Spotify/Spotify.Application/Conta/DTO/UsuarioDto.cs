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
    }
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