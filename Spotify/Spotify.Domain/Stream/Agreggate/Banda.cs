﻿using System;

namespace Spotify.Domain.Stream.Agreggate;
public class Banda
{
    public string NomeBanda { get; set; }
    public string EstiloMusica { get; set; }
    public List<string> BandaIntegrantes { get; set; }
    public List<Album> ListaAlbum { get; set; }

    public Banda(string nomeBanda, string estiloMusica, List<string> bandaIntegrantes, List<Album> listaAlbum)
    {
        NomeBanda = nomeBanda;
        EstiloMusica = estiloMusica;
        BandaIntegrantes = bandaIntegrantes;
        ListaAlbum = listaAlbum;
    }
}