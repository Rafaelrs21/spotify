using Spotify.Domain.Banco.ValueObject;
using Spotify.Domain.Stream.Agreggate;
using System;

namespace Spotify.Domain.Banco.Agreggate;
public class PessoaFisica
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string RG { get; set; }
    public string Telefone { get; set; }
    public string CEP { get; set; }
    public DateTime DataNascimento { get; set; }
    public List<Conta> ListaConta { get; set; }
    public List<Playlist> Playlists { get; set; }
    public List<Assinatura> Assinaturas { get; set; }
    public List<Banda> BandasFavoritas { get; set; }

}
