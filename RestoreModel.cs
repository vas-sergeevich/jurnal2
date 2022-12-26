using System.ComponentModel.DataAnnotations;

namespace Pagen.Models
{
    public class RestoreModel
    {
        #region Properties

        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Код восстановления")]
        public string Code { get; set; }

        [Display(Name = "Новый Пароль")]
        public string NewPassword { get; set; }

        [Display(Name = "Id")]
        public string Id { get; set; }

        #endregion
    }
}