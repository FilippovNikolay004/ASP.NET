using MusicPortal.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.BLL.Interfaces {
    public interface IGenreService {
        Task CreateGenre(GenreDTO genreDTO);
        Task UpdateGenre(GenreDTO genreDTO);
        Task DeleteGenre(int id);
        Task<GenreDTO> GetGenre(int id);
        Task<IEnumerable<GenreDTO>> GetAllGenres();
    }
}
