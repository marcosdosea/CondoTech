using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CondoTechWEB.Models
{
    public class AvisoModel
    {
        [Display(Name = "Codigo")]
        [Key]
        [Required(ErrorMessage = "Codigo Obrigatorio")]
        public int idAviso { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Descrição do Aviso é nescessária")]
        public String descricao { get; set; }

        [Display(Name = "Id Pessoa")]
        [Key]
        [Required(ErrorMessage = "Codigo Obrigatorio")]
        public int idPessoa { get; set; }

        [Display(Name = "Id Condominio")]
        [Key]
        [Required(ErrorMessage = "Codigo Obrigatorio")]
        public int idCondominio { get; set; }

        [Display(Name = "Data de Publicação")]
        [DataType(DataType.Date, ErrorMessage = "É necessário uma data válida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/YYYY}")]

        //Coloquei temporariamente para tentar resolver os erros (raul)
        public DateTime data { get; set; }
    }
}
