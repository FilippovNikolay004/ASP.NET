using Microsoft.EntityFrameworkCore;
using MusicPortal.DAL.EF;
using MusicPortal.DAL.Entities;
using MusicPortal.DAL.Interfaces;


namespace MusicPortal.DAL.Repositories {
    public class AdministratorRepository : IRepository<Administrator> {
        private MusicPortalDbContext db;

        public AdministratorRepository(MusicPortalDbContext context) {
            db = context;
        }


        public async Task<IEnumerable<Administrator>> GetAll() {
            return await db.Administrators.Include(a => a.User).ToListAsync();
        }
        public async Task<Administrator> GetById(int id) {
            return await db.Administrators.Include(a => a.User).FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<Administrator> GetByName(string name) {
            return await db.Administrators.Include(a => a.User).FirstOrDefaultAsync(a => a.User.Login == name);
        }
        public async Task Create(Administrator item) {
            db.Administrators.Add(item);
            await db.SaveChangesAsync();
        }
        public void Update(Administrator item) {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
        public async Task Delete(int id) {
            Administrator administrator = await db.Administrators.FindAsync(id);
            if (administrator != null) {
                db.Administrators.Remove(administrator);
                await db.SaveChangesAsync();
            }
        }
    }
}