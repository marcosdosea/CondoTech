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

        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(15, MinimumLength = 11, ErrorMessage = "Número do CPF é obrigatorio")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(14, MinimumLength = 10, ErrorMessage = "Número do telefone é obrigatorio")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Email da pessoa é obrigatorio")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(45, MinimumLength = 8, ErrorMessage = "Senha é obrigatoria")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [RegularExpression("Ativo|Bloqueado|Excluido", ErrorMessage ="Informe um status entre: Ativo,Bloqueado, Excluido")]
        public string Status { get; set; }

    }
}
