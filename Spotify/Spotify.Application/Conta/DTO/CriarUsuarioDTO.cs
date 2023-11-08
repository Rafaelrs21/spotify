using Spotify.Domain.Banco.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Conta.DTO
{
    public class CriarUsuarioDTO
    {
        public String Nome { get; set; }
        public CPF CPF { get; set; }
    }
}
