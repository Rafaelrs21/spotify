﻿using Spotify.Domain.Banco.Agreggate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Repository.Conta
{
    public class UsuarioRepository
    {
        private static List<Usuario> usuarios = new List<Usuario>();

        public Usuario ObterUsuario(Guid id)
        {
            return UsuarioRepository
                        .usuarios
                        .FirstOrDefault(x => x.Id == id);
        }

        public void SalvarUsuario(Usuario usuario)
        {
            usuario.Id = Guid.NewGuid();
            UsuarioRepository.usuarios.Add(usuario);
        }
    }
}
