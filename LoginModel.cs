using System.ComponentModel.DataAnnotations;

namespace Pagen.Models
{
    public class LoginModel
    {
        #region Properties

        [Display(Name = "Логин")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }


        #endregion
    }
}