using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pagen.Models.Identity
{
    public class Subject
    {
        [Required]
        public int Id { get; set; }

        [Display(Name ="Название предмета")]
        [Required]
        public string NameSubject { get; set; }

        [Display(Name = "Преподаватель Id")]
        [Required]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}