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
    public class GenreService : IGenreService {
        IUnitOfWork Database { get; set; }

        public GenreService(IUnitOfWork uow) {
            Database = uow;
        }


        public async Task CreateGenre(GenreDTO genreDTO) {
            var genre = new Genre {
                Name = genreDTO.Name
            };
            await Database.Genre.Create(genre);
            await Database.Save();
        }
        public async Task UpdateGenre(GenreDTO genreDTO) {
            var genre = new Genre {
                Id = genreDTO.Id,
                Name = genreDTO.Name
            };
            Database.Genre.Update(genre);
            await Database.Save();
        }
        public async Task DeleteGenre(int id) {
            await Database.Genre.Delete(id);
            await Database.Save();
        }
        public async Task<GenreDTO> GetGenre(int id) {
            var genre = await Database.Genre.GetById(id);
            if (genre == null)
                throw new ValidationException("Genre not found");

            return new GenreDTO {
                Id = genre.Id,
                Name = genre.Name
            };
        }
        public async Task<IEnumerable<GenreDTO>> GetAllGenres() {
            var genres = await Database.Genre.GetAll();
            return genres.Select(genre => new GenreDTO {
                Id = genre.Id,
                Name = genre.Name
            });
        }
    }
}
