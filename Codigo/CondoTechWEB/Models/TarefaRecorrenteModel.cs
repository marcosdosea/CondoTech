using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CondoTechWEB.Models
{
    public class TarefaRecorrenteModel
    {
        [Display(Name = "Código da Tarefa")]
        [Key]
        [Required(ErrorMessage = "Código é obrigatório")]
        public int IdTarefaRecorrente { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(45, MinimumLength =5, ErrorMessage = "Título de tarefa obrigatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Descrição de tarefa obrigatoria")]
        public string Descricao { get; set; }

        [Display(Name = "Data de Inicio")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Data { get; set; }
    }
}
