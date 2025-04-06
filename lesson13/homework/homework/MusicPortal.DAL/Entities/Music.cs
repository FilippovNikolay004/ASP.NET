using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.DAL.Entities {
    public class Music {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = new DateTime();


        // Navigation properties
        [ForeignKey("UserId")]
        public User User { get; set; } = new User();

        [ForeignKey("GenreId")]
        public Genre Genre { get; set; } = new Genre();
    }
}
