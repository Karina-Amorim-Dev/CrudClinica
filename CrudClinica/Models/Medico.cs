using System.ComponentModel.DataAnnotations;

namespace CrudClinica.Models
{
    public class Medico
    {
        public int idMedico { get; set; }

        [Required(ErrorMessage = "Informe o nome do médico.")]
        public string nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o CRM do médico.")]
        public string crm { get; set; } = string.Empty;

        [Required(ErrorMessage = "Selecione a especialidade.")]
        public int idEspecialidade { get; set; }        
        public string? especialidade { get; set; }
    }
}