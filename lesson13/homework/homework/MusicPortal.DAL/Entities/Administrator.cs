using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.DAL.Entities {
    public class Administrator {
        public int Id { get; set; }

        // Navigation properties
        [ForeignKey("UserId")]
        public User User { get; set; } = new User();
    }
}
