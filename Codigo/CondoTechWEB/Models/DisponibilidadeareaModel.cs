using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CondoTechWEB.Models
{
    public class DisponibilidadeareaModel
    {
        [Display(Name ="Código da disponibilidade de area")]
        [Key]
        [Required(ErrorMessage = "Código da disponibilidade de area é obrigatório")]
        public int IdDisponibilidadeArea { get; set; }

        [Display(Name = "Dias disponíveis")]
        [Required]
        [RegularExpression("segunda|terça|quarta|quinta|sexta|sábado|domingo", ErrorMessage = "Informe apenas o dia da semana entre segunda|terça|quarta|quinta|sexta|sábado|domingo")]
        public string DiaSemana { get; set; }

        [Display(Name ="Hora inicial")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh\\:mm}")]
        [RegularExpression(@"((([0-1][0-9])|(2[0-3]))(:[0-5][0-9])(:[0-5][0-9])?)", ErrorMessage = "Time must be between 00:00 to 23:59")]
        public TimeSpan HoraInicio { get; set; }

        [Display(Name ="Hora final")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh\\:mm}")]
        [RegularExpression(@"((([0-1][0-9])|(2[0-3]))(:[0-5][0-9])(:[0-5][0-9])?)", ErrorMessage = "Time must be between 00:00 to 23:59")]
        public TimeSpan HoraFim { get; set; }

        [Required(ErrorMessage ="A quantidade de vagas é necessaria")]
        public int Vagas { get; set; }

        [Display(Name ="Código da área comum")]
        [Required(ErrorMessage ="O código da área comum é necessário")]
        public int IdAreaComum { get; set; }
    }
}
