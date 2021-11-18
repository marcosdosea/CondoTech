using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CondoTechWEB.Models
{
    public class AreacomumModel
    {
        [Display(Name ="Código da área comum")]
        [Key]
        [Required(ErrorMessage ="Código da área comum é obrigatório")]

        public int IdAreaComum { get; set; }

        [Display(Name ="Código do condominio")]
        [Required(ErrorMessage ="Código do condominio é obrigatório")]

        public int IdCondominio { get; set; }

        [Required(ErrorMessage ="O nome da área é necessário")]
        [StringLength(45, MinimumLength = 5, ErrorMessage ="O nome da área deve ter entre 5 a 45 caracteres")]

        public string Nome { get; set; }

        [Display(Name ="Descrição")]
        [Required(ErrorMessage="A descrição da área é necessária")]
        [StringLength(45, MinimumLength = 5, ErrorMessage ="A descrição deve ter entre 5 e 45 caracteres")]

        public string Descricao { get; set; }

        

        



    }
}
