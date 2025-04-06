using MusicPortal.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.DAL.Interfaces {
    public interface IUnitOfWork {
        IRepository<Administrator> Administrator { get; }
        IRepository<Genre> Genre { get; }
        IRepository<Music> Music { get; }
        IRepository<User> Users { get; }
        Task Save();
    }
}
