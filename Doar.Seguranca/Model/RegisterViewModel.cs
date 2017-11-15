using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Doar.Seguranca.Model
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Campo Obrigatorio")]
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "InformeUmEmailValido")]
        [Display(Name = "Email")]
        public string Email { get; set; }

      
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


        public string Id { get; set; }

        [Display(Name = "LblCodigo")]
        public int? TipoDeUsuarioId { get; set; }

        [Display(Name = "LblCliente")]
        public int? ClienteId { get; set; }

        [Display(Name = "LblTipoDeLicenca")]
        public int? TipoDeLicencaId { get; set; }

        [Display(Name = "LblEmpreendimento")]
        public int? EmpreendimentoId { get; set; }


        [Display(Name = "LblAcessoEspecial")]
        public List<int> AcessoEspecialSelecionado { get; set; }

        [Display(Name = "LblImportarPermissoesDeOutroUsuario")]
        public bool ImportaPermissaoDeOutroUsuario { get; set; }


    }
}