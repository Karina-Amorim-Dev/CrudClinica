using System.ComponentModel.DataAnnotations;

namespace CrudClinica.Models
{
    public class Paciente
    {
        public int idPaciente { get; set; }

        [Required(ErrorMessage = "Informe o nome do paciente.")]
        public string nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o CPF do paciente.")]
        public string cpf { get; set; } = string.Empty;
        public string? telefone { get; set; }
        public DateTime? dataNasc { get; set; }
    }
}