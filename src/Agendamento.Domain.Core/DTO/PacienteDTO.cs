namespace Agendamento.Domain.Core.DTO
{
    public class PacienteDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = default!;
        public string CPF { get; set; } = default!;
        public DateTime DataNascimento { get; set; }
    }
}
