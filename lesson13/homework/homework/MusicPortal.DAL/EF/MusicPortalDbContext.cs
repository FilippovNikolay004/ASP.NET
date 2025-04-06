using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicPortal.DAL.Entities;

namespace MusicPortal.DAL.EF {
    public class MusicPortalDbContext : DbContext  {
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Music> Musics { get; set; }
        public DbSet<User> Users { get; set; }

        public MusicPortalDbContext(DbContextOptions<MusicPortalDbContext> options) : base(options) {
            Database.EnsureCreated();
        }
    }
}
