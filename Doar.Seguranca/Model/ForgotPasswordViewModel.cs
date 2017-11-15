using System.ComponentModel.DataAnnotations;

namespace Doar.Seguranca.Model
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Campo Obrigatorio")]
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "InformeUmEmailValido")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
