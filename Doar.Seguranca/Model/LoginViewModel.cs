using System.ComponentModel.DataAnnotations;

namespace Doar.Seguranca.Model
{
    public class LoginViewModel
    {
        [Display(Name = "LblEmailAlternativo")]
        [Required(ErrorMessage = "Campo Obrigatorio")]
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage= "InformeUmEmailValido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Senha é obrigatório.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "LblPermanecerLogado")]
        public bool RememberMe { get; set; }

        public int GrupoAuditoriaId { get; set; }
    }
}