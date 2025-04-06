using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.DAL.Entities {
    public class Genre {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        

        // Navigation properties
        public List<Music> Musics { get; set; } = new List<Music>();
    }
}
