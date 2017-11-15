using System.ComponentModel.DataAnnotations;

namespace Doar.Seguranca.Model
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}