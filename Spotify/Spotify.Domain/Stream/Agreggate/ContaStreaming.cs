using System;

namespace Spotify.Domain.Stream.Agreggate;
public class ContaStreaming
{
    public int ID { get; set; }
    public string Usuario { get; set; }
    public string Senha { get; set; }
    public bool PlanoAtivo { get; set; }
    public string EstiloMusical { get; set; }
    public List<Playlist> ListaPlaylist { get; set; }
    public bool VerificarCartao { get; set; }

    public ContaStreaming(int id, string usuario, string senha, bool planoAtivo, string estiloMusical,
     List<Playlist> listaPlaylist, bool verificarCartao)
    {
        ID = id;
        Usuario = usuario;
        Senha = senha;
        PlanoAtivo = planoAtivo;
        EstiloMusical = estiloMusical;
        ListaPlaylist = listaPlaylist;
        VerificarCartao = verificarCartao;
    }

    public void FavoritarMusica()
    {
        Console.WriteLine("Música favorita:........");
    }

    public void FavoritarBanda()
    {
        Console.WriteLine("Banda favorita:........");
    }

    public void BuscarBanda()
    {
        Console.WriteLine("Banda selecionada:........");
    }
}