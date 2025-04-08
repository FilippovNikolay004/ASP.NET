using MusicPortal.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.BLL.DTO {
    public class AdministratorDTO {
        public int Id { get; set; }


        // Navigation properties
        [ForeignKey("UserId")]
        public User? User { get; set; } = new User();
    }
}
