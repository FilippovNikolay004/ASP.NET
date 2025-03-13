using homework.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentsMVC
{
    // Чтобы подключиться к базе данных через Entity Framework, необходим контекст данных. 
    // Контекст данных представляет собой класс, производный от класса DbContext.
    public class UniversityContext : DbContext
    {
        public DbSet<Groups> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherSubjectGroup> TeacherSubjectGroups { get; set; }

        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options) {
            if(Database.EnsureCreated()) {
                // Инициализация групп
                var groups = new Groups[]
                {
                    new Groups { Name = "Группа 101", Amount = 25 },
                    new Groups { Name = "Группа 102", Amount = 30 },
                    new Groups { Name = "Группа 201", Amount = 20 },
                    new Groups { Name = "Группа 202", Amount = 28 },
                    new Groups { Name = "Группа 301", Amount = 35 }
                };
                Groups.AddRange(groups);
                SaveChanges();

                // Инициализация студентов
                var students = new Student[]
                {
                    new Student { Name = "Иван", Surname = "Иванов", Age = 20, GPA = 4.5, Groups = groups[0] },
                    new Student { Name = "Петр", Surname = "Петров", Age = 21, GPA = 4.0, Groups = groups[1] },
                    new Student { Name = "Анна", Surname = "Сидорова", Age = 19, GPA = 4.8, Groups = groups[2] },
                    new Student { Name = "Мария", Surname = "Кузнецова", Age = 22, GPA = 3.9, Groups = groups[3] },
                    new Student { Name = "Алексей", Surname = "Смирнов", Age = 20, GPA = 4.2, Groups = groups[4] }
                };
                Students.AddRange(students);
                SaveChanges();

                // Инициализация предметов
                var subjects = new Subject[]
                {
                    new Subject { Name = "Программирование на C#" },
                    new Subject { Name = "Базы данных SQL" },
                    new Subject { Name = "ASP.NET Core" },
                    new Subject { Name = "Программирование на С++" },
                    new Subject { Name = "Пентестинг" }
                };
                Subjects.AddRange(subjects);
                SaveChanges();

                // Инициализация преподавателей
                var teachers = new Teacher[]
                {
                    new Teacher { FirstName = "Сергей", LastName = "Павлов" },
                    new Teacher { FirstName = "Елена", LastName = "Волкова" },
                    new Teacher { FirstName = "Андрей", LastName = "Морозов" },
                    new Teacher { FirstName = "Ольга", LastName = "Петрова" },
                    new Teacher { FirstName = "Дмитрий", LastName = "Соколов" }
                };
                Teachers.AddRange(teachers);
                SaveChanges();

                // Инициализация связей преподаватель-предмет-группа
                var teacherSubjectGroups = new TeacherSubjectGroup[]
                {
                    new TeacherSubjectGroup { Teacher = teachers[0], Subject = subjects[0], Group = groups[0] },
                    new TeacherSubjectGroup { Teacher = teachers[1], Subject = subjects[1], Group = groups[1] },
                    new TeacherSubjectGroup { Teacher = teachers[2], Subject = subjects[2], Group = groups[2] },
                    new TeacherSubjectGroup { Teacher = teachers[3], Subject = subjects[3], Group = groups[3] },
                    new TeacherSubjectGroup { Teacher = teachers[4], Subject = subjects[4], Group = groups[4] }
                };
                TeacherSubjectGroups.AddRange(teacherSubjectGroups);
                SaveChanges();
            }
        }
    }
}