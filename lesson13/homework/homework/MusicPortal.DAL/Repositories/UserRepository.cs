using Microsoft.EntityFrameworkCore;
using MusicPortal.DAL.EF;
using MusicPortal.DAL.Entities;
using MusicPortal.DAL.Interfaces;


namespace MusicPortal.DAL.Repositories {
    public class UserRepository :IRepository<User> {
        private MusicPortalDbContext db;

        public UserRepository(MusicPortalDbContext context) {
            db = context;
        }


        public async Task<IEnumerable<User>> GetAll() {
            return await db.Users.Include(u => u.Musics).Include(u => u.Administrators).ToListAsync();
        }
        public async Task<User> GetById(int id) {
            return await db.Users.Include(u => u.Musics).Include(u => u.Administrators).FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<User> GetByName(string name) {
            return await db.Users.Include(u => u.Musics).Include(u => u.Administrators).FirstOrDefaultAsync(u => u.Login == name);
        }
        public async Task Create(User item) {
            db.Users.Add(item);
            await db.SaveChangesAsync();
        }
        public void Update(User item) {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
        public async Task Delete(int id) {
            User user = await db.Users.FindAsync(id);
            if (user != null) {
                db.Users.Remove(user);
                await db.SaveChangesAsync();
            }
        }
    }
}
