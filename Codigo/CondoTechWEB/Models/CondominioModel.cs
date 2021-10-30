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


        [Display(Name ="Nome")]
        [Required(ErrorMessage ="Campo requerido")]
        [StringLength(50, MinimumLength =15, ErrorMessage ="Nome do condomínio é inválido!")]
        public string Nome { get; set; }

        [Display(Name ="Rua")]
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(50, MinimumLength = 15, ErrorMessage = "Nome da rua é inválida!")]
        public string Rua { get; set; }

        [Display(Name ="Bairro")]
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(50, MinimumLength = 15, ErrorMessage = "Nome do bairro é inválido!")]
        public string Bairro { get; set; }

        [Display(Name ="Numero")]
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Nome do número é inválido!")]
        public int? Numero { get; set; }



    }
}
