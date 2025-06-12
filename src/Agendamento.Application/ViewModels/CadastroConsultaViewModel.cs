namespace Agendamento.Application.ViewModels
{
    public class CadastroConsultaViewModel
    {
        public Guid MedicoId { get; set; }
        public Guid PacienteId { get; set; }
        public string Especialidade { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Horario { get; set; }
    }
}