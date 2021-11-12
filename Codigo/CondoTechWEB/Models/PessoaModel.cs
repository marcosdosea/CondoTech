using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CondoTechWEB.Models
{
    public class PessoaModel
    {
        [Display(Name = "Código da Pessoa")]
        [Key]
        [Required(ErrorMessage = "Código é obrigatório")]
        public int IdPessoa { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Nome da pessoa é obrigatorio")]
        public string Nome { get; set; }


       
    }
}
