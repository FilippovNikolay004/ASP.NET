using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MusicPortal.BLL.DTO;
using MusicPortal.BLL.Interfaces;
using MusicPortal.DAL.Entities;
using MusicPortal.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.BLL.Services {
    class MusicService : IMusicService {
        IUnitOfWork Database { get; set; }

        public MusicService(IUnitOfWork uow) {
            Database = uow;
        }

        public async Task CreateMusic(MusicDTO musicDTO) {
            var music = new Music {
                Id = musicDTO.Id,
                Name = musicDTO.Name,
                Duration = musicDTO.Duration,
                CreatedAt = musicDTO.CreatedAt,
                Genre = musicDTO.Genre,
                User = musicDTO.User
            };
            await Database.Music.Create(music);
            await Database.Save();
        }
        public async Task UpdateMusic(MusicDTO musicDTO) {
            var music = new Music {
                Id = musicDTO.Id,
                Name = musicDTO.Name,
                Duration = musicDTO.Duration,
                CreatedAt = musicDTO.CreatedAt,
                Genre = musicDTO.Genre,
                User = musicDTO.User
            };
            Database.Music.Update(music);
            await Database.Save();
        }
        public async Task DeleteMusic(int id) {
            await Database.Music.Delete(id);
            await Database.Save();
        }
        public async Task<MusicDTO> GetMusic(int id) {
            var music = await Database.Music.GetById(id);
            if (music == null)
                throw new ValidationException("Music not found");
            return new MusicDTO {
                Id = music.Id,
                Name = music.Name,
                Duration = music.Duration,
                CreatedAt = music.CreatedAt,
                Genre = music.Genre,
                User = music.User
            };
        }
        public async Task<IEnumerable<MusicDTO>> GetAllMusics() {
            var musics = await Database.Music.GetAll();
            return musics.Select(music => new MusicDTO {
                Id = music.Id,
                Name = music.Name,
                Duration = music.Duration,
                CreatedAt = music.CreatedAt,
                Genre = music.Genre,
                User = music.User
            });
        }
    }
}
