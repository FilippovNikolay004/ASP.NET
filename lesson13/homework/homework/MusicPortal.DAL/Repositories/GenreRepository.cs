using Microsoft.EntityFrameworkCore;
using MusicPortal.DAL.EF;
using MusicPortal.DAL.Entities;
using MusicPortal.DAL.Interfaces;


namespace MusicPortal.DAL.Repositories {
    public class GenreRepository : IRepository<Genre> {
        private MusicPortalDbContext db;

        public GenreRepository(MusicPortalDbContext context) {
            db = context;
        }

        public async Task<IEnumerable<Genre>> GetAll() {
            return await db.Genres.Include(g => g.Musics).ToListAsync();
        }
        public async Task<Genre> GetById(int id) {
            return await db.Genres.Include(g => g.Musics).FirstOrDefaultAsync(g => g.Id == id);
        }
        public async Task<Genre> GetByName(string name) {
            return await db.Genres.Include(g => g.Musics).FirstOrDefaultAsync(g => g.Name == name);
        }
        public async Task Create(Genre item) {
            db.Genres.Add(item);
            await db.SaveChangesAsync();
        }
        public void Update(Genre item) {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
        public async Task Delete(int id) {
            Genre genre = await db.Genres.FindAsync(id);
            if (genre != null) {
                db.Genres.Remove(genre);
                await db.SaveChangesAsync();
            }
        }
    }
}
