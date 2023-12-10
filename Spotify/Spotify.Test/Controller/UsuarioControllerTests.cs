using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Spotify.API.Controllers;
using Spotify.Application.Conta.DTO;
using Xunit;

namespace Spotify.Test.Controller
{
    public class UsuarioControllerTests
    {
        [Fact]
        public void DeveChamarPostCriarUsuarioComSucesso()
        {
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

            var logger = LoggerFactory.Create(logger => logger.AddConsole())
                                      .CreateLogger<UsuarioController>();

            var controller = new UsuarioController(logger);

            var response = controller.CriarConta(dto);

            Assert.True(response is CreatedResult);

            var responseContent = (response as CreatedResult).Value;
            Assert.True(responseContent is UsuarioDto);
            Assert.True((responseContent as UsuarioDto).Id != Guid.Empty);
        }
    }
}