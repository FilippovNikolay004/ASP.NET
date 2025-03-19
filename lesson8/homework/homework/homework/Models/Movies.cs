using homework.Annotations;
using System.ComponentModel.DataAnnotations;

namespace homework.Models {
    public class Movies {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [Display(Name = "Название")]
        public string MoveName { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [Display(Name = "Режиссёр")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым.")]
        [MyGenre([
            "Боевик", "Комедия", "Драма",
            "Фантастика", "Фэнтези", "Ужасы",
            "Триллер", "Детектив", "Мелодрама",
            "Анимация", "Документальный", "Исторический",
            "Вестерн", "Приключения", "Мюзикл" ], ErrorMessage = "Недопустимый жанр")]
        [Display(Name = "Жанры")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым.")]
        [Range(1895, 2025, ErrorMessage = "Недопустимое значение")]
        [Display(Name = "Дата релиза")]
        public int ReleaseYear { get; set; }
        public string? FileName { get; set; }
        public string? Path { get; set; }

        [Display(Name = "Краткое описание")]
        public string? ShortDescription { get; set; }
    }
}
