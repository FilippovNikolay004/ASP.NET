using MusicPortal.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.BLL.Interfaces {
    public interface IAdministratorService {
        Task CreateAdmin(AdministratorDTO administratorDTO);
        Task UpdateAdmin(AdministratorDTO administratorDTO);
        Task DeleteAdmin(int id);
        Task<AdministratorDTO> GetAdmin(int id);
        Task<IEnumerable<AdministratorDTO>> GetAllAdmins();
    }
}
