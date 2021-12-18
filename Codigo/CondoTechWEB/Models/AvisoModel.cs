using System;
using System.ComponentModel.DataAnnotations;

namespace CondoTechWEB.Models
{
    public class AvisoModel
    {
        [Display(Name = "Codigo")]
        [Key]
        [Required(ErrorMessage = "Codigo Obrigatorio")]
        public int IdAviso { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Descrição do Aviso é nescessária")]
        public String Descricao { get; set; }

        [Display(Name = "Id Pessoa")]
        [Required(ErrorMessage = "Codigo Obrigatorio")]
        public int idPessoa { get; set; }

        [Display(Name = "Id Condominio")]
        [Required(ErrorMessage = "Codigo Obrigatorio")]
        public int idCondominio { get; set; }

        [Display(Name = "Data de Publicação")]
        [DataType(DataType.Date, ErrorMessage = "É necessário uma data válida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/YYYY}")]

        //Coloquei temporariamente para tentar resolver os erros (raul)
        public DateTime Data { get; set; }
    }
}
