﻿using Spotify.Streaming.Domain.Stream.Agreggate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Spotify.Repository.Streaming
{
    public class BandaRepository
    {
        private HttpClient HttpClient { get; set; }

        public BandaRepository()
        {
            this.HttpClient = new HttpClient();
        }

        public async Task<Musica> ObterMusica(Guid id)
        {
            var result = await this.HttpClient.GetAsync($"https://localhost:7156/api/banda/musica/{id}");

            if (result.IsSuccessStatusCode == false)
                return null;

            var content = await result.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<Musica>(content);
        }
    }
}