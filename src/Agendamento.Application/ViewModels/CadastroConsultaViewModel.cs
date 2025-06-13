using System.ComponentModel.DataAnnotations;

namespace Agendamento.Application.ViewModels
{
    public class CadastroConsultaViewModel
    {
        [Required(ErrorMessage = "O campo Email é obrigatório")]
        public Guid MedicoId { get; set; }
        [Required(ErrorMessage = "O campo Email é obrigatório")]
        public Guid PacienteId { get; set; }
        [Required(ErrorMessage = "O campo Email é obrigatório")]
        public string Especialidade { get; set; }
        [Required(ErrorMessage = "O campo Email é obrigatório")]
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "O campo Email é obrigatório")]
        public TimeSpan Horario { get; set; }
    }
}