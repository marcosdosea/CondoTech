using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CondoTechWEB.Models
{
    public class AreacomumModel
    {
        [Display(Name ="Código")]
        [Key]
        [Required(ErrorMessage ="Código da área comum é obrigatório")]

        public int IdAreacomum { get; set; }

        [Display(Name ="Descrição")]
        [Required(ErrorMessage="A descrição da área é necessária")]
        [StringLength(45, MinimumLength = 5, ErrorMessage ="A descrição deve ter entre 5 e 45 caracteres")]

        public string Descricao { get; set; }

        [Display(Name = "Dias")]
        [Required(ErrorMessage ="Os dias das áreas são necessários")]
        [StringLength(45, MinimumLength = 5, ErrorMessage ="Os dias devem ter entre 5 e 45 caracteres")]
        //[DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]

        //public DateTime? Dias { get; set; }
        public string Dias { get; set; }



    }
}
