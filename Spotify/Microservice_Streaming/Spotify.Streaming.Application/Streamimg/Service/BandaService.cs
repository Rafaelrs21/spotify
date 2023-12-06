using Spotify.Streaming.Application.Streamimg.DTO;
using Spotify.Streaming.Domain.Stream.Agreggate;
using Spotify.Streaming.Repository.Streaming;

namespace Spotify.Streaming.Application.Streamimg.Service
{
    public class BandaService
    {
        private BandaRepository Repository = new BandaRepository();
        public BandaService() { }

        public BandaDto Criar(BandaDto dto)
        {
            Banda banda = new Banda()
            {
                EstiloMusica = dto.EstiloBanda,
                NomeBanda = dto.NomeBanda,
            };

            if (dto.Albums != null)
            {
                foreach (var item in dto.Albums)
                {
                    Album album = new Album()
                    {
                        Id = Guid.NewGuid(),
                        NomeAlbum = item.NomeAlbum
                    };

                    if (item.Musicas != null)
                    {
                        foreach (var musica in item.Musicas)
                        {
                            album.AdicionarMusicas(new Musica()
                            {
                                Duracao = new Domain.Stream.ValueObject.Duracao(musica.Duracao),
                                NomeMusica = musica.NomeMusica,
                                Album = album,
                                Id = Guid.NewGuid()
                            });
                        }
                    }

                    banda.AdicionarAlbum(album);
                }
            }

            this.Repository.Criar(banda);
            dto.Id = banda.Id;

            return dto;

        }

        public BandaDto ObterBanda(Guid id)
        {
            var banda = this.Repository.ObterBanda(id);

            if (banda == null)
                return null;

            BandaDto dto = new BandaDto()
            {
                Id = banda.Id,
                EstiloBanda = banda.EstiloMusica,
                NomeBanda = banda.NomeBanda,
            };

            if (banda.ListaAlbum != null)
            {
                dto.Albums = new List<AlbumDto>();

                foreach (var album in banda.ListaAlbum)
                {
                    AlbumDto albumDto = new AlbumDto()
                    {
                        Id = album.Id,
                        NomeAlbum = album.NomeAlbum,
                        Musicas = new List<MusicaDto>()
                    };

                    album.ListaMusicas?.ForEach(m =>
                    {
                        albumDto.Musicas.Add(new MusicaDto()
                        {
                            Id = m.Id,
                            Duracao = m.Duracao.Valor,
                            NomeMusica = m.NomeMusica
                        });
                    });

                    dto.Albums.Add(albumDto);
                }
            }

            return dto;

        }

        public Musica ObterMusica(Guid idMusica)
        {
            return this.Repository.ObterMusica(idMusica);
        }
    }
}