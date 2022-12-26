using System.ComponentModel.DataAnnotations;

namespace Pagen.Models
{
    public class ChangePasswordModel
    {
        #region Properties

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Старый пароль")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Новый пароль")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Повторите пароль")]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают")]
        public string NewPasswordConfirm { get; set; }

        #endregion
    }
}