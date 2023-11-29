using Spotify.Application.Conta.DTO;
using Spotify.Application.Conta.Interface;
using Spotify.Core.Exception;
using Spotify.Domain.Banco.Agreggate;
using Spotify.Domain.Stream.Agreggate;
using Spotify.Repository.Conta;
using Spotify.Repository.Streaming;

namespace Spotify.Application.Conta.Services
{
    public class UsuarioService : IUsuarioService
    {
        private PlanoRepository planoRepository = new PlanoRepository();
        private UsuarioRepository usarioRepository = new UsuarioRepository();


        public UsuarioDto CriarConta(UsuarioDto conta)
        {
            //Todo: Verificar pegar plano
            Plano plano = this.planoRepository.ObterPlanoPorId(conta.IdPlano);

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
            this.usarioRepository.SalvarUsuario(usuario);
            conta.Id = usuario.Id;

            // Retornar Conta Criada
            return conta;
        }

        public UsuarioDto ObterUsuario(Guid id)
        {
            var usuario = this.usarioRepository.ObterUsuario(id);

            if (usuario == null)
                return null;

            UsuarioDto result = new UsuarioDto()
            {
                Id = usuario.Id,
                Cartao = new CartaoDto()
                {
                    CartaoAtivo = usuario.Cartoes.FirstOrDefault().CartaoAtivo,
                    LimiteCartao = usuario.Cartoes.FirstOrDefault().LimiteCartao,
                    NumeroCartao = "xxxx-xxxx-xxxx-xx"
                },
                CPF = usuario.CPF.NumeroFormatado(),
                Nome = usuario.Nome,
            };

            return result;
        }
    }
}