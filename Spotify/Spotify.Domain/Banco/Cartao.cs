using System;
namespace Spotify.Domain;
public class Cartao
{
	public string DataValidade { get; set; }
	public int LimiteDisponivel { get; set; }
	public string NumeroCartao { get; set; }
	public bool CartaoAtivo { get; set; }
	public List<Transferencia> ListaTransferencia { get; set; }

	public Cartao() { }
		
        public Cartao(string dataValidade, int limiteDisponivel, string numeroCartao,
		bool cartaoAtivo, List<Transferencia> listaTransferencia)
		{
			DataValidade = dataValidade;
			LimiteDisponivel = limiteDisponivel;
			NumeroCartao = numeroCartao;
			CartaoAtivo = cartaoAtivo;
			ListaTransferencia = listaTransferencia;

			 void GerarRelatorio()
			{
				Console.WriteLine("Relatório:........");
			}
		}
	}