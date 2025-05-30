﻿using System.ComponentModel.DataAnnotations;

namespace Soccer.BLL.DTO
{
    // Data Transfer Object - специальная модель для передачи данных
    // Класс TeamDTO должен содержать только те данные, которые нужно передать 
    // на уровень представления или, наоборот, получить с этого уровня.
    public class TeamDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено.")]
        public string? Coach { get; set; }
    }
}
