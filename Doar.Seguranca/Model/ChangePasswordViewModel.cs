using System.ComponentModel.DataAnnotations;

namespace Doar.Seguranca.Model
{
    public class ChangePasswordViewModel
    {
        [DataType(DataType.Password)]
        [Required( ErrorMessage = "Campo Obrigatorio")]
        //[Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Campo Obrigatorio")]
        [StringLength(30, ErrorMessage = "O campo {0} deve ter ao menos {2} caracteres.", MinimumLength = 6)]
        [Display(Name = "Nova Senha")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage =  "Senha Nao Confere")]
        [Required(ErrorMessage = "Campo Obrigatorio")]
        //[Display(Name = "Confirm new password")]
        public string ConfirmPassword { get; set; }

        //Campos utilizados apenas para 
        public string Email { get; set; }

        public string IdUsuario { get; set; }
    }
}