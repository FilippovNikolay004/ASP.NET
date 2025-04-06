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
        public int UserId { get; set; }
        public string User { get; set; } = string.Empty;
    }
}
