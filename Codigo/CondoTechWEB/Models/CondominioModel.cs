using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CondoTechWEB.Models
{
    public class CondominioModel
    {
        [Display(Name ="Código")]
        [Key]
        [Required(ErrorMessage = "Código do condomínio é obrigatório!")]
        public int IdCondominio { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "CNPJ inválido!")]
        public string Cnpj { get; set; }


        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(45, MinimumLength = 15, ErrorMessage ="Nome do condomínio é inválido!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(14, MinimumLength = 12, ErrorMessage = "Telefone inválido!")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(45, MinimumLength = 15, ErrorMessage = "Email é inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(45, MinimumLength = 15, ErrorMessage = "Nome da rua é inválida!")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(45, MinimumLength = 15, ErrorMessage = "Nome do bairro é inválido!")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public int? Numero { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(45, MinimumLength = 15, ErrorMessage = "O CEP é inválido!")]
        public string Cep { get; set; }

    }
}
