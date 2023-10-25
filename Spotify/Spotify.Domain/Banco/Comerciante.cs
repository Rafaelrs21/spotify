using System;
namespace Spotify.Domain;
public class Comerciante
{
	public int CNPJ { get; set; }
	public string NomeEmpresa { get; set; }
	public string EndComercial { get; set; }
	public string Telefone { get; set; }
	public List<Transferencia> ListaTranferencia { get; set; }

	public Comerciante(int cnpj, string nomeEmpresa, string endComercial, string telefone, List<Transferencia> listaTransferencia)
	{
		CNPJ = cnpj;
		NomeEmpresa = nomeEmpresa;
		EndComercial = endComercial;
		Telefone = telefone;
		ListaTranferencia = listaTransferencia;
	}
}