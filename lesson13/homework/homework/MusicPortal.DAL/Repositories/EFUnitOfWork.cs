using MusicPortal.DAL.EF;
using MusicPortal.DAL.Entities;
using MusicPortal.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.DAL.Repositories {
    public class EFUnitOfWork : IUnitOfWork {
        private MusicPortalDbContext db;
        private AdministratorRepository administratorRepository;
        private GenreRepository genreRepository;
        private MusicRepository musicRepository;
        private UserRepository userRepository;

        public EFUnitOfWork(MusicPortalDbContext context) {
            db = context;
        }


        public IRepository<Administrator> Administrator {
            get {
                if (administratorRepository == null) {
                    administratorRepository = new AdministratorRepository(db);
                }
                return administratorRepository;
            }
        }
        public IRepository<Genre> Genre {
            get {
                if (genreRepository == null) {
                    genreRepository = new GenreRepository(db);
                }
                return genreRepository;
            }
        }
        public IRepository<Music> Music {
            get {
                if (musicRepository == null) {
                    musicRepository = new MusicRepository(db);
                }
                return musicRepository;
            }
        }
        public IRepository<User> Users {
            get {
                if (userRepository == null) {
                    userRepository = new UserRepository(db);
                }
                return userRepository;
            }
        }

        public async Task Save() {
            await db.SaveChangesAsync();
        }
    }
}
