using System.ComponentModel.DataAnnotations;

namespace StudentsMVC.Models
{
    public class Student
    {
        // Идентификатор студента
        public int Id { get; set; }

        // Имя студента
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Имя студента")]
        public string? Name { get; set; }

        // Фамилия студента
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Фамилия студента")]
        public string? Surname { get; set; }

        // Возраст студента
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Возраст")]
        [Range(15, 60, ErrorMessage = "Недопустимый возраст")]
        public int Age { get; set; }

        // Средний балл
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Range(0.0, 12.0, ErrorMessage = "Недопустимый средний балл")]
        [Display(Name = "Средний балл")]
        public double GPA { get; set; }
    }
}