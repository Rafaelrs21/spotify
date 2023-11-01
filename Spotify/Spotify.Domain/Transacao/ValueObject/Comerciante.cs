using System;
using Spotify.Domain.Transacao.Agreggate;

namespace Spotify.Domain.Transacao.ValueObject;
public class Comerciante
{
    public int CNPJ { get; set; }
    public string NomeEmpresa { get; set; }
    public string EndComercial { get; set; }
    public string Telefone { get; set; }
    public List<Transferencia> ListaTranferencia { get; set; }

}