using System;
using System.ComponentModel.DataAnnotations;

namespace Doar.Entity.Entities
{
    public class Doacao : BaseDominio
    {
        public int DoacaoId { get; set; }
        [Required(ErrorMessage = "Campo Obirgatório")]
        [Display(Name = "Vencimento:")]
        public DateTime Vencimento { get; set; }
        [Required(ErrorMessage = "Campo Obirgatório")]
        [Display(Name = "Valor:")]
        public decimal Valor { get; set; }
        public int? UsuarioId { get; set; }
    }
}
