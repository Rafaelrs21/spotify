using Spotify.Domain.Banco.Agreggate;

namespace Spotify.Test
{
    public class CartaoTestes
	{
        [Fact]
        public void DeveTerCartaoAtivo()
        {
			// Arrange
			Cartao cartao = new Cartao();

			// Act
			bool estaAtivo = cartao.CartaoAtivo = true;

			// Assert
			Assert.True(estaAtivo);
		}

        [Fact]
		public void DeveTerCartaoInativo() 
		{
			// Arrange
			Cartao cartao = new Cartao();

			// Act
			bool estaAtivo = cartao.CartaoAtivo = false;

			// Assert
			Assert.False(estaAtivo);
		}

		[Fact]
		public void AumentarLimite()
		{
			// Arrange
			Cartao cartao = new Cartao("", 1000, "", true, null);

			// Act
			int novoLimite = 1500;
			cartao.LimiteDisponivel = novoLimite;
			int limiteModificado = cartao.LimiteDisponivel;

			// Assert
			Assert.Equal(novoLimite, limiteModificado);
		}
	}
}