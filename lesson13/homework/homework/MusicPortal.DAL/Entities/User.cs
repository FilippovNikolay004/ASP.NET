using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.DAL.Entities {
    public enum UserStatus {
        Pending,    // ожидает одобрения
        Active,     // активный
        Rejected    // отклонен
    }

    public class User {
        public int Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string NumberPhone { get; set; } = string.Empty;
        public DateTime DateOfBirthday { get; set; } = new DateTime();
        public UserStatus Status { get; set; } = UserStatus.Pending;


        // Navigation properties
        public List<Music> Musics { get; set; } = new List<Music>();
        public List<Administrator> Administrators { get; set; } = new List<Administrator>();
    }
}
