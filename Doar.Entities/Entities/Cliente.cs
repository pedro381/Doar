using System.ComponentModel.DataAnnotations;

namespace Doar.Entity.Entities
{
    public class Cliente : BaseDominio
    {
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "Campo Obirgatório")]
        [Display(Name = "Nome:")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo Obirgatório")]
        [Display(Name = "CNPJ:")]
        public string Cnpj { get; set; }
        [Required(ErrorMessage = "Campo Obirgatório")]
        [Display(Name = "Agência:")]
        public string Agencia { get; set; }
        [Required(ErrorMessage = "Campo Obirgatório")]
        [Display(Name = "Conta:")]
        public string Conta { get; set; }
        [Required(ErrorMessage = "Campo Obirgatório")]
        [Display(Name = "Carteira:")]
        public string Carteira { get; set; }
        [Required(ErrorMessage = "Campo Obirgatório")]
        [Display(Name = "Nosso número:")]
        public string NossoNumero { get; set; }        
    }
}
