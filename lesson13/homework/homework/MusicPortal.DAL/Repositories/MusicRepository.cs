using Microsoft.EntityFrameworkCore;
using MusicPortal.DAL.EF;
using MusicPortal.DAL.Entities;
using MusicPortal.DAL.Interfaces;


namespace MusicPortal.DAL.Repositories {
    public class MusicRepository :IRepository<Music> {
        private MusicPortalDbContext db;

        public MusicRepository(MusicPortalDbContext context) {
            db = context;
        }


        public async Task<IEnumerable<Music>> GetAll() {
            return await db.Musics.Include(m => m.Genre).Include(m => m.User).ToListAsync();
        }
        public async Task<Music> GetById(int id) {
            return await db.Musics.Include(m => m.Genre).Include(m => m.User).FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task<Music> GetByName(string name) {
            return await db.Musics.Include(m => m.Genre).Include(m => m.User).FirstOrDefaultAsync(m => m.Name == name);
        }
        public async Task Create(Music item) {
            db.Musics.Add(item);
            await db.SaveChangesAsync();
        }
        public void Update(Music item) {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
        public async Task Delete(int id) {
            Music music = await db.Musics.FindAsync(id);
            if (music != null) {
                db.Musics.Remove(music);
                await db.SaveChangesAsync();
            }
        }
    }
}
