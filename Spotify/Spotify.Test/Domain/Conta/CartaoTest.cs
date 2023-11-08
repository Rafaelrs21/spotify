using Spotify.Domain.Banco.Agreggate;
using Spotify.Domain.Banco.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Spotify.Test.Domain.Conta
{
    public class CartaoTest
    {
        [Fact]
        public void DeveFazerTransacaoComSucesso()
        {
            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                CartaoAtivo = true,
                LimiteDisponivel = 1000M,
                NumeroCartao = "6465465466",
            };

            string nomeEmpresa = "Bananada";
            string aviso = "Transação foi realizado com sucesso";
            Decimal valor = 10.00M;

            cartao.CriarTransacao(nomeEmpresa, valor, aviso);

            Assert.True(cartao.Transferencias.Count() > 0);
        }
        [Fact]
        public void DeveFazerTransacaoSemSucesso()
        {
            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                CartaoAtivo = true,
                LimiteDisponivel = 1000M,
                NumeroCartao = "6465465466",
            };

            string nomeEmpresa = "Bananada";
            string aviso = "Transação foi realizado com sucesso";
            Decimal valor = 10.00M;

            cartao.CriarTransacao(nomeEmpresa, valor, aviso);

            Assert.Throws<CartaoException>(
                () => cartao.Transferencias.Count() > 0);

        }
        public void DeveFazerTransacaoSemLimite()
        {
            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                CartaoAtivo = true,
                LimiteDisponivel = 1M,
                NumeroCartao = "6465465466",
            };

            string nomeEmpresa = "Bananada";
            string aviso = "Transação foi realizado com sucesso";
            Decimal valor = 10.00M;

            cartao.CriarTransacao(nomeEmpresa, valor, aviso);

            Assert.True(cartao.Transferencias.Count() > 0);



        }
    }
}
