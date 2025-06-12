namespace Agendamento.Domain.Entities
{
    public class Consulta
    {
        public Guid Id { get; set; }
        public Guid PacienteId { get; set; }
        public Guid MedicoId { get; set; }
        public string Especialidade { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Horario { get; set; }

        public virtual Medico Medico { get; set; }
        public virtual Paciente Paciente { get; set; }
    }
}
