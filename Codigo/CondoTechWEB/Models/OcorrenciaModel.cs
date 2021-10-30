using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations

namespace CondoTechWEB.Models
{
    public class OcorrenciaModel
    {
        [Display(Name = "Código")]
        [Key]
        [Required(ErrorMessage = "Código da ocorrência é obrigatório")]

        public int IdOcorrencias { get; set; }

        [Required(ErrorMessage ="Campo Requerido")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Ocorrencia fora do formato")]

        public string Descricao { get; set; }

        [Display(Name = "Tipo")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Tipo Inválido")]
        public string Tipo { get; set; }

        

    }
}
