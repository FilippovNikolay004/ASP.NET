using MusicPortal.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.BLL.DTO {
    public class MusicDTO {
        public int Id { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Поле должно быть установлено.")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Продолжительность")]
        [Required(ErrorMessage = "Поле должно быть установлено.")]
        public string Duration { get; set; } = string.Empty;

        [Display(Name = "Опубликовано")]
        [Required(ErrorMessage = "Поле должно быть установлено.")]
        public DateTime CreatedAt { get; set; } = new DateTime();


        // Navigation properties
        [Display(Name = "Добавил пользователь")]
        [ForeignKey("UserId")]
        public User User { get; set; } = new User();

        [Display(Name = "Жанр")]
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; } = new Genre();
    }
}
