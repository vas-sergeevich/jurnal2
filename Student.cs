using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pagen.Models.Identity
{
    public class Student
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Группа")]
        public string Group { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        [NotMapped]
        public string FullName => $"{Group} {Surname} {Name}";
    }
}