﻿
using System.ComponentModel.DataAnnotations;

namespace AjaxMvcApplication.Models
{
    public class Student
    {
        // Идентификатор студента
        public int Id { get; set; }
        // Имя студента
        public string? Name { get; set; }
        // Фамилия студента
        public string? Surname { get; set; }
        // Возраст студента
        public int Age { get; set; }
        // Средний балл
        public double GPA { get; set; }
    }
}