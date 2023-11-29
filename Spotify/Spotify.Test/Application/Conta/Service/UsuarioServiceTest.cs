using Spotify.Application.Conta.DTO;
using Spotify.Application.Conta.Services;
using Spotify.Core.Exception;
using Xunit;

namespace Spotify.Test.Application.Conta.Service
{
    public class UsuarioServiceTest
    {
        [Fact]
        public void DeveCriarContaComSucesso()
        {
            //Arrange
            UsuarioDto dto = new UsuarioDto()
            {
                Nome = "Lorem Ipsum do teste",
                CPF = "26952278095",
                Cartao = new CartaoDto()
                {
                    CartaoAtivo = true,
                    LimiteCartao = 100,
                    NumeroCartao = "5248581002684983"
                },
                IdPlano = new Guid("8D044595-D4A6-4E1A-9F09-DAB92205C71C")
            };

            UsuarioService service = new UsuarioService();
            service.CriarConta(dto);

            Assert.True(dto.Id != Guid.Empty);
        }

        [Fact]
        public void NaoDeveCriarContaComPlanoInvalido()
        {
            //Arrange
            UsuarioDto dto = new UsuarioDto()
            {
                Nome = "Lorem Ipsum do teste",
                CPF = "26952278095",
                Cartao = new CartaoDto()
                {
                    CartaoAtivo = true,
                    LimiteCartao = 100,
                    NumeroCartao = "5248581002684983"
                },
                IdPlano = Guid.NewGuid()
            };

            UsuarioService service = new UsuarioService();

            Assert.Throws<BusinessException>(() => service.CriarConta(dto));
        }
    }
}