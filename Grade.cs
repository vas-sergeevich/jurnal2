using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pagen.Models.Identity
{
    public class Grade
    {
        public int Id { get; set; }

        public virtual Student Student { get; set; }

        [Display(Name = "Студент")]
        [Required]
        public int StudentId { get; set; }

        public virtual Subject Subject { get; set; }

        [Display(Name = "Предмет")]
        [Required]
        public int SubjectId { get; set; }

        [Display(Name ="Оценка")]
        public string Rate { get; set; }

        [Display(Name = "Описание")]
        public string Discription { get; set; }
    }
}