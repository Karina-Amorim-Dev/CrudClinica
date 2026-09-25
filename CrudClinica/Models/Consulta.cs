using System.ComponentModel.DataAnnotations;

namespace CrudClinica.Models
{
    public class Consulta
    {
        public int idConsulta { get; set; }

        [Required(ErrorMessage = "Selecione o médico.")]
        public int idMedico { get; set; }
        public string? medico { get; set; }

        [Required(ErrorMessage = "Selecione o paciente.")]
        public int idPaciente { get; set; }
        public string? paciente { get; set; }

        [Required(ErrorMessage = "Informe a data e hora da consulta.")]
        public DateTime dataHora { get; set; }
    }
}
