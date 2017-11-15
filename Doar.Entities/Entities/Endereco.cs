using System.ComponentModel.DataAnnotations;

namespace Doar.Entity.Entities
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public string Logradouro { get; }
        [Required(ErrorMessage = "Campo Obirgatório")]
        [Display(Name = "Endereço:")]
        public string End { get; set; }
        [Required(ErrorMessage = "Campo Obirgatório")]
        [Display(Name = "Número:")]
        public string Numero { get; set; }
        [Required(ErrorMessage = "Campo Obirgatório")]
        [Display(Name = "Complemento:")]
        public string Complemento { get; set; }
        [Required(ErrorMessage = "Campo Obirgatório")]
        [Display(Name = "Bairro:")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "Campo Obirgatório")]
        [Display(Name = "Cidade:")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Campo Obirgatório")]
        [Display(Name = "UF:")]
        public string UF { get; set; }
        [Required(ErrorMessage = "Campo Obirgatório")]
        [Display(Name = "CEP:")]
        public string CEP { get; set; }
        public string Email { get; set; }
        public string EndComNumero { get; }
    }
}
