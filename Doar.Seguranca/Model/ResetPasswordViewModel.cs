using System.ComponentModel.DataAnnotations;

namespace Doar.Seguranca.Model
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Campo Obrigatorio")]
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "InformeUmEmailValido")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Sua senha deve ter no mínimo dois caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Senha não confere.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}