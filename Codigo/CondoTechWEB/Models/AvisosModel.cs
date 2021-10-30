using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CondoTechWEB.Models
{
    public class AvisosModel
    {
        [Display(Name = "Codigo")]
        [Key]
        [Required(ErrorMessage = "Codigo Obrigatorio")]
        public int IdAvisos { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Descrição do Aviso é nescessária")]
        public String Descricao { get; set; }

        [Display(Name = "Data de Publicação")]
        [DataType(DataType.Date, ErrorMessage = "É necessário uma data válida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/YYYY}")]
    }
}
