using Spotify.Application.Conta.DTO;
using Spotify.Core.Exception;
using Spotify.Domain.Banco.Agreggate;
using Spotify.Repository.Conta;
using Spotify.Repository.Streaming;
using Spotify.Streaming.Domain.Stream.Agreggate;

namespace Spotify.Application.Conta.Services
{
    public class UsuarioService
    {
        private UsuarioRepository usuarioRepository = new UsuarioRepository();
        private PlanoRepository planoRepository = new PlanoRepository();
        private BandaRepository bandaRepository = new BandaRepository();


        public async Task<UsuarioDto> CriarConta(UsuarioDto conta)
        {
            //Todo: Verificar pegar plano
            Plano plano = await this.planoRepository.ObterPlano(conta.IdPlano);

            if (plano == null)
            {
                new BusinessException(new BusinessValidation()
                {
                    ErrorMessage = "Plano não encontrado",
                    ErrorName = nameof(CriarConta)
                }).ValidateAndThrow();
            }

            Cartao cartao = new Cartao();
            cartao.CartaoAtivo = conta.Cartao.CartaoAtivo;
            cartao.NumeroCartao = conta.Cartao.NumeroCartao;
            cartao.LimiteCartao = conta.Cartao.LimiteCartao;

            //Criar Usuario
            Usuario usuario = new Usuario();
            usuario.Criar(conta.Nome, conta.CPF, plano, cartao);

            //Gravar o usuario na base;
            this.usuarioRepository.SalvarUsuario(usuario);
            conta.Id = usuario.IdUsuario;

            // Retornar Conta Criada
            return conta;
        }

        public UsuarioDto ObterUsuario(Guid id)
        {
            var usuario = this.usuarioRepository.ObterUsuario(id);

            if (usuario == null)
                return null;

            UsuarioDto result = new UsuarioDto()
            {
                Id = usuario.IdUsuario,
                Cartao = new CartaoDto()
                {
                    CartaoAtivo = usuario.Cartoes.FirstOrDefault().CartaoAtivo,
                    LimiteCartao = usuario.Cartoes.FirstOrDefault().LimiteCartao,
                    NumeroCartao = "xxxx-xxxx-xxxx-xx"
                },
                CPF = usuario.CPF.NumeroFormatado(),
                Nome = usuario.Nome,
                Playlists = new List<PlaylistDto>()
            };

            foreach (var item in usuario.Playlists)
            {
                var playList = new PlaylistDto()
                {
                    Id = item.Id,
                    Nome = item.NomePlaylist,
                    Publica = item.Publica,
                    Musicas = new List<Conta.DTO.MusicaDto>()
                };

                foreach (var musicas in item.Musicas)
                {
                    playList.Musicas.Add(new Conta.DTO.MusicaDto()
                    {
                        Duracao = musicas.Duracao,
                        Id = musicas.Id,
                        Nome = musicas.NomeMusica
                    });
                }

                result.Playlists.Add(playList);
            }

            return result;
        }

        public async Task FavoritarMusica(Guid id, Guid idMusica)
        {
            var usuario = this.usuarioRepository.ObterUsuario(id);

            if (usuario == null)
            {
                throw new BusinessException(new BusinessValidation()
                {
                    ErrorMessage = "Não encontrei o usuário",
                    ErrorName = nameof(FavoritarMusica)
                });
            }

            var musica = await this.bandaRepository.ObterMusica(idMusica);

            if (musica == null)
            {
                throw new BusinessException(new BusinessValidation()
                {
                    ErrorMessage = "Não encontrei a musica",
                    ErrorName = nameof(FavoritarMusica)
                });
            }

            usuario.Favoritar(musica);
            this.usuarioRepository.Update(usuario);

        }
    }
}