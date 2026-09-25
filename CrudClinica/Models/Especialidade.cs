using System.ComponentModel.DataAnnotations;

namespace CrudClinica.Models
{
    public class Especialidade
    {
        public int idEspecialidade { get; set; }

        [Required(ErrorMessage = "Informe o nome da especialidade.")]
        public string nome { get; set; } = string.Empty;
    }
}
