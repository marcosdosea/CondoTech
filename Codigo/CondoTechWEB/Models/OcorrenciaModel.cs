using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CondoTechWEB.Models
{
    public class OcorrenciaModel
    {
        [Display(Name = "Código")]
        [Key]
        [Required(ErrorMessage = "Código da ocorrência é obrigatório")]

        public int IdOcorrencias { get; set; }

        [Required(ErrorMessage ="Campo Requerido")]
        [StringLength(80, MinimumLength = 5, ErrorMessage = "Descrição inadequada")]

        public string Descricao { get; set; }

        [StringLength(45, MinimumLength = 5, ErrorMessage = "Tipo de ocorrência inadequado")]
        public string Tipo { get; set; }

        

    }
}
