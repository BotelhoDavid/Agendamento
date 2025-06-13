namespace Agendamento.Application.ViewModels
{
    public class ConsultaViewModel
    {
        public Guid Id { get; set; }
        public required PacienteViewModel Paciente { get; set; }
        public required MedicoViewModel Medico { get; set; }
        public required string Especialidade { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Horario { get; set; }

    }
}
