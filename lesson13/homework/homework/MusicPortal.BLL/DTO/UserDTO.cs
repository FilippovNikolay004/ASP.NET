using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.BLL.DTO {
    public enum UserStatus {
        Pending,    // ожидает одобрения
        Active,     // активный
        Rejected    // отклонен
    }

    public class UserDTO {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено.")]
        public string Login { get; set; } = string.Empty;

        [Required(ErrorMessage = "Поле должно быть установлено.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Поле должно быть установлено.")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Некорректный email")]
        public string Email { get; set; } = string.Empty;


        [Required(ErrorMessage = "Поле должно быть установлено.")]
        public string NumberPhone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Поле должно быть установлено.")]
        public DateTime DateOfBirthday { get; set; } = new DateTime();

        [Required(ErrorMessage = "Поле должно быть установлено.")]
        public UserStatus Status { get; set; } = UserStatus.Pending;
    }
}
