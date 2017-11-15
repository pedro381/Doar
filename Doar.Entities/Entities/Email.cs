using System.ComponentModel.DataAnnotations;

namespace Doar.Entity.Entities {
    public class Email {
        [Required(ErrorMessage = "Campo Obirgatório")]
        [Display(Name = "Nome:")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo Obirgatório")]
        [Display(Name = "Telefone:")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Campo Obirgatório")]
        [Display(Name = "E-mail:")]
        public string Destinatario { get; set; }
        [Required(ErrorMessage = "Campo Obirgatório")]
        [Display(Name = "Mensagem:")]
        public string Corpo { get; set; }
        [Required(ErrorMessage = "Campo Obirgatório")]
        [Display(Name = "Assunto:")]
        public string Assunto { get; set; }
    }
}
