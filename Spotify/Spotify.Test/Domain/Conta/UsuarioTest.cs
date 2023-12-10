using Spotify.Domain.Banco.Agreggate;
using Spotify.Domain.Banco.Exception;
using Spotify.Streaming.Domain.Stream.Agreggate;
using Xunit;

namespace Spotify.Test.Domain.Conta
{
    public class UsuarioTest
    {
        [Fact]
        public void DeveCriarUsuarioComSucesso()
        {
            Plano plano = new Plano()
            {
                Descricao = "Lorem ipsum",
                Id = Guid.NewGuid(),
                NomePlano = "Plano Dummy",
                ValorPlano = 19.90M
            };

            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                CartaoAtivo = true,
                LimiteCartao = 1000M,
                NumeroCartao = "6465465466",
            };

            string cpf = "40635121000";
            string nome = "Dummy Usuario";

            //Act
            Usuario usuario = new Usuario();
            usuario.Criar(nome, cpf, plano, cartao);

            //Assert
            Assert.NotNull(usuario.CPF);
            Assert.NotNull(usuario.Nome);
            Assert.True(usuario.CPF.Numero == cpf);
            Assert.True(usuario.Nome == nome);

            Assert.True(usuario.Assinaturas.Count > 0);
            Assert.Same(usuario.Assinaturas[0].Plano, plano);

            Assert.True(usuario.Cartoes.Count > 0);
            Assert.Same(usuario.Cartoes[0], cartao);

            Assert.True(usuario.Playlists.Count > 0);
            Assert.True(usuario.Playlists[0].NomePlaylist == "Favoritas");
            Assert.False(usuario.Playlists[0].Publica);
        }

        [Fact()]
        public void NaoDeveCriarUsuarioComCPFInvalido()
        {
            Plano plano = new Plano()
            {
                Descricao = "Lorem ipsum",
                Id = Guid.NewGuid(),
                NomePlano = "Plano Dummy",
                ValorPlano = 19.90M
            };

            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                CartaoAtivo = true,
                LimiteCartao = 1000M,
                NumeroCartao = "6465465466",
            };

            string cpf = "406351545685";
            string nome = "Dummy Usuario";
            Usuario usuario = new Usuario();

            Assert.Throws<CPFException>
                (() => usuario.Criar(nome, cpf, plano, cartao));

        }


        [Fact()]
        public void NaoDeveCriarUsuarioComCartaoInvalido()
        {
            Plano plano = new Plano()
            {
                Descricao = "Lorem ipsum",
                Id = Guid.NewGuid(),
                NomePlano = "Plano Dummy",
                ValorPlano = 19.90M
            };

            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                CartaoAtivo = false,
                LimiteCartao = 1000M,
                NumeroCartao = "6465465466",
            };

            string cpf = "40635121000";
            string nome = "Dummy Usuario";
            Usuario usuario = new Usuario();

            Assert.Throws<CartaoException>
                (() => usuario.Criar(nome, cpf, plano, cartao));

        }
    }
}
