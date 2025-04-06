using MusicPortal.BLL.DTO;
using MusicPortal.BLL.Interfaces;
using MusicPortal.DAL.Entities;
using MusicPortal.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.BLL.Services {
    class AdministratorService {
        IUnitOfWork Database { get; set; }

        public AdministratorService(IUnitOfWork uow) {
            Database = uow;
        }


        public async Task CreateAdmin(AdministratorDTO administratorDTO) {
            var admin = new Administrator {
                
            };
            await Database.Administrator.Create(admin);
            await Database.Save();
        }
    }
}
