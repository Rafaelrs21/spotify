using Spotify.Domain.Banco.Agreggate;

namespace Spotify.Repository.Conta
{
    public class UsuarioRepository
    {
        private static List<Usuario> usuarios = new List<Usuario>();

        public Usuario ObterUsuario(Guid id)
        {
            return UsuarioRepository
                        .usuarios
                        .FirstOrDefault(x => x.IdUsuario == id);
        }

        public void SalvarUsuario(Usuario usuario)
        {
            usuario.IdUsuario = Guid.NewGuid();
            UsuarioRepository.usuarios.Add(usuario);
        }

        public void Update(Usuario usuario)
        {
            Usuario usuarioOld = this.ObterUsuario(usuario.IdUsuario);
            UsuarioRepository.usuarios.Remove(usuarioOld);
            UsuarioRepository.usuarios.Add(usuario);
        }
    }
}
