using Microsoft.EntityFrameworkCore;

namespace AspNetCore.WebAPI.Models
{
    public class MusicContext : DbContext
    {
        public DbSet<Music> Musics { get; set; }
        public MusicContext(DbContextOptions<MusicContext> options)
            : base(options)
        {
            if(Database.EnsureCreated())
            {
                Musics.AddRange(
                    new Music { Name = "Back in Black", Executor = "AC/DC", Genre = "Hard Rock", Release = new DateTime(1980, 7, 25) },
                    new Music { Name = "Bohemian Rhapsody", Executor = "Queen", Genre = "Rock", Release = new DateTime(1975, 10, 31) },
                    new Music { Name = "Sick Music 2020", Executor = "Hospital Records", Genre = "Drum & Bass", Release = new DateTime(2020, 5, 22) }
                );

                SaveChanges();
            }
        }
    }
    public class Music
    {
        // Идентификатор 
        public int Id { get; set; }

        // Название музыки
        public string? Name { get; set; }

        // Исполнитель
        public string? Executor { get; set; }

        // Жанр музыки
        public string? Genre { get; set; }

        // Дата релиза
        public DateTime Release { get; set; }
    }
}
