using MusicPortal.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.BLL.Interfaces {
    public interface IMusicService {
        Task CreateMusic(MusicDTO musicDTO);
        Task UpdateMusic(MusicDTO musicDTO);
        Task DeleteMusic(int id);
        Task<MusicDTO> GetMusic(int id);
        Task<IEnumerable<MusicDTO>> GetAllMusics();
    }
}
