﻿using Spotify.Domain.Banco.Agreggate;
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
                LimiteCartao = 1000M,
                NumeroCartao = "6465465466",
            };

            string nomeEmpresa = "Bananada";
            string aviso = "Transação foi realizado com sucesso";
            Decimal valor = 10.00M;

            cartao.CriarTransacao(nomeEmpresa, valor, aviso);

            Assert.True(cartao.Transferencias.Count() > 0);
        }

        [Fact]
        public void NaoDeveCriarTransacaoComCartaoSemLimite()
        {
            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                CartaoAtivo = true,
                LimiteCartao = 1M,
                NumeroCartao = "6465465466",
            };

            string nomeEmpresa = "Bananada";
            string aviso = "Transação foi realizado com sucesso";
            Decimal valor = 10.00M;

            Assert.Throws<CartaoException>(
                () => cartao.CriarTransacao("Dummy", 19M, "Dummy Transacao"));

        }

        [Fact]
        public void NaoDeveCriarTransacaoComCartaoValorDuplicado()
        {
            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                CartaoAtivo = true,
                LimiteCartao = 1M,
                NumeroCartao = "6465465466",
            };

            cartao.Transferencias.Add(new Spotify.Domain.Transacao.Agreggate.Transferencia()
            {
                TempoTranferencia = DateTime.Now,
                Id = Guid.NewGuid(),
                Comerciante = new Spotify.Domain.Transacao.ValueObject.Comerciante()
                {
                    NomeEmpresa = "Dummy"
                },
                Valor = 19M,
                AvisoConfirmacao = "saljasdlak"
            });

            Assert.Throws<CartaoException>(
                () => cartao.CriarTransacao("Dummy", 19M, "Dummy Transacao"));
        }

        [Fact]
        public void NaoDeveCriarTransacaoComCartaoAltoFrequencia()
        {
            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                CartaoAtivo = true,
                LimiteCartao = 1M,
                NumeroCartao = "6465465466",
            };

            cartao.Transferencias.Add(new Spotify.Domain.Transacao.Agreggate.Transferencia()
            {
                TempoTranferencia = DateTime.Now.AddMinutes(-1),
                Id = Guid.NewGuid(),
                Comerciante = new Spotify.Domain.Transacao.ValueObject.Comerciante()
                {
                    NomeEmpresa = "Dummy"
                },
                Valor = 19M,
                AvisoConfirmacao = "saljasdlak"
            });

            cartao.Transferencias.Add(new Spotify.Domain.Transacao.Agreggate.Transferencia()
            {
                TempoTranferencia = DateTime.Now.AddMinutes(-0.5),
                Id = Guid.NewGuid(),
                Comerciante = new Spotify.Domain.Transacao.ValueObject.Comerciante()
                {
                    NomeEmpresa = "Dummy"
                },
                Valor = 19M,
                AvisoConfirmacao = "saljasdlak"
            });

            cartao.Transferencias.Add(new Spotify.Domain.Transacao.Agreggate.Transferencia()
            {
                TempoTranferencia = DateTime.Now,
                Id = Guid.NewGuid(),
                Comerciante = new Spotify.Domain.Transacao.ValueObject.Comerciante()
                {
                    NomeEmpresa = "Dummy"
                },
                Valor = 19M,
                AvisoConfirmacao = "saljasdlak"
            });


            Assert.Throws<CartaoException>(
                () => cartao.CriarTransacao("Dummy", 19M, "Dummy Transacao"));
        }

        [Fact]
        public void NaoDeveCriarTransacaoComCartaoInativo()
        {
            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                CartaoAtivo = false,
                LimiteCartao = 1000M,
                NumeroCartao = "6465465466",
            };

            Assert.Throws<CartaoException>(
                () => cartao.CriarTransacao("Dummy", 19M, "Dummy Transacao"));
        }
    }
}