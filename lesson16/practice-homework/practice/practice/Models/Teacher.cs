using Microsoft.EntityFrameworkCore;

namespace practice.Models {
    public class TeacherContext :DbContext {
        public DbSet<Teacher> Teachers { get; set; } = null!;

        public TeacherContext(DbContextOptions<TeacherContext> options) : base(options) {
            if (Database.EnsureCreated()) {
                // Database was created, seed data here
                Teachers.AddRange(new List<Teacher> {
                    new Teacher { FirstName = "John", LastName = "Doe", Age = 30 },
                    new Teacher { FirstName = "Jane", LastName = "Smith", Age = 25 },
                    new Teacher { FirstName = "Sam", LastName = "Brown", Age = 40 }
                });
                SaveChanges();
            }
        }
    }

    public class Teacher {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
    }
}
